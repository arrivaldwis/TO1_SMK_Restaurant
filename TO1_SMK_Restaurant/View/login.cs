using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO1_SMK_Restaurant.Class;

namespace TO1_SMK_Restaurant.View
{
    public partial class login : baseView
    {
        public login()
        {
            InitializeComponent();
        }

        private void loginProcess() {
            foreach (Control c in this.Controls.OfType<TextBox>().Where(x=>x.Text.ToString() == "" || x.Text.ToString() == string.Empty))
            {
                MessageBox.Show("Please fill the form");
                return;
            }

            bool validEmail = helper.emailValidation(textBox1.Text);
            if (validEmail)
            {
                var isLogin = data.Employees.Where(
                    x => x.email.Equals(textBox1.Text) &&
                        x.password.Equals(textBox2.Text));

                if (isLogin.Count() > 0)
                {
                    mainMenu mainView = new mainMenu(isLogin.Select(x=>x.roleId).First());
                    parent.view(mainView, new string[] { });
                }
                else
                {
                    MessageBox.Show("Email or Password wrong!");
                }
            }
            else
            {
                MessageBox.Show("Email not valid!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginProcess();
        }
    }
}
