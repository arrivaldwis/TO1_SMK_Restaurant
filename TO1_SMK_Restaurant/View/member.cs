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
    public partial class member : baseView
    {
        public member()
        {
            InitializeComponent();
            loadMemberData();

        }

        private void loadMemberData()
        {
            var members = data.Members.Select(x =>
                new
                {
                    MemberID = x.memberId,
                    FirstName = x.firstName,
                    LastName = x.lastName,
                    Phone = x.phoneNumber,
                    Email = x.email
                }
                ).ToList();
            dataGridView1.DataSource = members;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEditMember a = new addEditMember(0, "");
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string memberId = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                addEditMember a = new addEditMember(1, memberId);
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string memberId = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                var employee = data.Members.Find(memberId);
                data.Members.Remove(employee);
                data.SaveChanges();

                MessageBox.Show("Member data has been remove");
                loadMemberData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadMemberData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }
    }
}
