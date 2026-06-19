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
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(15, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(110, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(150, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblGenre
            // 
            this.lblGenre.Location = new System.Drawing.Point(15, 60);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(80, 20);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Жанр:";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(110, 60);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(150, 20);
            this.txtGenre.TabIndex = 3;
            // 
            // lblRating
            // 
            this.lblRating.Location = new System.Drawing.Point(15, 100);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(80, 20);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Рейтинг:";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(110, 100);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(150, 20);
            this.txtRating.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(85, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Добавить фильм";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MovieEditForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MovieEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление фильма";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}