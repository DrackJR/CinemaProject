using CinemaProject.Models;
using CinemaProject.Repositories;
using System.Collections.Generic;

namespace CinemaProject.Managers
{
    public class UserManager
    {
        private User currentUser_ = new User();
        private readonly UserRepository repo_ = new UserRepository();

        public User CurrentUser
        {
            get { return currentUser_; }
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
            repo_.AddToHistory(finalUserId, movieId);
        }

        public List<Movie> GetPersonalRecommendations(MovieManager movieManager)
        {
            return repo_.GetPersonalRecommendations(currentUser_.Id);
        }
    }
}