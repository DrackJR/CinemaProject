using CinemaProject.Models;
using CinemaProject.Repositories;
using Npgsql;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaProject.Managers
{
    public class UserManager
    {
        private User currentUser_ = new User();
        private readonly UserRepository repo_ = new UserRepository();
        public User CurrentUser
        {
            get { return currentUser_; }
            set { currentUser_ = value; }
        }


        public bool Register(string login, string password)
        {
            if (repo_.IsLoginExists(login)) return false;
            repo_.RegisterUser(login, password, "User");
            return true;
        }

        public User Authenticate(string login, string password)
        {
            User user = repo_.Authenticate(login, password);
            if (user != null)
            {
                user.History = repo_.GetUserHistory(user.Id);
                currentUser_ = user;
                return currentUser_;
            }
            return null;
        }

        public void AddToHistory(int movieId)
        {
            int finalUserId = (currentUser_ != null && currentUser_.Id > 0) ? currentUser_.Id : 1;

            List<int> currentHistory = repo_.GetUserHistory(finalUserId);
            if (currentHistory.Contains(movieId))
            {
                return;
            }

            repo_.SaveMovieToHistory(finalUserId, movieId);
        }

        public List<Movie> GetPersonalRecommendations(MovieManager movieManager)
        {
            return repo_.GetPersonalRecommendations(currentUser_.Id);
        }
        public List<int> GetUserHistory(int userId)
        {
            try
            {
                return repo_.GetUserHistory(userId);
            }
            catch
            {
                return new List<int>();
            }
        }
        
    }
}