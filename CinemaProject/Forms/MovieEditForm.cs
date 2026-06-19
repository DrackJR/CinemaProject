using CinemaProject.Managers; // Подключаем менеджер фильмов
using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MovieEditForm : Form
    {
        private readonly MovieManager _movieManager = new MovieManager();

        public MovieEditForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Заполните все данные о фильме");
                return;
            }

            double rate = 0;
            double.TryParse(txtRating.Text, out rate);
            Movie newMovie = new Movie(0, txtTitle.Text, txtGenre.Text, rate);

            try
            {
                _movieManager.AddMovie(newMovie);
                MessageBox.Show("Фильм добавлен успешно!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения");
            }
        }
    }
}