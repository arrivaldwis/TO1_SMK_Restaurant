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
        smk_restaurantEntities data = new smk_restaurantEntities();
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
            var priv = data.Roles.Where(x => x.roleId.Equals(roleId)).First();

            string[] privValue = priv.privileges.Substring(1).Split(',');
            string[] devPrivValue = priv.defaultPrivileges.Substring(1).Split(',');
            var btn = this.Controls.OfType<Button>();

            for (int i = 1; i < privValue.Length; i++)
            {
                if (privValue[i].Equals("1"))
                {
                    //MessageBox.Show(buttons[i].Text);
                    Button myButton = (Button)this.Controls.Find("button"+i.ToString(), true)[0];
                    myButton.Visible = true;
                }
            }
        }
    }
}
