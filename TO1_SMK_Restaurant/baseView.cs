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

namespace TO1_SMK_Restaurant
{
    public partial class baseView : UserControl
    {
        public ICallBack parent;

        public void setParent(ICallBack parent)
        {
            this.parent = parent;
        }

        public baseView()
        {
            InitializeComponent();
        }
    }
}
