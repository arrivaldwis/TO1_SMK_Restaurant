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
        public smk_restaurantEntities data = new smk_restaurantEntities();
        public ICallBack parent;
        public Helper helper = new Helper();
        public string[] par;

        public void setParent(ICallBack parent)
        {
            this.parent = parent;
        }

        public void setData(string[] par)
        {
            this.par = par;
        }

        public baseView()
        {
            InitializeComponent();
        }
    }
}
