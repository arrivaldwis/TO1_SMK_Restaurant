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
    public partial class mainMenu : baseView
    {
        private List<Button> buttons = new List<Button>();
        int roleId;

        public mainMenu(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            buttons = this.Controls.OfType<Button>().ToList();
            checkPrivileges();
        }

        private void checkPrivileges()
        {
            var priv = data.Roles.Where(x => x.roleId.Equals(roleId)).FirstOrDefault();

            string[] privValue = priv.privileges.Substring(1).Split(',');
            string[] devPrivValue = priv.defaultPrivileges.Substring(1).Split(',');
            var btn = this.Controls.OfType<Button>();

            for (int i = 1; i < privValue.Length; i++)
            {
                if (privValue[i].Equals("1"))
                {
                    Button myButton = (Button)this.Controls.Find("button"+i.ToString(), true)[0];
                    myButton.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employee views = new employee();
            parent.view(views, new string[] { this.roleId.ToString() });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            member views = new member();
            parent.view(views, new string[] { this.roleId.ToString() });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            promo views = new promo();
            parent.view(views, new string[] { this.roleId.ToString() });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            role views = new role();
            parent.view(views, new string[] { this.roleId.ToString() });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            login views = new login();
            parent.view(views, new string[] { this.roleId.ToString() });
        }
    }
}
