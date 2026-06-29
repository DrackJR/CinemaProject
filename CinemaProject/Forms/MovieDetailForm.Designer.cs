namespace CinemaProject
{
    partial class MovieDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpQuality = new System.Windows.Forms.GroupBox();
            this.rb1080 = new System.Windows.Forms.RadioButton();
            this.rb720 = new System.Windows.Forms.RadioButton();
            this.rb480 = new System.Windows.Forms.RadioButton();
            this.btnPlay = new System.Windows.Forms.Button();
            this.grpQuality.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название фильма";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRating.ForeColor = System.Drawing.Color.Gold;
            this.lblRating.Location = new System.Drawing.Point(21, 60);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(107, 21);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Рейтинг: 0.0";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDescription.ForeColor = System.Drawing.Color.LightGray;
            this.txtDescription.Location = new System.Drawing.Point(25, 100);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(435, 120);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Описание фильма...";
            // 
            // grpQuality
            // 
            this.grpQuality.Controls.Add(this.rb1080);
            this.grpQuality.Controls.Add(this.rb720);
            this.grpQuality.Controls.Add(this.rb480);
            this.grpQuality.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpQuality.ForeColor = System.Drawing.Color.White;
            this.grpQuality.Location = new System.Drawing.Point(25, 240);
            this.grpQuality.Name = "grpQuality";
            this.grpQuality.Size = new System.Drawing.Size(435, 75);
            this.grpQuality.TabIndex = 3;
            this.grpQuality.TabStop = false;
            this.grpQuality.Text = " Выберите качество видео ";
            // 
            // rb1080
            // 
            this.rb1080.AutoSize = true;
            this.rb1080.Location = new System.Drawing.Point(310, 32);
            this.rb1080.Name = "rb1080";
            this.rb1080.Size = new System.Drawing.Size(64, 23);
            this.rb1080.TabIndex = 2;
            this.rb1080.Text = "1080p";
            this.rb1080.UseVisualStyleBackColor = true;
            // 
            // rb720
            // 
            this.rb720.AutoSize = true;
            this.rb720.Checked = true;
            this.rb720.Location = new System.Drawing.Point(170, 32);
            this.rb720.Name = "rb720";
            this.rb720.Size = new System.Drawing.Size(56, 23);
            this.rb720.TabIndex = 1;
            this.rb720.TabStop = true;
            this.rb720.Text = "720p";
            this.rb720.UseVisualStyleBackColor = true;
            // 
            // rb480
            // 
            this.rb480.AutoSize = true;
            this.rb480.Location = new System.Drawing.Point(30, 32);
            this.rb480.Name = "rb480";
            this.rb480.Size = new System.Drawing.Size(56, 23);
            this.rb480.TabIndex = 0;
            this.rb480.Text = "480p";
            this.rb480.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))));
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(25, 340);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(435, 45);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Смотреть фильм";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // MovieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.grpQuality);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovieDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Детали фильма";
            this.grpQuality.ResumeLayout(false);
            this.grpQuality.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpQuality;
        private System.Windows.Forms.RadioButton rb1080;
        private System.Windows.Forms.RadioButton rb720;
        private System.Windows.Forms.RadioButton rb480;
        private System.Windows.Forms.Button btnPlay;
    }
}