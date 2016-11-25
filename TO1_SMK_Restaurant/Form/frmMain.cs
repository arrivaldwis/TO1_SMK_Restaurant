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
using TO1_SMK_Restaurant.View;

namespace TO1_SMK_Restaurant
{
    public partial class frmMain : Form, ICallBack
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void view(baseView view, string[] data)
        {
            panel4.Controls.Clear();
            view.Dock = DockStyle.Fill;
            view.setParent(this);
            view.setData(data);
            panel4.Controls.Add(view);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            login loginView = new login();
            view(loginView, new string[] { "" });
        }
    }
}
