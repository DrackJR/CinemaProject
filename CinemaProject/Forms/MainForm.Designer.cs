using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbGenreFilter;
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.FlowLayoutPanel flpMovieCatalog;
        private System.Windows.Forms.ListBox lbRecommendations;
        private System.Windows.Forms.Label lblRecTitle;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbGenreFilter = new System.Windows.Forms.ComboBox();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.flpMovieCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.lbRecommendations = new System.Windows.Forms.ListBox();
            this.lblRecTitle = new System.Windows.Forms.Label();
            this.btnOpenHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(20, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbGenreFilter
            // 
            this.cmbGenreFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.cmbGenreFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenreFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGenreFilter.ForeColor = System.Drawing.Color.White;
            this.cmbGenreFilter.Location = new System.Drawing.Point(240, 25);
            this.cmbGenreFilter.Name = "cmbGenreFilter";
            this.cmbGenreFilter.Size = new System.Drawing.Size(130, 29);
            this.cmbGenreFilter.TabIndex = 1;
            this.cmbGenreFilter.SelectedIndexChanged += new System.EventHandler(this.cmbGenreFilter_SelectedIndexChanged);
            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnAdminPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminPanel.FlatAppearance.BorderSize = 0;
            this.btnAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminPanel.ForeColor = System.Drawing.Color.White;
            this.btnAdminPanel.Location = new System.Drawing.Point(390, 24);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(180, 30);
            this.btnAdminPanel.TabIndex = 2;
            this.btnAdminPanel.Text = "Добавить фильм";
            this.btnAdminPanel.UseVisualStyleBackColor = false;
            this.btnAdminPanel.Visible = false;
            this.btnAdminPanel.Click += new System.EventHandler(this.btnAdminPanel_Click);
            // 
            // flpMovieCatalog
            // 
            this.flpMovieCatalog.AutoScroll = true;
            this.flpMovieCatalog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.flpMovieCatalog.Location = new System.Drawing.Point(20, 70);
            this.flpMovieCatalog.Name = "flpMovieCatalog";
            this.flpMovieCatalog.Size = new System.Drawing.Size(550, 450);
            this.flpMovieCatalog.TabIndex = 3;
            // 
            // lbRecommendations
            // 
            this.lbRecommendations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(50)))));
            this.lbRecommendations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRecommendations.ForeColor = System.Drawing.Color.White;
            this.lbRecommendations.ItemHeight = 21;
            this.lbRecommendations.Location = new System.Drawing.Point(590, 91);
            this.lbRecommendations.Name = "lbRecommendations";
            this.lbRecommendations.Size = new System.Drawing.Size(260, 422);
            this.lbRecommendations.TabIndex = 5;
            // 
            // lblRecTitle
            // 
            this.lblRecTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(180)))));
            this.lblRecTitle.Location = new System.Drawing.Point(586, 57);
            this.lblRecTitle.Name = "lblRecTitle";
            this.lblRecTitle.Size = new System.Drawing.Size(150, 31);
            this.lblRecTitle.TabIndex = 4;
            this.lblRecTitle.Text = "Рекомендации:";
            // 
            // btnOpenHistory
            // 
            this.btnOpenHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.btnOpenHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenHistory.FlatAppearance.BorderSize = 0;
            this.btnOpenHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenHistory.ForeColor = System.Drawing.Color.White;
            this.btnOpenHistory.Location = new System.Drawing.Point(590, 24);
            this.btnOpenHistory.Name = "btnOpenHistory";
            this.btnOpenHistory.Size = new System.Drawing.Size(260, 30);
            this.btnOpenHistory.TabIndex = 6;
            this.btnOpenHistory.Text = "История просмотров";
            this.btnOpenHistory.UseVisualStyleBackColor = false;
            this.btnOpenHistory.Click += new System.EventHandler(this.btnOpenHistory_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(874, 541);
            this.Controls.Add(this.btnOpenHistory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbGenreFilter);
            this.Controls.Add(this.btnAdminPanel);
            this.Controls.Add(this.flpMovieCatalog);
            this.Controls.Add(this.lblRecTitle);
            this.Controls.Add(this.lbRecommendations);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Онлайн-кинотеатр";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnOpenHistory;
    }
}