using AxWMPLib;
using CinemaProject.Models;
using CinemaProject.Services;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class VideoPlayerForm : Form
    {
        private string videoPath_;

        private MediaPlayer mediaPlayer;

        public VideoPlayerForm(string videoPath)
        {
            InitializeComponent();
            videoPath_ = videoPath;
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, videoPath_);
            wmpPlayer.stretchToFit = true;
            if (System.IO.File.Exists(videoPath_))
            {
                wmpPlayer.URL = videoPath_;
                wmpPlayer.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show($"Файл не найден:\n{fullPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}   