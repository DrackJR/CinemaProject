using AxWMPLib;
using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class VideoPlayerForm : Form
    {
        private string videoPath_;

        public VideoPlayerForm(string videoPath)
        {
            InitializeComponent();
            videoPath_ = videoPath;
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            string fullPath = videoPath_;
            wmpPlayer.stretchToFit = true;
            wmpPlayer.URL = videoPath_;
            wmpPlayer.Ctlcontrols.play();
        }
    }
}   