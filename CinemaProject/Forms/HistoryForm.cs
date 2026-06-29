using CinemaProject.Models;
using CinemaProject.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class HistoryForm : Form
    {
        private readonly User user_;
        private readonly UserRepository userRepo_ = new UserRepository();
        private readonly MovieRepository movieRepo_ = new MovieRepository();

        public HistoryForm(User user)
        {
            InitializeComponent();
            user_ = user;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            this.Text = $"История просмотров | {user_.Login}";
            LoadWatchHistoryFromDb();
        }

        private void LoadWatchHistoryFromDb()
        {
            lbHistory.Items.Clear();

            List<int> watchedMovieIds = userRepo_.GetUserHistory(user_.Id);

            if (watchedMovieIds == null || watchedMovieIds.Count == 0)
            {
                lbHistory.Items.Add("Вы еще не посмотрели ни одного фильма.");
                return;
            }

            var allMovies = movieRepo_.GetAllMovies();

            foreach (int movieId in watchedMovieIds)
            {
                var movie = allMovies.Find(m => m.Id == movieId);
                if (movie != null)
                {
                    lbHistory.Items.Add($"{movie.Title} — Просмотрено");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}