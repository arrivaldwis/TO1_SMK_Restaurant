using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO1_SMK_Restaurant.Class;

namespace TO1_SMK_Restaurant.Dialog
{
    public partial class addEditMember : Form
    {
        smk_restaurantEntities data = new smk_restaurantEntities();
        Helper helper = new Helper();
        string memberId = "";
        int type;
        public addEditMember(int type, string memberId)
        {
            InitializeComponent();
            this.type = type;
            this.memberId = memberId;

            if (this.type == 1)
            {
                loadForm(memberId);
            }
        }

        private void loadForm(string memberId)
        {
            var member = data.Members.Find(this.memberId);
            textBox1.Text = member.firstName;
            textBox4.Text = member.lastName;
            textBox2.Text = member.phoneNumber.ToString();
            textBox3.Text = member.email;
            button2.Text = "Edit";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var a in this.Controls.OfType<TextBox>().Where(x => x.Text == "" || x.Text == string.Empty))
            {
                MessageBox.Show("Please complete the field!");
                return;
            }

            bool isValidEmail = helper.emailValidation(textBox3.Text);
            if (!isValidEmail)
            {
                MessageBox.Show("Email not valid!");
                return;
            }

            int increment = 1;
            int count = data.Members.Where(x => x.memberId.Contains(textBox1.Text.Substring(0, 1).ToUpper() + textBox4.Text.Substring(textBox4.Text.Length - 1).ToUpper())).Count();
            if (count > 0)
            {
                increment = count + 1;
            }

            int phoneLength = textBox2.Text.Length;
            if (phoneLength < 10 || phoneLength > 12)
            {
                MessageBox.Show("Phone length should be 10 - 12 digit");
                return;
            }

            if (this.type == 0)
            {
                Member em = new Member();
                em.memberId = textBox1.Text.Substring(0, 1).ToUpper() + textBox4.Text.Substring(textBox4.Text.Length - 1).ToUpper() + increment.ToString().PadLeft(4, '0');
                em.firstName = textBox1.Text;
                em.lastName = textBox4.Text;
                em.phoneNumber = textBox2.Text;
                em.email = textBox3.Text;

                try
                {
                    data.Members.Add(em);
                    data.SaveChanges();
                    MessageBox.Show("Member has been added");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Member em = data.Members.Find(this.memberId);
                em.firstName = textBox1.Text;
                em.lastName = textBox4.Text;
                em.phoneNumber = textBox2.Text;
                em.email = textBox3.Text;

                try
                {
                    data.SaveChanges();
                    MessageBox.Show("Member has been updated");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = helper.onlyNumberTextField(textBox2);
            if (!isNumber)
            {
                textBox2.Text = "";
                MessageBox.Show("Only number!");
            }
        }
    }
}
