using CinemaProject.Managers;
using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly User currentUser_;
        private readonly MovieManager movieManager_ = new MovieManager();
        private readonly UserManager userManager_ = new UserManager();

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser_ = user;
            userManager_.CurrentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Онлайн-кинотеатр | " + currentUser_.Login;
            cmbGenreFilter.Items.AddRange(new object[] { "Все", "Фантастика", "Драма", "Боевик", "Комедия" });
            cmbGenreFilter.SelectedIndex = 0;

            if (currentUser_.Role == "Admin") btnAdminPanel.Visible = true;

            LoadMovieCatalog(movieManager_.GetAllMovies());
            RenderRecommendations();
        }

        public void LoadMovieCatalog(List<Movie> movies, bool isSearch = false)
        {
            flpMovieCatalog.Controls.Clear();

            if (movies == null || movies.Count == 0)
            {

                string message;

                if (isSearch)
                {
                    message = "По вашему запросу ничего не найдено";
                }
                else
                {
                    message = "Не удалось загрузить список фильмов. Попробуйте зайти позже";
                }

                Label lblEmpty = new Label()
                {
                   Text = message,
                   ForeColor = Color.Gray,
                   Font = new Font("Segoe UI", 12, FontStyle.Italic),
                   AutoSize = false,
                   Width = flpMovieCatalog.Width - 30,
                   Height = 100,
                   TextAlign = ContentAlignment.MiddleCenter
                };

                flpMovieCatalog.Controls.Add(lblEmpty);
                return;
            }

            foreach (Movie movie in movies)
            {
                int cardHeight = (currentUser_.Role == "Admin") ? 280 : 220;

                Panel card = new Panel()
                {
                    Width = 150,
                    Height = cardHeight,
                    BackColor = Color.FromArgb(37, 37, 50),
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
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand
                };
                pbPoster.Click += (s, e) => MovieCard_Click(card, e);

                if (!string.IsNullOrEmpty(movie.PosterPath))
                {
                    try
                    {
                        pbPoster.Image = Image.FromFile(movie.PosterPath);
                    }
                    catch
                    {
                        pbPoster.Image = null;
                    }
                }
                card.Controls.Add(pbPoster);

                Label lbl = new Label()
                {
                    Text = movie.Title,
                    Location = new Point(10, 155),
                    Width = 130,
                    Height = 35,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    TextAlign = ContentAlignment.TopCenter,
                    Cursor = Cursors.Hand
                };
                lbl.Click += (s, e) => MovieCard_Click(card, e);
                card.Controls.Add(lbl);

                if (currentUser_.Role == "Admin")
                {
                    Button btnEdit = new Button()
                    {
                        Text = "Редактировать",
                        Location = new Point(10, 215),
                        Width = 130,
                        Height = 25,
                        BackColor = Color.FromArgb(55, 55, 70),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Click += (s, ev) =>
                    {
                        using (MovieEditForm editForm = new MovieEditForm(movie))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadMovieCatalog(movieManager_.GetAllMovies());
                            }
                        }
                    };
                    card.Controls.Add(btnEdit);

                    Button btnDelete = new Button()
                    {
                        Text = "Удалить",
                        Location = new Point(10, 245),
                        Width = 130,
                        Height = 25,
                        BackColor = Color.FromArgb(220, 53, 69),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };
                    btnDelete.FlatAppearance.BorderSize = 0;
                    btnDelete.Click += (s, ev) =>
                    {
                        DialogResult dr = MessageBox.Show($"Вы уверены, что хотите удалить фильм \"{movie.Title}\"?",
                            "Удаление фильма", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                movieManager_.DeleteMovie(movie.Id);
                                LoadMovieCatalog(movieManager_.GetAllMovies());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };
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
                movieManager_.DeleteMovie(movieId);

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
            string keyword = txtSearch.Text.Trim().ToLower();


            var allMovies = movieManager_.GetAllMovies();


            var filteredMovies = allMovies.Where(m => m.Title.ToLower().Contains(keyword)).ToList();

            LoadMovieCatalog(filteredMovies, true);
        }

        private void cmbGenreFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMovieCatalog(movieManager_.FilterByGenre(cmbGenreFilter.Text));
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            using (MovieEditForm editForm = new MovieEditForm())
            {
                editForm.ShowDialog();
            }
            LoadMovieCatalog(movieManager_.GetAllMovies());
        }

        private void MovieCard_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            if (clickedControl == null || clickedControl.Tag == null) return;

            Movie selectedMovie = (Movie)clickedControl.Tag;

            using (MovieDetailForm detailForm = new MovieDetailForm(selectedMovie))
            {
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    string quality = detailForm.SelectedQuality;

                    string videoPath = selectedMovie.GetVideoPathByQuality(quality);

                    if (string.IsNullOrEmpty(videoPath))
                    {
                        videoPath = AutoFallbackQuality(selectedMovie, quality);
                    }

                    if (string.IsNullOrEmpty(videoPath))
                    {
                        MessageBox.Show("К сожалению, video недоступно ни в одном разрешении.",
                                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    userManager_.AddToHistory(selectedMovie.Id);

                    RenderRecommendations();

                    using (VideoPlayerForm playerForm = new VideoPlayerForm(videoPath))
                    {
                        playerForm.ShowDialog();
                    }
                }
            }
        }

        private void RenderRecommendations()
        {
            lbRecommendations.Items.Clear();

            List<Movie> recs = userManager_.GetPersonalRecommendations(movieManager_);

            foreach (Movie r in recs)
            {
                lbRecommendations.Items.Add(r.Title + " — ★" + r.Rating.ToString("F1"));
            }
        }
        private string AutoFallbackQuality(Movie movie, string failedQuality)
        {
            string[] alternatives;

            if (failedQuality == "720p")
                alternatives = new string[] { "1080p", "480p" };
            else if (failedQuality == "1080p")
                alternatives = new string[] { "720p", "480p" };
            else
                alternatives = new string[] { "720p", "1080p" };

            foreach (var quality in alternatives)
            {
                string path = movie.GetVideoPathByQuality(quality);
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }

            return null;
        }

        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            using (HistoryForm historyForm = new HistoryForm(currentUser_))
            {
                historyForm.ShowDialog();
            }
        }
    }
}