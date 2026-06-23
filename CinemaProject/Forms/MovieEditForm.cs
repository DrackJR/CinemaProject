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
        private void btnBrowsePoster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите постер фильма";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPoster.Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            }
        }

        // Обзор для видео 480p
        private void btnBrowse480_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Видео файлы (*.mp4;*.mkv;*.avi)|*.mp4;*.mkv;*.avi|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите видео 480p";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtV480.Text = ofd.FileName;
                }
            }
        }

        // Обзор для видео 720p
        private void btnBrowse720_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Видео файлы (*.mp4;*.mkv;*.avi)|*.mp4;*.mkv;*.avi|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите видео 720p";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtV720.Text = ofd.FileName;
                }
            }
        }

        // Обзор для видео 1080p
        private void btnBrowse1080_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Видео файлы (*.mp4;*.mkv;*.avi)|*.mp4;*.mkv;*.avi|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите видео 1080p";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtV1080.Text = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Заполните название и жанр фильма!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtV480.Text) &&
                string.IsNullOrWhiteSpace(txtV720.Text) &&
                string.IsNullOrWhiteSpace(txtV1080.Text))
            {
                MessageBox.Show("Необходимо указать путь к видео хотя бы для одного качества (480p, 720p или 1080p)!",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double rate = 0;
            double.TryParse(txtRating.Text, out rate);

            Movie newMovie = new Movie()
            {
                Id = 0,
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Rating = rate,
                Description = txtDesc.Text,
                PosterPath = txtPoster.Text,
                VideoPath480p = !string.IsNullOrWhiteSpace(txtV480.Text) ? txtV480.Text : string.Empty,
                VideoPath720p = !string.IsNullOrWhiteSpace(txtV720.Text) ? txtV720.Text : string.Empty,
                VideoPath1080p = !string.IsNullOrWhiteSpace(txtV1080.Text) ? txtV1080.Text : string.Empty
            };

            try
            {
                _movieManager.AddMovie(newMovie);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить фильм в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}