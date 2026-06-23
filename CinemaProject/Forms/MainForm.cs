    using CinemaProject.Managers;
using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly User currentUser_;
        private readonly MovieManager _movieManager = new MovieManager();
        private readonly UserManager _userManager = new UserManager();

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser_ = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Онлайн-кинотеатр | " + currentUser_.Login;
            cmbGenreFilter.Items.AddRange(new object[] { "Все", "Фантастика", "Драма", "Боевик", "Комедия" });
            cmbGenreFilter.SelectedIndex = 0;

            if (currentUser_.Role == "Admin") btnAdminPanel.Visible = true;

            LoadMovieCatalog(_movieManager.GetAllMovies());
            RenderRecommendations();
        }

        public void LoadMovieCatalog(List<Movie> movies)
        {
            flpMovieCatalog.Controls.Clear();
            foreach (Movie movie in movies)
            {
                int cardHeight = (currentUser_.Role == "Admin") ? 250 : 220;

                Panel card = new Panel()
                {
                    Width = 150,
                    Height = cardHeight,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Tag = movie
                };

                card.Click += MovieCard_Click;

                PictureBox pbPoster = new PictureBox()
                {
                    Width = 130,
                    Height = 140,
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                pbPoster.Click += (s, e) => MovieCard_Click(card, e);

                string pathFromDb = movie.PosterPath ?? "";

                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromDb);


                    if (System.IO.File.Exists(fullPath))
                    {
                        pbPoster.ImageLocation = fullPath;
                        pbPoster.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbPoster.BackColor = Color.Gray;
                    }

            
                card.Controls.Add(pbPoster);

                Label lbl = new Label()
                {
                    Text = movie.Title,
                    Location = new Point(10, 155),
                    Width = 130,
                    Height = 35,
                    TextAlign = ContentAlignment.TopCenter
                };
                lbl.Click += (s, e) => MovieCard_Click(card, e);
                card.Controls.Add(lbl);

                if (currentUser_.Role == "Admin")
                {
                    Button btnDelete = new Button()
                    {
                        Text = "Удалить",
                        Location = new Point(10, 215),
                        Width = 130,
                        Height = 25,
                        BackColor = Color.LightCoral
                    };

                    btnDelete.Tag = movie.Id;
                    btnDelete.Click += BtnDelete_Click;

                    card.Controls.Add(btnDelete);
                }

                flpMovieCatalog.Controls.Add(card);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int movieId = (int)clickedButton.Tag;

            try
            {
                _movieManager.DeleteMovie(movieId);

                Control cardPanel = clickedButton.Parent;
                if (cardPanel != null)
                {
                    flpMovieCatalog.Controls.Remove(cardPanel);
                    cardPanel.Dispose();
                }
                RenderRecommendations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMovieCatalog(_movieManager.SearchMovies(txtSearch.Text));
        }

        private void cmbGenreFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMovieCatalog(_movieManager.FilterByGenre(cmbGenreFilter.Text));
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            using (MovieEditForm editForm = new MovieEditForm())
            {
                editForm.ShowDialog();
            }
            LoadMovieCatalog(_movieManager.GetAllMovies());
        }

        private void MovieCard_Click(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card != null && card.Tag is Movie movie)
            {
                string quality = "720p";
                using (Form qForm = new Form() { Text = "Качество", Width = 200, Height = 150, StartPosition = FormStartPosition.CenterParent })
                {
                    RadioButton r1 = new RadioButton() { Text = "480p", Top = 10, Left = 20 };
                    RadioButton r2 = new RadioButton() { Text = "720p", Top = 35, Left = 20, Checked = true };
                    RadioButton r3 = new RadioButton() { Text = "1080p", Top = 60, Left = 20 };
                    Button ok = new Button() { Text = "ОК", Top = 85, Left = 50 };
                    ok.Click += (s, ev) => {
                        if (r1.Checked) quality = "480p";
                        if (r3.Checked) quality = "1080p";
                        qForm.Close();
                    };
                    qForm.Controls.Add(r1); qForm.Controls.Add(r2); qForm.Controls.Add(r3); qForm.Controls.Add(ok);
                    qForm.ShowDialog();
                }

                _userManager.AddToHistory(movie.Id);

                RenderRecommendations();

                string videoPath = movie.GetVideoPathByQuality(quality);

                using (VideoPlayerForm playerForm = new VideoPlayerForm(videoPath))
                {
                    playerForm.ShowDialog();
                }
            }
        }

        private void RenderRecommendations()
        {
            lbRecommendations.Items.Clear();

            List<Movie> recs = _userManager.GetPersonalRecommendations(_movieManager);

            foreach (Movie r in recs)
            {
                lbRecommendations.Items.Add(r.Title + " — ★" + r.Rating.ToString("F1"));
            }
        }
    }
}