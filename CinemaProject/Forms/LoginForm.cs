using CinemaProject.Managers; 
using CinemaProject.Models;
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserManager userManager_ = new UserManager();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = userManager_.Authenticate(txtLogin.Text, txtPassword.Text);
            if (user != null)
            {
                this.Hide();
                using (MainForm mainForm = new MainForm(user))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            using (RegisterForm regForm = new RegisterForm())
            {
                regForm.ShowDialog();
            }
        }
    }
}