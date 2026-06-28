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
        private System.Windows.Forms.ComboBox cmbGenre;
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
            this.cmbGenre = new System.Windows.Forms.ComboBox();
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
            this.btnBrowsePoster = new System.Windows.Forms.Button();
            this.btnBrowse480 = new System.Windows.Forms.Button();
            this.btnBrowse720 = new System.Windows.Forms.Button();
            this.btnBrowse1080 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(129, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(251, 24);
            this.txtTitle.TabIndex = 1;
            // 
            // lblGenre
            // 
            this.lblGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblGenre.Location = new System.Drawing.Point(15, 50);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(90, 20);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Жанр:";
            // 
            // cmbGenre
            // 
            this.cmbGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGenre.ForeColor = System.Drawing.Color.White;
            this.cmbGenre.Location = new System.Drawing.Point(129, 48);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(251, 25);
            this.cmbGenre.TabIndex = 3;
            // 
            // lblRating
            // 
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblRating.Location = new System.Drawing.Point(15, 80);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(90, 20);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Рейтинг:";
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtRating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRating.ForeColor = System.Drawing.Color.White;
            this.txtRating.Location = new System.Drawing.Point(129, 78);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(251, 24);
            this.txtRating.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblDesc.Location = new System.Drawing.Point(15, 110);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(90, 20);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Описание:";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ForeColor = System.Drawing.Color.White;
            this.txtDesc.Location = new System.Drawing.Point(129, 108);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(251, 24);
            this.txtDesc.TabIndex = 7;
            // 
            // lblPoster
            // 
            this.lblPoster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblPoster.Location = new System.Drawing.Point(15, 140);
            this.lblPoster.Name = "lblPoster";
            this.lblPoster.Size = new System.Drawing.Size(90, 20);
            this.lblPoster.TabIndex = 8;
            this.lblPoster.Text = "Постер:";
            // 
            // txtPoster
            // 
            this.txtPoster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPoster.ForeColor = System.Drawing.Color.White;
            this.txtPoster.Location = new System.Drawing.Point(129, 138);
            this.txtPoster.Name = "txtPoster";
            this.txtPoster.Size = new System.Drawing.Size(150, 24);
            this.txtPoster.TabIndex = 9;
            // 
            // lblV480
            // 
            this.lblV480.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblV480.Location = new System.Drawing.Point(15, 170);
            this.lblV480.Name = "lblV480";
            this.lblV480.Size = new System.Drawing.Size(108, 29);
            this.lblV480.TabIndex = 11;
            this.lblV480.Text = "Видео 480p:";
            // 
            // txtV480
            // 
            this.txtV480.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtV480.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtV480.ForeColor = System.Drawing.Color.White;
            this.txtV480.Location = new System.Drawing.Point(129, 168);
            this.txtV480.Name = "txtV480";
            this.txtV480.Size = new System.Drawing.Size(150, 24);
            this.txtV480.TabIndex = 12;
            // 
            // lblV720
            // 
            this.lblV720.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblV720.Location = new System.Drawing.Point(15, 200);
            this.lblV720.Name = "lblV720";
            this.lblV720.Size = new System.Drawing.Size(108, 27);
            this.lblV720.TabIndex = 14;
            this.lblV720.Text = "Видео 720p:";
            // 
            // txtV720
            // 
            this.txtV720.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtV720.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtV720.ForeColor = System.Drawing.Color.White;
            this.txtV720.Location = new System.Drawing.Point(129, 198);
            this.txtV720.Name = "txtV720";
            this.txtV720.Size = new System.Drawing.Size(150, 24);
            this.txtV720.TabIndex = 15;
            // 
            // lblV1080
            // 
            this.lblV1080.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblV1080.Location = new System.Drawing.Point(15, 230);
            this.lblV1080.Name = "lblV1080";
            this.lblV1080.Size = new System.Drawing.Size(108, 27);
            this.lblV1080.TabIndex = 17;
            this.lblV1080.Text = "Видео 1080p:";
            // 
            // txtV1080
            // 
            this.txtV1080.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtV1080.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtV1080.ForeColor = System.Drawing.Color.White;
            this.txtV1080.Location = new System.Drawing.Point(129, 228);
            this.txtV1080.Name = "txtV1080";
            this.txtV1080.Size = new System.Drawing.Size(150, 24);
            this.txtV1080.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(129, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Добавить фильм";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowsePoster
            // 
            this.btnBrowsePoster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.btnBrowsePoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowsePoster.FlatAppearance.BorderSize = 0;
            this.btnBrowsePoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePoster.ForeColor = System.Drawing.Color.White;
            this.btnBrowsePoster.Location = new System.Drawing.Point(284, 138);
            this.btnBrowsePoster.Name = "btnBrowsePoster";
            this.btnBrowsePoster.Size = new System.Drawing.Size(96, 29);
            this.btnBrowsePoster.TabIndex = 10;
            this.btnBrowsePoster.Text = "Обзор...";
            this.btnBrowsePoster.UseVisualStyleBackColor = false;
            this.btnBrowsePoster.Click += new System.EventHandler(this.btnBrowsePoster_Click);
            // 
            // btnBrowse480
            // 
            this.btnBrowse480.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.btnBrowse480.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse480.FlatAppearance.BorderSize = 0;
            this.btnBrowse480.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse480.ForeColor = System.Drawing.Color.White;
            this.btnBrowse480.Location = new System.Drawing.Point(284, 168);
            this.btnBrowse480.Name = "btnBrowse480";
            this.btnBrowse480.Size = new System.Drawing.Size(96, 29);
            this.btnBrowse480.TabIndex = 13;
            this.btnBrowse480.Text = "Обзор...";
            this.btnBrowse480.UseVisualStyleBackColor = false;
            this.btnBrowse480.Click += new System.EventHandler(this.btnBrowse480_Click);
            // 
            // btnBrowse720
            // 
            this.btnBrowse720.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.btnBrowse720.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse720.FlatAppearance.BorderSize = 0;
            this.btnBrowse720.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse720.ForeColor = System.Drawing.Color.White;
            this.btnBrowse720.Location = new System.Drawing.Point(284, 198);
            this.btnBrowse720.Name = "btnBrowse720";
            this.btnBrowse720.Size = new System.Drawing.Size(96, 29);
            this.btnBrowse720.TabIndex = 16;
            this.btnBrowse720.Text = "Обзор...";
            this.btnBrowse720.UseVisualStyleBackColor = false;
            this.btnBrowse720.Click += new System.EventHandler(this.btnBrowse720_Click);
            // 
            // btnBrowse1080
            // 
            this.btnBrowse1080.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.btnBrowse1080.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse1080.FlatAppearance.BorderSize = 0;
            this.btnBrowse1080.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse1080.ForeColor = System.Drawing.Color.White;
            this.btnBrowse1080.Location = new System.Drawing.Point(284, 228);
            this.btnBrowse1080.Name = "btnBrowse1080";
            this.btnBrowse1080.Size = new System.Drawing.Size(96, 29);
            this.btnBrowse1080.TabIndex = 19;
            this.btnBrowse1080.Text = "Обзор...";
            this.btnBrowse1080.UseVisualStyleBackColor = false;
            this.btnBrowse1080.Click += new System.EventHandler(this.btnBrowse1080_Click);
            // 
            // MovieEditForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(400, 325);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblPoster);
            this.Controls.Add(this.txtPoster);
            this.Controls.Add(this.btnBrowsePoster);
            this.Controls.Add(this.lblV480);
            this.Controls.Add(this.txtV480);
            this.Controls.Add(this.btnBrowse480);
            this.Controls.Add(this.lblV720);
            this.Controls.Add(this.txtV720);
            this.Controls.Add(this.btnBrowse720);
            this.Controls.Add(this.lblV1080);
            this.Controls.Add(this.txtV1080);
            this.Controls.Add(this.btnBrowse1080);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovieEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление фильма";
            this.Load += new System.EventHandler(this.MovieEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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