using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class VideoPlayerForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TrackBar tbSeek;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tbVolume;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.videoPanel = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbSeek = new System.Windows.Forms.TrackBar();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.videoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // videoPanel
            // 
            this.videoPanel.BackColor = System.Drawing.Color.Black;
            this.videoPanel.Controls.Add(this.lblStatus);
            this.videoPanel.Location = new System.Drawing.Point(15, 15);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(450, 130);
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(10, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(430, 30);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Text = "Загрузка видео...";
            // 
            // tbSeek
            // 
            this.tbSeek.Location = new System.Drawing.Point(15, 160);
            this.tbSeek.Maximum = 1000;
            this.tbSeek.Name = "tbSeek";
            this.tbSeek.Size = new System.Drawing.Size(450, 45);
            this.tbSeek.Scroll += new System.EventHandler(this.tbSeek_Scroll);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(20, 210);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(80, 30);
            this.btnPlayPause.Text = "Пауза";
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(110, 210);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 30);
            this.btnStop.Text = "Стоп";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(210, 210);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(100, 45);
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // VideoPlayerForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.tbSeek);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VideoPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Плеер";
            this.Load += new System.EventHandler(this.VideoPlayerForm_Load);
            this.videoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}