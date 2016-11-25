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
    public partial class promo : baseView
    {
        public promo()
        {
            InitializeComponent();
            loadPromoData();
        }

        private void loadPromoData()
        {
            var members = data.Promoes.Select(x =>
                new
                {
                    PromoName = x.promoName,
                    StartDate = x.startDate,
                    EndDate = x.endDate,
                    MinPayment = x.minPayment,
                    Percent = x.discountPercent,
                    BankName = x.Bank.bankName
                }
                ).ToList();
            dataGridView1.DataSource = members;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadPromoData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEditPromo a = new addEditPromo(0, 0);
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string promoName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                var promo = data.Promoes.Where(x=>x.promoName.Equals(promoName)).First();

                if (promo.endDate.Ticks < DateTime.Now.Ticks)
                {
                    MessageBox.Show("Sorry, can't update past promo");
                    return;
                }

                addEditPromo a = new addEditPromo(1, promo.promoId);
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
                string promoName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                var promo = data.Promoes.Where(x => x.promoName.Equals(promoName)).First();
                data.Promoes.Remove(promo);
                data.SaveChanges();

                MessageBox.Show("Promo data has been remove");
                loadPromoData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }
    }
}
