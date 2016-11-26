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
    public partial class payment : baseView
    {
        bool isMember = false;
        bool isPromo = false;
        bool isCreditCard = false;
        int promoId = 0;

        public payment()
        {
            InitializeComponent();
            loadListView();
            loadOrderStatusData();
            loadBank();
        }

        private void loadListView()
        {
            listView3.Columns.Add("Id");
            listView3.Columns.Add("Table");

            listView4.Columns.Add("Id");
            listView4.Columns.Add("Menu Name");
            listView4.Columns.Add("Qty");
            listView4.Columns.Add("Status");
            listView4.Columns.Add("Price");
            listView4.Columns.Add("Sub Total");
        }

        private void loadBank()
        {
            var bank = data.Banks;
            foreach (var a in bank)
            {
                comboBox1.Items.Add(a.bankName);
            }
        }

        private void loadOrderStatusData()
        {
            listView3.Items.Clear();
            var order = data.Orders.Where(x=>!x.status.Equals("done")).Select(
                x => new
                {
                    Id = x.orderId,
                    TableNo = x.Table.tableNo,
                    Status = x.status
                }).ToList();

            foreach (var a in order)
            {
                ListViewItem lv = new ListViewItem(a.Id.ToString());
                lv.SubItems.Add(a.TableNo);
                lv.BackColor = Color.Gold;
                lv.ForeColor = Color.White;

                listView3.Items.Add(lv);
            }
            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void getTotalPrice()
        {
            double total = 0;
            if (listView4.Items.Count > 0)
            {
                for (int i = 0; i < listView4.Items.Count; i++)
                {
                    ListViewItem item = listView4.Items[i];
                    total += double.Parse(item.SubItems[5].Text);
                }
            }

            label10.Text = total + "";
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                var selectedItems = listView3.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    orderId = selectedItem.SubItems[0].Text;
                    int orderIds = int.Parse(selectedItem.SubItems[0].Text);
                    var orderDetails = data.OrderDetails.Where(
                        x => x.orderId.Equals(orderIds) && x.status.Equals("delivered")
                        ).Select(x => new
                        {
                            Id = x.orderDetailsId,
                            Menu = x.Menu.menuName,
                            Qty = x.qty,
                            Status = x.status,
                            Price = x.price,
                            SubTotal = x.subTotal
                        }).ToList();

                    foreach (var a in orderDetails)
                    {
                        ListViewItem lv = new ListViewItem(a.Id.ToString());
                        lv.SubItems.Add(a.Menu);
                        lv.SubItems.Add(a.Qty.ToString());
                        lv.SubItems.Add(a.Status);
                        lv.SubItems.Add(a.Price.ToString());
                        lv.SubItems.Add(a.SubTotal.ToString());
                        lv.BackColor = Color.Green;
                        lv.ForeColor = Color.White;
                        listView4.Items.Add(lv);
                    }

                    listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }

                getTotalPrice();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (orderId == null)
            {
                MessageBox.Show("Pleaes choose the order food details first");
                return;
            }

            checkMember();
        }

        private void checkMember()
        {
            var member = data.Members.Find(textBox1.Text);
            if (member != null)
            {
                double dis = 0.1 * double.Parse(label10.Text.ToString());
                label5.Visible = true;
                label12.Text = dis+"";
                isMember = true;
            }
            else
            {
                MessageBox.Show("Sorry, member id not found");
                label5.Visible = false;
                label12.Text = "0";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = helper.onlyNumberTextField(textBox2);
            if (!isNumber)
            {
                textBox2.Text = "";
                MessageBox.Show("Only number!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (orderId.Equals("") || orderId.Equals(string.Empty))
            {
                MessageBox.Show("Pleaes choose the order food details first");
                return;
            }

            checkPromo();
        }

        private void checkPromo()
        {
            if (textBox3.Text.Equals("") || textBox3.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please insert your credit card number");
                return;
            }

            decimal total = decimal.Parse(label10.Text);
            var promo = data.Promoes.Where(
                x => x.Bank.bankName.Equals(comboBox1.Text) &&
                     total >= x.minPayment &&       
                     DateTime.Now >= x.startDate && 
                     DateTime.Now <= x.endDate).FirstOrDefault();
            if (promo != null)
            {
                isPromo = true;
                promoId = promo.promoId;
                decimal dis = (decimal.Parse(promo.discountPercent.ToString()) / 100) * decimal.Parse(label10.Text.ToString());
                label14.Text = dis + "";
                label6.Text = "Congrats! you got " + promo.discountPercent + "% discount";
                label6.ForeColor = Color.Green;
                label6.Visible = true;
            }
            else
            {
                label6.Text = "You choose credit card. Sorry no promo today";
                label6.ForeColor = Color.Black;
                label6.Visible = true;
                label14.Text = "0";
            }

            isCreditCard = true;
            textBox2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (orderId.Equals("") || orderId.Equals(string.Empty))
            {
                MessageBox.Show("Please choose the order food details first");
                return;
            }

            if (!isCreditCard) {
                if (textBox2.Text.Equals("") || textBox2.Text.Equals(string.Empty))
                {
                    tabControl2.SelectTab(1);
                    MessageBox.Show("Please input amount of money");
                    return;
                }
            }

            decimal totalPrice = decimal.Parse(label10.Text) - (decimal.Parse(label12.Text) + decimal.Parse(label14.Text));

            if (!isCreditCard)
            {
                if (decimal.Parse(textBox2.Text) < totalPrice)
                {
                    MessageBox.Show("Amount should be bigger or equals total price");
                    return;
                }
            }

            int bank = data.Banks.Where(x => x.bankName.Equals(comboBox1.Text)).Select(x => x.bankId).Count();
            Payment pay = new Payment();
            pay.orderId = int.Parse(orderId);
            pay.amount = isCreditCard ? totalPrice : decimal.Parse(textBox2.Text);
            if (bank > 0)
            {
                pay.bankId = data.Banks.Where(x => x.bankName.Equals(comboBox1.Text)).Select(x => x.bankId).First();
            }
            pay.creditCardNumber = isCreditCard ? textBox3.Text : null;
            pay.memberId = isMember ? textBox1.Text : null;
            pay.payMethod = isCreditCard ? "credit" : "cash";
            pay.createdAt = DateTime.Now;

            if (isPromo)
            {
                pay.promoId = promoId;
            }

            try
            {
                data.Payments.Add(pay);

                Order order = data.Orders.Find(int.Parse(orderId));
                order.status = "done";
                Table tbl = data.Tables.Find(order.tableId);
                tbl.status = "available";

                data.SaveChanges();
                MessageBox.Show("Payment successfully..");

                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clear()
        {
            listView4.Items.Clear();
            loadOrderStatusData();
            label10.Text = "";
            label12.Text = "";
            label14.Text = "";
            textBox2.Text = "";
            textBox2.Enabled = true;
            textBox1.Text = "";
            textBox3.Text = "";
            label5.Visible = false;
            label6.Visible = false;
            orderId = "";
            isCreditCard = false;
            isMember = false;
            isPromo = false;
            promoId = 0;
        }

        string orderId = "";
        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
