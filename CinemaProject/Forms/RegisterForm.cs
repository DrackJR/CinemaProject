using CinemaProject.Managers; 
using System;
using System.Windows.Forms;

namespace CinemaProject.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserManager userManager_ = new UserManager();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            bool success = userManager_.Register(txtLogin.Text, txtPassword.Text);
            if (success)
            {
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}