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
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(20, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbGenreFilter
            // 
            this.cmbGenreFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenreFilter.Location = new System.Drawing.Point(240, 25);
            this.cmbGenreFilter.Name = "cmbGenreFilter";
            this.cmbGenreFilter.Size = new System.Drawing.Size(130, 21);
            this.cmbGenreFilter.SelectedIndexChanged += new System.EventHandler(this.cmbGenreFilter_SelectedIndexChanged);
            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.Location = new System.Drawing.Point(390, 23);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(130, 25);
            this.btnAdminPanel.Text = "Добавить фильм";
            this.btnAdminPanel.Visible = false;
            this.btnAdminPanel.Click += new System.EventHandler(this.btnAdminPanel_Click);
            // 
            // flpMovieCatalog
            // 
            this.flpMovieCatalog.AutoScroll = true;
            this.flpMovieCatalog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpMovieCatalog.Location = new System.Drawing.Point(20, 70);
            this.flpMovieCatalog.Name = "flpMovieCatalog";
            this.flpMovieCatalog.Size = new System.Drawing.Size(550, 450);
            // 
            // lblRecTitle
            // 
            this.lblRecTitle.Location = new System.Drawing.Point(590, 50);
            this.lblRecTitle.Name = "lblRecTitle";
            this.lblRecTitle.Size = new System.Drawing.Size(100, 15);
            this.lblRecTitle.Text = "Рекомендации:";
            // 
            // lbRecommendations
            // 
            this.lbRecommendations.Location = new System.Drawing.Point(590, 70);
            this.lbRecommendations.Name = "lbRecommendations";
            this.lbRecommendations.Size = new System.Drawing.Size(260, 446);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(874, 541);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbGenreFilter);
            this.Controls.Add(this.btnAdminPanel);
            this.Controls.Add(this.flpMovieCatalog);
            this.Controls.Add(this.lblRecTitle);
            this.Controls.Add(this.lbRecommendations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Онлайн-кинотеатр";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}