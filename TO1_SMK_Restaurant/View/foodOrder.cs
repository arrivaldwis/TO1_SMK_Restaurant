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
    public partial class foodOrder : baseView
    {
        public foodOrder()
        {
            InitializeComponent();
            loadListView();
            loadOrderData();
            loadMenuList();
            loadOrderStatusData();
        }

        private void loadListView()
        {
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Price");

            listView2.Columns.Add("Id");
            listView2.Columns.Add("Name");
            listView2.Columns.Add("Qty");
            listView2.Columns.Add("Price");

            listView3.Columns.Add("Id");
            listView3.Columns.Add("Table");

            listView4.Columns.Add("Id");
            listView4.Columns.Add("Menu Name");
            listView4.Columns.Add("Qty");
            listView4.Columns.Add("Status");
        }

        private void loadOrderStatusData()
        {
            listView3.Items.Clear();
            var order = data.Orders.Select(
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

                if (a.Status.Equals("done"))
                {
                    lv.BackColor = Color.Green;
                }
                else
                {
                    lv.BackColor = Color.Gold;
                }

                lv.ForeColor = Color.White;

                listView3.Items.Add(lv);
            }
            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void loadMenuList()
        {
            var menu = data.Menus.Select(
                x => new
                {
                    Id = x.menuId,
                    Name = x.menuName,
                    Price = x.price,
                    Date = x.startDate
                }).Distinct().OrderByDescending(x => x.Date).ToList();

            foreach (var a in menu)
            {
                ListViewItem lv = new ListViewItem(a.Id.ToString());
                lv.SubItems.Add(a.Name);
                lv.SubItems.Add(a.Price.ToString());
                listView1.Items.Add(lv);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void loadOrderData() {
            var table = data.Tables.Select(x=>new {
                TableNo = x.tableNo,
                Status = x.status
            }).ToList();
            
            foreach(var a in table) {
                Button btn = new Button();
                btn.Width = 50;
                btn.Height = 50;
                btn.Text = a.TableNo;
                btn.Name = a.TableNo;
                btn.Tag = a.TableNo;
                btn.Click += btn_Click;
                
                if (a.Status.Equals("booked"))
                {
                    btn.Enabled = false;
                }

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Control a = (Button)sender;
            textBox1.Text = a.Tag.ToString();
            tabControl1.SelectTab(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            loadOrderData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var menu = data.Menus.Where(x=>x.menuName.Contains(textBox2.Text)).Select(
                x => new
                {
                    Id = x.menuId,
                    Name = x.menuName,
                    Price = x.price,
                    Date = x.startDate
                }).Distinct().OrderByDescending(x => x.Date).ToList();

            foreach (var a in menu)
            {
                ListViewItem lv = new ListViewItem(a.Id.ToString());
                lv.SubItems.Add(a.Name);
                lv.SubItems.Add(a.Price.ToString());
                listView1.Items.Add(lv);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void getTotalIngredientsPrice()
        {
            decimal total = 0;
            if (listView2.Items.Count > 0)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    ListViewItem item = listView2.Items[i];
                    total += decimal.Parse(item.SubItems[3].Text);
                }
            }

            label15.Text = total + "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Qty must more than zero");
                return;
            }

            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItems = listView1.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    ListViewItem lv = listView1.FindItemWithText(selectedItem.SubItems[0].Text);
                    if (listView2.Items.Count > 0)
                    {
                        ListViewItem lvi = listView2.FindItemWithText(selectedItem.SubItems[0].Text);
                        if (lvi != null)
                        {
                            lvi.SubItems[0].Text = selectedItem.SubItems[0].Text;
                            lvi.SubItems[1].Text = selectedItem.SubItems[1].Text;
                                lvi.SubItems[2].Text = (Int32.Parse(lvi.SubItems[2].Text) + numericUpDown1.Value).ToString();
                                decimal totalPriceIng = Int32.Parse(lvi.SubItems[2].Text) * decimal.Parse(lv.SubItems[2].Text);
                                lvi.SubItems[3].Text = totalPriceIng.ToString();
                        }
                        else
                        {
                            ListViewItem items = new ListViewItem(selectedItem.SubItems[0].Text);
                            items.SubItems.Add(selectedItem.SubItems[1].Text);
                                items.SubItems.Add(numericUpDown1.Value.ToString());
                                decimal totalPriceIng = numericUpDown1.Value * decimal.Parse(selectedItem.SubItems[2].Text);
                                items.SubItems.Add(totalPriceIng.ToString());
                                listView2.Items.Add(items);
                        }
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(selectedItem.SubItems[0].Text);
                        item.SubItems.Add(selectedItem.SubItems[1].Text);
                        item.SubItems.Add(numericUpDown1.Value.ToString());
                        decimal totalPriceIng = numericUpDown1.Value * decimal.Parse(selectedItem.SubItems[2].Text);
                        item.SubItems.Add(totalPriceIng.ToString());
                        listView2.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the menu first..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            getTotalIngredientsPrice();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                var selectedItems = listView2.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    ListViewItem lvi = listView1.FindItemWithText(selectedItem.SubItems[1].Text);
                    if (lvi != null)
                    {
                        listView2.Items.Remove(selectedItem);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the menu first..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            getTotalIngredientsPrice();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            numericUpDown1.Value = 0;
            getTotalIngredientsPrice();
            loadOrderStatusData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox1.Text.Equals(string.Empty))
            {
                tabControl1.SelectTab(0);
                MessageBox.Show("Please select table first!");
                return;
            }

            if (listView2.Items.Count <= 0)
            {
                MessageBox.Show("Please insert at least one order!");
                return;
            }

            int tableId = data.Tables.Where(x => x.tableNo.Equals(textBox1.Text)).Select(x => x.tableId).First();

            Order o = new Order();
            o.tableId = tableId;
            o.status = "in progress";
            o.totalPrice = decimal.Parse(label15.Text);
            o.createdAt = DateTime.Now;
            o.updatedAt = DateTime.Now;

            try
            {
                data.Orders.Add(o);

                Table tbl = data.Tables.Find(tableId);
                tbl.status = "booked";

                try
                {
                    foreach (ListViewItem items in listView2.Items)
                    {
                        OrderDetail od = new OrderDetail();
                        od.orderId = o.orderId;
                        od.menuId = int.Parse(items.SubItems[0].Text);
                        od.qty = int.Parse(items.SubItems[2].Text);
                        od.price = decimal.Parse(items.SubItems[3].Text) / int.Parse(items.SubItems[2].Text);
                        od.subTotal = decimal.Parse(items.SubItems[3].Text);
                        od.status = "in progress";

                        try
                        {
                            data.OrderDetails.Add(od);

                            var menuIngredients = data.MenuIngredients.Where(x => x.menuId.Equals(od.menuId)).ToList();
                            foreach (var b in menuIngredients)
                            {
                                Ingredient ingredient = data.Ingredients.Find(b.ingredientsId);
                                if (ingredient.stock >= (b.qty * od.qty))
                                {
                                    ingredient.stock -= (b.qty * od.qty);
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, stock of ingredients for the menu is out of stock");
                                    return;
                                }

                                try
                                {
                                    data.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    MessageBox.Show("Thank you, order in progress..");
                    button6.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                var selectedItems = listView4.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    OrderDetail or = data.OrderDetails.Find(int.Parse(selectedItem.SubItems[0].Text));
                    or.status = "delivered";

                    data.SaveChanges();
                    selectedItem.BackColor = Color.Green;
                    selectedItem.ForeColor = Color.White;
                    MessageBox.Show("Food Delivered");
                    loadOrderStatusData();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                var selectedItems = listView4.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    OrderDetail or = data.OrderDetails.Find(int.Parse(selectedItem.SubItems[0].Text));
                    or.status = "cancelled";

                    data.SaveChanges();
                    selectedItem.BackColor = Color.DarkOrange;
                    selectedItem.ForeColor = Color.White;
                    MessageBox.Show("Food Cancelled");
                    loadOrderStatusData();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                var selectedItems = listView4.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    OrderDetail or = data.OrderDetails.Find(int.Parse(selectedItem.SubItems[0].Text));
                    or.status = "deleted";

                    data.SaveChanges();
                    selectedItem.BackColor = Color.Green;
                    selectedItem.ForeColor = Color.White;
                    MessageBox.Show("Food Deleted");
                    loadOrderStatusData();
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                listView4.Items.Clear();
                var selectedItems = listView3.SelectedItems;
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    int orderId = int.Parse(selectedItem.SubItems[0].Text);
                    var orderDetails = data.OrderDetails.Where(
                        x => x.orderId.Equals(orderId)
                        ).Select(x => new { 
                            Id = x.orderDetailsId,
                            Menu = x.Menu.menuName,
                            Qty = x.qty,
                            Status = x.status
                        }).ToList();

                    foreach (var a in orderDetails)
                    {
                        ListViewItem lv = new ListViewItem(a.Id.ToString());
                        lv.SubItems.Add(a.Menu);
                        lv.SubItems.Add(a.Qty.ToString());
                        lv.SubItems.Add(a.Status);

                        if (a.Status.Equals("in progress"))
                        {
                            lv.BackColor = Color.Gold;
                        }

                        if (a.Status.Equals("delivered"))
                        {
                            lv.BackColor = Color.Green;
                        }

                        if (a.Status.Equals("cancelled"))
                        {
                            lv.BackColor = Color.DarkOrange;
                        }

                        if (a.Status.Equals("deleted"))
                        {
                            lv.BackColor = Color.Crimson;
                        }

                        lv.ForeColor = Color.White;

                        listView4.Items.Add(lv);
                    }

                    listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }
    }
}
