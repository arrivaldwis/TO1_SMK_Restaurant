using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO1_SMK_Restaurant.Dialog;

namespace TO1_SMK_Restaurant.View
{
    public partial class employee : baseView
    {
        public employee()
        {
            InitializeComponent();
            loadEmployeesData();
        }

        private void loadEmployeesData()
        {
            var employee = data.Employees.Select( x=>
                new
                {
                    EmployeeID = x.employeeId,
                    Name = x.employeeName,
                    Role = x.Role.roleName,
                    DateOfBirth = x.DOB,
                    Phone = x.phoneNumber,
                    Email = x.email
                }
                ).ToList();
            dataGridView1.DataSource = employee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEditEmployee a = new addEditEmployee(0, "");
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string employeeid = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                addEditEmployee a = new addEditEmployee(1, employeeid);
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try{
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string employeeid = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                var employee = data.Employees.Where(x => x.employeeId.Equals(employeeid)).First();
                data.Employees.Remove(employee);
                data.SaveChanges();

                MessageBox.Show("Employee data has been remove");
                loadEmployeesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadEmployeesData();
        }
    }
}
