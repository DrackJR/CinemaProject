using CinemaProject.Managers;
using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MovieEditForm : Form
    {
        private readonly MovieManager _movieManager = new MovieManager();
        private readonly Movie _editingMovie = null;

        // Этот конструктор вызывается при ДОБАВЛЕНИИ нового фильма
        public MovieEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление фильма";
        }

        // Этот конструктор вызывается при РЕДАКТИРОВАНИИ существующего фильма
        public MovieEditForm(Movie movie)
        {
            InitializeComponent();
            _editingMovie = movie;
            this.Text = "Редактирование фильма";
        }

        // Событие загрузки формы: заполняем поля, если мы редактируем
        private void MovieEditForm_Load(object sender, EventArgs e)
        {
            if (_editingMovie != null)
            {
                txtTitle.Text = _editingMovie.Title;
                txtGenre.Text = _editingMovie.Genre;
                txtRating.Text = _editingMovie.Rating.ToString();
                txtDesc.Text = _editingMovie.Description;
                txtPoster.Text = _editingMovie.PosterPath;
                txtV480.Text = _editingMovie.VideoPath480p;
                txtV720.Text = _editingMovie.VideoPath720p;
                txtV1080.Text = _editingMovie.VideoPath1080p;
            }
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

        private void btnBrowse480_Click(object sender, EventArgs e) => BrowseVideo(txtV480, "480p");
        private void btnBrowse720_Click(object sender, EventArgs e) => BrowseVideo(txtV720, "720p");
        private void btnBrowse1080_Click(object sender, EventArgs e) => BrowseVideo(txtV1080, "1080p");

        private void BrowseVideo(TextBox targetTextBox, string quality)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Видео файлы (*.mp4;*.mkv;*.avi)|*.mp4;*.mkv;*.avi|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите видео " + quality;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double rate = 0;
            double.TryParse(txtRating.Text, out rate);

            if (_editingMovie == null)
            {
                // Логика добавления нового фильма
                Movie newMovie = new Movie()
                {
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
                    MessageBox.Show("Фильм успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Логика редактирования существующего фильма
                _editingMovie.Title = txtTitle.Text;
                _editingMovie.Genre = txtGenre.Text;
                _editingMovie.Rating = rate;
                _editingMovie.Description = txtDesc.Text;
                _editingMovie.PosterPath = txtPoster.Text;
                _editingMovie.VideoPath480p = txtV480.Text;
                _editingMovie.VideoPath720p = txtV720.Text;
                _editingMovie.VideoPath1080p = txtV1080.Text;

                try
                {
                    _movieManager.UpdateMovie(_editingMovie);
                    MessageBox.Show("Фильм успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}