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
        private readonly MovieManager movieManager_ = new MovieManager();
        private readonly UserManager userManager_ = new UserManager();

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

            LoadMovieCatalog(movieManager_.GetAllMovies());
            RenderRecommendations();
        }

        public void LoadMovieCatalog(List<Movie> movies)
        {
            flpMovieCatalog.Controls.Clear();

            if (movies == null || movies.Count == 0)
            {
                Label lblEmpty = new Label()
                {
                    Text = "Не удалось загрузить список фильмов. Попробуйте зайти позже",
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
                    TextAlign = ContentAlignment.TopCenter
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
                        BackColor = Color.LightBlue
                    };
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
                        BackColor = Color.LightCoral
                    };
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
            LoadMovieCatalog(movieManager_.SearchMovies(txtSearch.Text));
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
            Panel card = sender as Panel;
            if (card != null && card.Tag is Movie movie)
            {
                string quality = "720p";
                using (Form qForm = new Form() { Text = "О фильме: " + movie.Title, Width = 350, Height = 300, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false, StartPosition = FormStartPosition.CenterParent })
                {
                    TextBox txtMovieDescription = new TextBox()
                    {
                        Text = string.IsNullOrEmpty(movie.Description) ? "Описание отсутствует." : movie.Description,
                        Top = 15,
                        Left = 15,
                        Width = 305,
                        Height = 100,
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        BackColor = SystemColors.Control,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    RadioButton r1 = new RadioButton() { Text = "480p", Top = 130, Left = 20 };
                    RadioButton r2 = new RadioButton() { Text = "720p", Top = 155, Left = 20, Checked = true };
                    RadioButton r3 = new RadioButton() { Text = "1080p", Top = 180, Left = 20 };

                    Button ok = new Button() { Text = "Смотреть", Top = 215, Left = 120, Width = 100, Height = 30 };

                    ok.Click += (s, ev) => {
                        if (r1.Checked) quality = "480p";
                        if (r2.Checked) quality = "720p";
                        if (r3.Checked) quality = "1080p";

                        qForm.DialogResult = DialogResult.OK;
                        qForm.Close();
                    };

                    qForm.Controls.Add(txtMovieDescription);
                    qForm.Controls.Add(r1);
                    qForm.Controls.Add(r2);
                    qForm.Controls.Add(r3);
                    qForm.Controls.Add(ok);

                    if (qForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                string videoPath = movie.GetVideoPathByQuality(quality);

                if (string.IsNullOrEmpty(videoPath))
                {
                    string[] backupQualities;

                    if (quality == "720p")
                    {
                        backupQualities = new string[] { "1080p", "480p" };
                    }
                    else if (quality == "1080p")
                    {
                        backupQualities = new string[] { "720p", "480p" };
                    }
                    else
                    {
                        backupQualities = new string[] { "720p", "1080p" };
                    }

                    bool alternativeFound = false;
                    foreach (string altQuality in backupQualities)
                    {
                        string altPath = movie.GetVideoPathByQuality(altQuality);

                        if (!string.IsNullOrEmpty(altPath))
                        {
                            videoPath = altPath;
                            alternativeFound = true;
                            break;
                        }
                    }

                    if (!alternativeFound)
                    {
                        MessageBox.Show("Видео недоступно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                userManager_.AddToHistory(movie.Id);
                RenderRecommendations();

                using (VideoPlayerForm playerForm = new VideoPlayerForm(videoPath))
                {
                    playerForm.ShowDialog();
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

        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            using (HistoryForm historyForm = new HistoryForm(currentUser_))
            {
                historyForm.ShowDialog();
            }
        }
    }
}