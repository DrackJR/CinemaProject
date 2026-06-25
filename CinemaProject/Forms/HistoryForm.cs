using CinemaProject.Managers;
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
        private readonly MovieManager movieManager_ = new MovieManager();
        private readonly UserRepository userRepository_ = new UserRepository();

        public HistoryForm(User user)
        {
            InitializeComponent();
            user_ = user;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            lbHistory.Items.Clear();

            try
            {
                List<int> movieIds = userRepository_.GetUserHistory(user_.Id);

                if (movieIds.Count == 0)
                {
                    lbHistory.Items.Add("Вы еще не посмотрели ни одного фильма.");
                    return;
                }

                foreach (int movieId in movieIds)
                {
                    Movie movie = movieManager_.GetMovieById(movieId);
                    if (movie != null)
                    {
                        lbHistory.Items.Add($"{movie.Title} ({movie.Genre})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке истории: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}