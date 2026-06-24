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
        private readonly User _user;
        private readonly MovieManager _movieManager = new MovieManager();
        private readonly UserRepository _userRepository = new UserRepository(); // Для получения ID фильмов из истории

        public HistoryForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            lbHistory.Items.Clear();

            try
            {
                // 1. Получаем список ID просмотренных фильмов для текущего пользователя из базы
                List<int> movieIds = _userRepository.GetUserHistory(_user.Id);

                if (movieIds.Count == 0)
                {
                    lbHistory.Items.Add("Вы еще не посмотрели ни одного фильма.");
                    return;
                }

                // 2. Для каждого ID достаем название фильма и выводим его в список
                foreach (int movieId in movieIds)
                {
                    Movie movie = _movieManager.GetMovieById(movieId);
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