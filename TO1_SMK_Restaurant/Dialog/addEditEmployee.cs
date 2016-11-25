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
    public partial class addEditEmployee : Form
    {
        smk_restaurantEntities data = new smk_restaurantEntities();
        Helper helper = new Helper();
        string employeeId = "";
        int type;
        public addEditEmployee(int type, string employeeId)
        {
            InitializeComponent();
            this.type = type;
            this.employeeId = employeeId;

            if (this.type == 1)
            {
                loadForm(this.employeeId);
            }
            else
            {
                loadForm();
            }
        }

        private void loadForm()
        {
            var role = data.Roles;
            foreach (var r in role)
            {
                comboBox1.Items.Add(r.roleName);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void loadForm(string employeeId)
        {
            var getEmployee = data.Employees.Find(this.employeeId);
            textBox1.Text = getEmployee.employeeName;
            textBox2.Text = getEmployee.phoneNumber.ToString();
            textBox3.Text = getEmployee.email;
            textBox4.Text = getEmployee.password;
            dateTimePicker1.Value = getEmployee.DOB;

            var role = data.Roles;
            foreach (var r in role)
            {
                comboBox1.Items.Add(r.roleName);
            }

            comboBox1.Text = getEmployee.Role.roleName;
            dateTimePicker1.Enabled = false;
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
            int count = data.Employees.Where(x=>x.employeeId.Contains(dateTimePicker1.Value.Year.ToString()+dateTimePicker1.Value.Month.ToString())).Count();
            if(count > 0) {
                increment = count+1;
            }

            int phoneLength = textBox2.Text.Length;
            if (phoneLength < 10 || phoneLength > 12)
            {
                MessageBox.Show("Phone length should be 10 - 12 digit");
                return;
            }

            int calcs = DateTime.Now.Year - DateTime.Parse(dateTimePicker1.Value.ToString()).Year;
            if (DateTime.Today < dateTimePicker1.Value.AddYears(calcs)) calcs--;

            if (calcs < 22 || calcs > 40)
            {
                MessageBox.Show("Employee age should be 22 - 40 years old");
                return;
            }

            if (this.type == 0)
            {
                Employee em = new Employee();
                em.employeeId = dateTimePicker1.Value.Year.ToString() + dateTimePicker1.Value.Month.ToString() + increment.ToString().PadLeft(5, '0');
                em.employeeName = textBox1.Text;
                em.roleId = data.Roles.Where(x => x.roleName.Equals(comboBox1.Text)).Select(x => x.roleId).First();
                em.DOB = dateTimePicker1.Value;
                em.phoneNumber = textBox2.Text;
                em.email = textBox3.Text;
                em.password = textBox4.Text;

                try
                {
                    data.Employees.Add(em);
                    data.SaveChanges();
                    MessageBox.Show("Employee has been added");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Employee em = data.Employees.Find(this.employeeId);
                em.employeeName = textBox1.Text;
                em.roleId = data.Roles.Where(x => x.roleName.Equals(comboBox1.Text)).Select(x => x.roleId).First();
                em.phoneNumber = textBox2.Text;
                em.email = textBox3.Text;
                em.password = textBox4.Text;

                try
                {
                    data.SaveChanges();
                    MessageBox.Show("Employee has been updated");
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
