using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TO1_SMK_Restaurant.View
{
    public partial class role : baseView
    {
        string[] privilegesData;
        public role()
        {
            InitializeComponent();
            loadRoleData();
        }

        private void loadRoleData()
        {
            var role = data.Roles.Select(
                x => new {
                    RoleName = x.roleName
                }).ToList();
            dataGridView1.DataSource = role;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string roleName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                var role = data.Roles.Where(x => x.roleName.Equals(roleName)).First();

                txtName.Text = role.roleName;
                label2.Text = role.roleId.ToString();

                var priv = data.Roles.Where(x => x.roleId.Equals(role.roleId)).FirstOrDefault();

                string[] privValue = priv.privileges.Substring(1).Split(',');
                string[] devPrivValue = priv.defaultPrivileges.Substring(1).Split(',');
                var ck = this.Controls.OfType<CheckBox>();

                for (int i = 1; i < privValue.Length; i++)
                {
                    CheckBox myCheckbox = (CheckBox)this.Controls.Find("checkBox" + i.ToString(), true)[0];

                    if (privValue[i].Equals("1"))
                    {
                        myCheckbox.Checked = true;
                    }
                    else
                    {
                        myCheckbox.Checked = false;
                    }

                    if (devPrivValue[i].Equals("1"))
                    {
                        myCheckbox.Enabled = false;
                    } 
                    else 
                    {
                        myCheckbox.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadRoleData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actionAddEdit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            actionAddEdit(1);
        }

        private void actionAddEdit(int type)
        {
            if (txtName.Text == "" || txtName.Text == string.Empty)
            {
                MessageBox.Show("Please give the role name");
                return;
            }

            string priv = "1,";
            for (int i = 1; i < 10; i++)
            {
                CheckBox myCheckbox = (CheckBox)this.Controls.Find("checkBox" + i.ToString(), true)[0];

                if (myCheckbox.Checked == true)
                {
                    if (i == 1)
                    {
                        priv += "1";
                    }
                    else
                    {
                        priv += "," + "1";
                    };
                }
                else
                {
                    if (i == 1)
                    {
                        priv += "0";
                    }
                    else
                    {
                        priv += "," + "0";
                    };
                }
            }

            if (!priv.Substring(2).Contains("1"))
            {
                MessageBox.Show("at least choose one privileges for this role");
                return;
            }

            int role = data.Roles.Where(x => x.roleName.Equals(txtName.Text)).Count();
            if (type == 0)
            {
                if (role > 0)
                {
                    MessageBox.Show("Sorry, this role already registered");
                }
                else
                {
                    Role ro = new Role();
                    ro.roleName = txtName.Text;
                    ro.privileges = priv;
                    ro.defaultPrivileges = "0,0,0,0,0,0,0,0,0,0";

                    try
                    {
                        data.Roles.Add(ro);
                        data.SaveChanges();
                        MessageBox.Show("Role has been added");
                        loadRoleData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (role > 0)
                {
                    Role ro = data.Roles.Find(int.Parse(label2.Text));
                    ro.roleName = txtName.Text;
                    ro.privileges = priv;

                    try
                    {
                        data.SaveChanges();
                        MessageBox.Show("Role has been updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This role unidentified, you can add this role");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtName.Text == string.Empty)
            {
                MessageBox.Show("Please choose the role name");
                return;
            }

            Role ro = data.Roles.Where(x => x.roleName.Equals(txtName.Text)).First();

            try
            {
                data.Roles.Remove(ro);
                data.SaveChanges();
                MessageBox.Show("Role has been removed");
                loadRoleData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            for (int i = 1; i < 10; i++)
            {
                CheckBox myCheckbox = (CheckBox)this.Controls.Find("checkBox" + i.ToString(), true)[0];
                myCheckbox.Checked = false;
                myCheckbox.Enabled = true;
            }
        }
    }
}
