using System;
using System.Windows.Forms;
using CinemaProject.Models;

namespace CinemaProject.Forms
{
    public partial class VideoPlayerForm : Form
    {
        private Movie movie_;
        private string quality_;

        public VideoPlayerForm(Movie movie, string quality)
        {
            InitializeComponent();
            movie_ = movie;
            quality_ = quality;
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            wmpPlayer.uiMode = "full";

            string path = movie_.GetVideoPathByQuality(quality_);

            wmpPlayer.URL = path;
        }
    }
}