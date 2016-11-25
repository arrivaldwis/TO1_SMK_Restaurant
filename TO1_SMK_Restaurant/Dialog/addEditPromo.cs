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
    public partial class addEditPromo : Form
    {
        smk_restaurantEntities data = new smk_restaurantEntities();
        Helper helper = new Helper();
        int promoId = 0;
        int type;
        public addEditPromo(int type, int promoId)
        {
            InitializeComponent();
            this.type = type;
            this.promoId = promoId;

            if (this.type == 1)
            {
                loadForm(promoId);
            }
            else
            {
                loadForm();
            }
        }

        private void loadForm()
        {
            var role = data.Banks;
            foreach (var r in role)
            {
                comboBox1.Items.Add(r.bankName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void loadForm(int promoId)
        {
            var promo = data.Promoes.Find(promoId);
            textBox1.Text = promo.promoName;
            dateTimePicker1.Value = promo.startDate;
            dateTimePicker2.Value = promo.endDate;
            textBox3.Text = promo.minPayment.ToString();
            textBox4.Text = promo.discountPercent.ToString();

            var role = data.Banks;
            foreach (var r in role)
            {
                comboBox1.Items.Add(r.bankName);
            }

            comboBox1.Text = promo.Bank.bankName;
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            button2.Text = "Edit";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var a in this.Controls.OfType<TextBox>().Where(x => x.Text == "" || x.Text == string.Empty))
            {
                MessageBox.Show("Please complete the field!");
                return;
            }

            float startDate = dateTimePicker1.Value.Ticks;
            float endDate = dateTimePicker2.Value.Ticks;

            if (this.type == 0)
            {
                if (startDate < DateTime.Now.Ticks)
                {
                    MessageBox.Show("Start Date can't less than now");
                    return;
                }
            }

            if (endDate < startDate)
            {
                MessageBox.Show("End date can't less than start date");
                return;
            }

            if (this.type == 0)
            {
                Promo em = new Promo();
                em.promoName = textBox1.Text;
                em.startDate = dateTimePicker1.Value;
                em.endDate = dateTimePicker2.Value;
                em.minPayment = decimal.Parse(textBox3.Text);
                em.discountPercent = int.Parse(textBox4.Text);
                em.bankId = data.Banks.Where(x=>x.bankName.Equals(comboBox1.Text)).Select(x=>x.bankId).First();

                try
                {
                    data.Promoes.Add(em);
                    data.SaveChanges();
                    MessageBox.Show("Promo has been added");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Promo em = data.Promoes.Find(this.promoId);
                em.endDate = dateTimePicker2.Value;

                try
                {
                    data.SaveChanges();
                    MessageBox.Show("Promo has been updated");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = helper.onlyNumberTextField(textBox3);
            if (!isNumber)
            {
                textBox3.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = helper.onlyNumberTextField(textBox4);
            if (!isNumber)
            {
                textBox4.Text = "";
                MessageBox.Show("Only number!");
            }
        }
    }
}
