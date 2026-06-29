using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class MovieDetailForm : Form
    {
        private Movie movie_;

        public string SelectedQuality { get; private set; } = "720p";

        public MovieDetailForm(Movie movie)
        {
            InitializeComponent();
            movie_ = movie;

            this.Text = $"Детали фильма: {movie.Title}";
            lblTitle.Text = movie.Title;
            lblRating.Text = $"Рейтинг: {movie.Rating:F1}";

            txtDescription.Text = movie.Description;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (rb480.Checked) SelectedQuality = "480p";
            else if (rb1080.Checked) SelectedQuality = "1080p";
            else SelectedQuality = "720p";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}