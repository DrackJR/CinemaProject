using System;
using System.Windows.Forms;
using CinemaProject.Models;
using CinemaProject.Services; // Обертка плеера лежит здесь по структуре проекта

namespace CinemaProject.Forms
{
    public partial class VideoPlayerForm : Form
    {
        private readonly Movie movie_;
        private readonly string quality_;
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private bool isPlaying = true;

        public VideoPlayerForm(Movie movie, string quality)
        {
            InitializeComponent();
            movie_ = movie;
            quality_ = quality;
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            string path = movie_.GetVideoPathByQuality(quality_);
            mediaPlayer.LoadMovie(path);

            mediaPlayer.PositionChanged += (sec) =>
            {
                if (tbSeek.IsDisposed) return;
                tbSeek.Value = Math.Min(sec, tbSeek.Maximum);
                lblStatus.Text = "Файл: " + path + " | Время: " + mediaPlayer.GetCurrentPosition().ToString("mm\\:ss");
            };
            mediaPlayer.Play();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (isPlaying) { mediaPlayer.Pause(); btnPlayPause.Text = "Старт"; }
            else { mediaPlayer.Play(); btnPlayPause.Text = "Пауза"; }
            isPlaying = !isPlaying;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
            this.Close();
        }

        private void tbVolume_Scroll(object sender, EventArgs e) { mediaPlayer.SetVolume(tbVolume.Value); }
        private void tbSeek_Scroll(object sender, EventArgs e) { mediaPlayer.Seek(tbSeek.Value); }
    }
}