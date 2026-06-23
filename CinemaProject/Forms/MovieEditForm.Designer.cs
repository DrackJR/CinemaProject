using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MovieEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnSave;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblPoster = new System.Windows.Forms.Label();
            this.txtPoster = new System.Windows.Forms.TextBox();
            this.lblV480 = new System.Windows.Forms.Label();
            this.txtV480 = new System.Windows.Forms.TextBox();
            this.lblV720 = new System.Windows.Forms.Label();
            this.txtV720 = new System.Windows.Forms.TextBox();
            this.lblV1080 = new System.Windows.Forms.Label();
            this.txtV1080 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();

            // Кнопки Обзора (Windows Dialog)
            this.btnBrowsePoster = new System.Windows.Forms.Button();
            this.btnBrowse480 = new System.Windows.Forms.Button();
            this.btnBrowse720 = new System.Windows.Forms.Button();
            this.btnBrowse1080 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Название, Жанр, Рейтинг, Описание
            this.lblTitle.Location = new System.Drawing.Point(15, 20); this.lblTitle.Size = new System.Drawing.Size(90, 20); this.lblTitle.Text = "Название:";
            this.txtTitle.Location = new System.Drawing.Point(110, 20); this.txtTitle.Size = new System.Drawing.Size(230, 20);

            this.lblGenre.Location = new System.Drawing.Point(15, 50); this.lblGenre.Size = new System.Drawing.Size(90, 20); this.lblGenre.Text = "Жанр:";
            this.txtGenre.Location = new System.Drawing.Point(110, 50); this.txtGenre.Size = new System.Drawing.Size(230, 20);

            this.lblRating.Location = new System.Drawing.Point(15, 80); this.lblRating.Size = new System.Drawing.Size(90, 20); this.lblRating.Text = "Рейтинг:";
            this.txtRating.Location = new System.Drawing.Point(110, 80); this.txtRating.Size = new System.Drawing.Size(230, 20);

            this.lblDesc.Location = new System.Drawing.Point(15, 110); this.lblDesc.Size = new System.Drawing.Size(90, 20); this.lblDesc.Text = "Описание:";
            this.txtDesc.Location = new System.Drawing.Point(110, 110); this.txtDesc.Size = new System.Drawing.Size(230, 20);

            // Постер + Кнопка Обзор
            this.lblPoster.Location = new System.Drawing.Point(15, 140); this.lblPoster.Size = new System.Drawing.Size(90, 20); this.lblPoster.Text = "Постер:";
            this.txtPoster.Location = new System.Drawing.Point(110, 140); this.txtPoster.Size = new System.Drawing.Size(150, 20);
            this.btnBrowsePoster.Location = new System.Drawing.Point(265, 138); this.btnBrowsePoster.Size = new System.Drawing.Size(75, 23); this.btnBrowsePoster.Text = "Обзор...";
            this.btnBrowsePoster.Click += new System.EventHandler(this.btnBrowsePoster_Click);

            // Видео 480p + Кнопка Обзор
            this.lblV480.Location = new System.Drawing.Point(15, 170); this.lblV480.Size = new System.Drawing.Size(90, 20); this.lblV480.Text = "Видео 480p:";
            this.txtV480.Location = new System.Drawing.Point(110, 170); this.txtV480.Size = new System.Drawing.Size(150, 20);
            this.btnBrowse480.Location = new System.Drawing.Point(265, 168); this.btnBrowse480.Size = new System.Drawing.Size(75, 23); this.btnBrowse480.Text = "Обзор...";
            this.btnBrowse480.Click += new System.EventHandler(this.btnBrowse480_Click);

            // Видео 720p + Кнопка Обзор
            this.lblV720.Location = new System.Drawing.Point(15, 200); this.lblV720.Size = new System.Drawing.Size(90, 20); this.lblV720.Text = "Видео 720p:";
            this.txtV720.Location = new System.Drawing.Point(110, 200); this.txtV720.Size = new System.Drawing.Size(150, 20);
            this.btnBrowse720.Location = new System.Drawing.Point(265, 198); this.btnBrowse720.Size = new System.Drawing.Size(75, 23); this.btnBrowse720.Text = "Обзор...";
            this.btnBrowse720.Click += new System.EventHandler(this.btnBrowse720_Click);

            // Видео 1080p + Кнопка Обзор
            this.lblV1080.Location = new System.Drawing.Point(15, 230); this.lblV1080.Size = new System.Drawing.Size(90, 20); this.lblV1080.Text = "Видео 1080p:";
            this.txtV1080.Location = new System.Drawing.Point(110, 230); this.txtV1080.Size = new System.Drawing.Size(150, 20);
            this.btnBrowse1080.Location = new System.Drawing.Point(265, 228); this.btnBrowse1080.Size = new System.Drawing.Size(75, 23); this.btnBrowse1080.Text = "Обзор...";
            this.btnBrowse1080.Click += new System.EventHandler(this.btnBrowse1080_Click);

            // Кнопка Сохранить
            this.btnSave.Location = new System.Drawing.Point(110, 275);
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.Text = "Добавить фильм";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Настройка самой формы MovieEditForm
            this.ClientSize = new System.Drawing.Size(360, 325);
            this.Controls.Add(this.lblTitle); this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblGenre); this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblRating); this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblDesc); this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblPoster); this.Controls.Add(this.txtPoster); this.Controls.Add(this.btnBrowsePoster);
            this.Controls.Add(this.lblV480); this.Controls.Add(this.txtV480); this.Controls.Add(this.btnBrowse480);
            this.Controls.Add(this.lblV720); this.Controls.Add(this.txtV720); this.Controls.Add(this.btnBrowse720);
            this.Controls.Add(this.lblV1080); this.Controls.Add(this.txtV1080); this.Controls.Add(this.btnBrowse1080);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MovieEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление фильма";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Объявление полей внизу Designer.cs:
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblPoster;
        private System.Windows.Forms.TextBox txtPoster;
        private System.Windows.Forms.Button btnBrowsePoster;
        private System.Windows.Forms.Label lblV480;
        private System.Windows.Forms.TextBox txtV480;
        private System.Windows.Forms.Button btnBrowse480;
        private System.Windows.Forms.Label lblV720;
        private System.Windows.Forms.TextBox txtV720;
        private System.Windows.Forms.Button btnBrowse720;
        private System.Windows.Forms.Label lblV1080;
        private System.Windows.Forms.TextBox txtV1080;
        private System.Windows.Forms.Button btnBrowse1080;

    }
}