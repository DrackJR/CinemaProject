using CinemaProject.Managers; // Подключаем менеджеры по ПЗ
using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private readonly MovieManager _movieManager = new MovieManager();
        private readonly UserManager _userManager = new UserManager();

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Онлайн-кинотеатр | " + _currentUser.Login;
            cmbGenreFilter.Items.AddRange(new object[] { "Все", "Фантастика", "Драма", "Боевик", "Комедия" });
            cmbGenreFilter.SelectedIndex = 0;

            if (_currentUser.Role == "Admin") btnAdminPanel.Visible = true;

            LoadMovieCatalog(_movieManager.GetAllMovies());
            RenderRecommendations();
        }

        public void LoadMovieCatalog(List<Movie> movies)
        {
            flpMovieCatalog.Controls.Clear();
            foreach (Movie movie in movies)
            {
                Panel card = new Panel() { Width = 150, Height = 100, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(10), Tag = movie, Cursor = Cursors.Hand };
                card.Controls.Add(new Label { Text = movie.Title, Left = 10, Top = 10, Width = 130, Font = new Font(Font, FontStyle.Bold), Enabled = false });
                card.Controls.Add(new Label { Text = movie.Genre + "\n★ " + movie.Rating.ToString("F1"), Left = 10, Top = 45, Width = 130, Enabled = false });

                card.Click += MovieCard_Click;
                flpMovieCatalog.Controls.Add(card);
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

                using (VideoPlayerForm playerForm = new VideoPlayerForm(movie, quality))
                {
                    playerForm.ShowDialog();
                }
            }
        }

        private void RenderRecommendations()
        {
            lbRecommendations.Items.Clear();
            List<Movie> recs = _userManager.GetPersonalRecommendations(_movieManager);
            foreach (Movie r in recs) lbRecommendations.Items.Add(r.Title + " — ★" + r.Rating.ToString("F1"));
        }
    }
}