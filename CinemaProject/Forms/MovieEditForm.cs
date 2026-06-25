using CinemaProject.Managers;
using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MovieEditForm : Form
    {
        private readonly MovieManager movieManager_ = new MovieManager();
        private readonly Movie editingMovie_ = null;

        public MovieEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление фильма";
        }

        public MovieEditForm(Movie movie)
        {
            InitializeComponent();
            editingMovie_ = movie;
            this.Text = "Редактирование фильма";
        }

        private void MovieEditForm_Load(object sender, EventArgs e)
        {
            cmbGenre.Items.Clear();
            cmbGenre.Items.AddRange(new string[] { "Фантастика", "Драма", "Боевик", "Комедия" });
            cmbGenre.SelectedIndex = 0;

            if (editingMovie_ != null)
            {
                btnSave.Text = "Изменить";
                txtTitle.Text = editingMovie_.Title;
                txtRating.Text = editingMovie_.Rating.ToString();
                txtDesc.Text = editingMovie_.Description;
                txtPoster.Text = editingMovie_.PosterPath;
                txtV480.Text =  editingMovie_.VideoPath480p;
                txtV720.Text = editingMovie_.VideoPath720p;
                txtV1080.Text = editingMovie_.VideoPath1080p;

                if (cmbGenre.Items.Contains(editingMovie_.Genre))
                {
                    cmbGenre.SelectedItem = editingMovie_.Genre;
                }
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
                    txtPoster.Text = ofd.FileName;
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
                    targetTextBox.Text = ofd.FileName;
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

            string selectedGenre = cmbGenre.SelectedItem?.ToString() ?? "Фантастика";

            if (editingMovie_ == null)
            {
                Movie newMovie = new Movie()
                {
                    Title = txtTitle.Text,
                    Genre = selectedGenre,
                    Rating = rate,
                    Description = txtDesc.Text,
                    PosterPath = txtPoster.Text,
                    VideoPath480p = !string.IsNullOrWhiteSpace(txtV480.Text) ? txtV480.Text : string.Empty,
                    VideoPath720p = !string.IsNullOrWhiteSpace(txtV720.Text) ? txtV720.Text : string.Empty,
                    VideoPath1080p = !string.IsNullOrWhiteSpace(txtV1080.Text) ? txtV1080.Text : string.Empty
                };

                try
                {
                    movieManager_.AddMovie(newMovie);
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
                editingMovie_.Title = txtTitle.Text;
                editingMovie_.Genre = selectedGenre;
                editingMovie_.Rating = rate;
                editingMovie_.Description = txtDesc.Text;
                editingMovie_.PosterPath = txtPoster.Text;
                editingMovie_.VideoPath480p = txtV480.Text;
                editingMovie_.VideoPath720p = txtV720.Text;
                editingMovie_.VideoPath1080p = txtV1080.Text;

                try
                {
                    movieManager_.UpdateMovie(editingMovie_);   
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