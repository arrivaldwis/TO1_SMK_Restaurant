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
    public partial class foodMenu : baseView
    {
        int menuId;
        public foodMenu()
        {
            InitializeComponent();
            loadFoodData();
            loadIngredientsData();
            loadListView();
        }

        private void loadListView()
        {
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Stock");
            listView1.Columns.Add("Unit");
            listView1.Columns.Add("Price/unit");

            listView2.Columns.Add("Name");
            listView2.Columns.Add("Qty");
            listView2.Columns.Add("Unit");
            listView2.Columns.Add("Total Price");
        }

        private void loadFoodData()
        {
            var food = data.Menus.Select(
                x => new { 
                    MenuId = x.menuId,
                    MenuName = x.menuName,
                    Price = x.price,
                    StartDate = x.startDate
                }).ToList();
            dataGridView1.DataSource = food;
        }

        private void loadIngredientsData()
        {
            var ingredients = data.Ingredients.Select(
                x => new { 
                    IngredientsName = x.ingredientsName,
                    Stock = x.stock,
                    Unit = x.unit,
                    Price = x.price
                }).ToList();

            foreach (var a in ingredients)
            {
                ListViewItem lv = new ListViewItem(a.IngredientsName);
                lv.SubItems.Add(a.Stock.ToString());
                lv.SubItems.Add(a.Unit);
                lv.SubItems.Add(a.Price.ToString());
                listView1.Items.Add(lv);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void actionAddEdit(int type)
        {
            foreach (var a in this.Controls.OfType<TextBox>().Where(x => x.Text == "" || x.Text == string.Empty))
            {
                MessageBox.Show("Please complete the field!");
                return;
            }

            if (listView2.Items.Count <= 0)
            {
                MessageBox.Show("Please choose at least one ingredients");
                return;
            }

            if (txtName.Text != string.Empty && textBox1.Text != string.Empty && listView2.Items.Count > 0)
            {

                double minPrice = 1.5 * double.Parse(label15.Text);
                if (double.Parse(textBox1.Text) < minPrice)
                {
                    MessageBox.Show("Minimum menu price is 150% * Total price of all ingredients" + Environment.NewLine + "Suggest price: >= " + minPrice);
                    return;
                }

                int exists = data.Menus.Where(x => x.menuId.Equals(this.menuId)).Count();

                if (type == 0)
                {
                    if (exists > 0)
                    {
                        MessageBox.Show("Sorry, this menu already exists");
                    }
                    else
                    {
                        Menu m = new Menu();
                        m.menuName = txtName.Text;
                        m.price = decimal.Parse(textBox1.Text);
                        m.startDate = dateTimePicker1.Value;

                        try
                        {
                            data.Menus.Add(m);
                            data.SaveChanges();

                            foreach (ListViewItem items in listView2.Items)
                            {
                                string name = items.SubItems[0].Text;
                                string qty = items.SubItems[1].Text;

                                MenuIngredient mi = new MenuIngredient();
                                mi.menuId = m.menuId;
                                mi.ingredientsId = data.Ingredients.Where(x => x.ingredientsName.Equals(name)).Select(x => x.ingredientsId).First();
                                mi.qty = int.Parse(qty);

                                try
                                {
                                    data.MenuIngredients.Add(mi);
                                    data.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            MessageBox.Show("Menu has been added!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    if (exists > 0)
                    {
                        Menu m = data.Menus.Find(this.menuId);
                        m.menuName = txtName.Text;
                        m.price = decimal.Parse(textBox1.Text);
                        m.startDate = dateTimePicker1.Value;

                        try
                        {
                            data.SaveChanges();

                            var mis = data.MenuIngredients.Where(x => x.menuId.Equals(this.menuId));
                            foreach (MenuIngredient ma in mis)
                            {
                                data.MenuIngredients.Remove(ma);
                            }

                            foreach (ListViewItem items in listView2.Items)
                            {
                                string name = items.SubItems[0].Text;
                                string qty = items.SubItems[1].Text;

                                MenuIngredient mi = new MenuIngredient();
                                mi.menuId = m.menuId;
                                mi.ingredientsId = data.Ingredients.Where(x => x.ingredientsName.Equals(name)).Select(x => x.ingredientsId).First();
                                mi.qty = int.Parse(qty);

                                try
                                {
                                    data.MenuIngredients.Add(mi);
                                    data.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            MessageBox.Show("Menu has been updated!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please complete the field!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Qty can't less than zero or zero");
                return;
            }

            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.DataSource = null;

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string menuName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            var food = data.Menus.Find(int.Parse(menuName));
            label12.Text = food.menuName;
            label11.Text = food.price.ToString();
            label10.Text = food.startDate.ToShortDateString();

            var ingredients = data.MenuIngredients.Where(x => x.menuId.Equals(food.menuId));
            dataGridView4.DataSource = ingredients.Select(x => new
            {
                Name = x.Ingredient.ingredientsName,
                Qty = x.qty,
                Unit = x.Ingredient.unit
            }).ToList();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadFoodData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.menuId = 0;
            textBox1.Text = string.Empty;
            txtName.Text = string.Empty;
            numericUpDown1.Value = 0;
            listView2.Items.Clear();
            button2.Text = "Add";
            getTotalIngredientsPrice();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string menuIds = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                var mis = data.MenuIngredients.Where(x => x.menuId.Equals(int.Parse(menuIds)));
                foreach (MenuIngredient ma in mis)
                {
                    data.MenuIngredients.Remove(ma);
                }

                try
                {
                    data.SaveChanges();

                    var menu = data.Menus.Find(int.Parse(menuIds));

                    try
                    {
                        data.Menus.Remove(menu);
                        data.SaveChanges();
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

                MessageBox.Show("Menus data has been remove");
                loadFoodData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the menu first");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Add"))
            {
                actionAddEdit(0);
            }
            else
            {
                actionAddEdit(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listView2.Items.Clear();

                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string menuName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                menuId = int.Parse(menuName);

                var menu = data.Menus.Find(int.Parse(menuName));
                txtName.Text = menu.menuName;
                textBox1.Text = menu.price.ToString();
                dateTimePicker1.Value = menu.startDate;

                foreach (var a in data.MenuIngredients.Where(x => x.menuId.Equals(menu.menuId)))
                {
                    ListViewItem lv = new ListViewItem(a.Ingredient.ingredientsName);
                    lv.SubItems.Add(a.qty.ToString());
                    lv.SubItems.Add(a.Ingredient.unit);

                    decimal totalPriceIng = a.qty * a.Ingredient.price;

                    lv.SubItems.Add(totalPriceIng.ToString());
                    listView2.Items.Add(lv);
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                getTotalIngredientsPrice();

                button2.Text = "Edit";
                tabControl1.SelectTab(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            label15.Text = total+"";
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var ingredients = data.Ingredients.Select(
                x => new
                {
                    IngredientsName = x.ingredientsName,
                    Stock = x.stock,
                    Unit = x.unit,
                    Price = x.price
                }).Where(x => x.IngredientsName.Contains(textBox2.Text)).ToList();

            foreach (var a in ingredients)
            {
                ListViewItem lv = new ListViewItem(a.IngredientsName);
                lv.SubItems.Add(a.Stock.ToString());
                lv.SubItems.Add(a.Unit);
                lv.SubItems.Add(a.Price.ToString());
                listView1.Items.Add(lv);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button7_Click_1(object sender, EventArgs e)
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
                    if (Int32.Parse(selectedItem.SubItems[1].Text) > 0)
                    {
                        ListViewItem lv = listView1.FindItemWithText(selectedItem.SubItems[0].Text);
                        if (listView2.Items.Count > 0)
                        {
                            ListViewItem lvi = listView2.FindItemWithText(selectedItem.SubItems[0].Text);
                            if (lvi != null)
                            {
                                if (long.Parse(lv.SubItems[1].Text) >= numericUpDown1.Value)
                                {
                                    lvi.SubItems[0].Text = selectedItem.SubItems[0].Text;
                                    lvi.SubItems[1].Text = (Int32.Parse(lvi.SubItems[1].Text) + numericUpDown1.Value).ToString();
                                    lvi.SubItems[2].Text = lv.SubItems[2].Text;
                                    decimal totalPriceIng = Int32.Parse(lvi.SubItems[1].Text) * decimal.Parse(lv.SubItems[3].Text);
                                    lvi.SubItems[3].Text = totalPriceIng.ToString();
                                    lv.SubItems[1].Text = (long.Parse(lv.SubItems[1].Text) - numericUpDown1.Value).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, ingredients out of stock", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                if (long.Parse(lv.SubItems[1].Text) >= numericUpDown1.Value)
                                {
                                    ListViewItem items = new ListViewItem(selectedItem.SubItems[0].Text);
                                    items.SubItems.Add(numericUpDown1.Value.ToString());
                                    items.SubItems.Add(selectedItem.SubItems[2].Text);
                                    decimal totalPriceIng = numericUpDown1.Value * decimal.Parse(selectedItem.SubItems[3].Text);
                                    items.SubItems.Add(totalPriceIng.ToString());
                                    listView2.Items.Add(items);
                                    lv.SubItems[1].Text = (long.Parse(lv.SubItems[1].Text) - numericUpDown1.Value).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, ingredients out of stock", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            if (long.Parse(lv.SubItems[1].Text) >= numericUpDown1.Value)
                            {
                                ListViewItem item = new ListViewItem(selectedItem.SubItems[0].Text);
                                item.SubItems.Add(numericUpDown1.Value.ToString());
                                item.SubItems.Add(selectedItem.SubItems[2].Text);
                                decimal totalPriceIng = numericUpDown1.Value * decimal.Parse(selectedItem.SubItems[3].Text);
                                item.SubItems.Add(totalPriceIng.ToString());
                                listView2.Items.Add(item);
                                lv.SubItems[1].Text = (long.Parse(lv.SubItems[1].Text) - numericUpDown1.Value).ToString();
                            }
                            else
                            {
                                MessageBox.Show("Sorry, ingredients out of stock", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, ingredients out of stock", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the ingredients first..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    ListViewItem lvi = listView1.FindItemWithText(selectedItem.SubItems[0].Text);
                    if (lvi != null)
                    {
                        listView2.Items.Remove(selectedItem);
                        lvi.SubItems[1].Text = (long.Parse(lvi.SubItems[1].Text) + long.Parse(selectedItem.SubItems[1].Text)).ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the menu ingredients first..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            getTotalIngredientsPrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = helper.onlyNumberTextField(textBox1);
            if (!isNumber)
            {
                textBox1.Text = "";
                MessageBox.Show("Only number!");
            }
        }
    }
}
