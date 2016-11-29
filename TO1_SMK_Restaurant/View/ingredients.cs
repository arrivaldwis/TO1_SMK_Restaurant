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
    public partial class ingredients : baseView
    {
        public ingredients()
        {
            InitializeComponent();
            loadIngredientsData();
        }

        private void loadIngredientsData()
        {
            var employee = data.Ingredients.Select(x =>
                new
                {
                    Id= x.ingredientsId,
                    Ingredients = x.ingredientsName,
                    Stock = x.stock,
                    Unit = x.unit,
                    Price = x.price
                }
                ).ToList();
            dataGridView1.DataSource = employee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string ingredientsName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                addEditIngredients a = new addEditIngredients(1, ingredientsName);
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first! "+ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEditIngredients a = new addEditIngredients(0, "");
            a.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string ingredientsName = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                var ingredients = data.Ingredients.Find(int.Parse(ingredientsName));
                data.Ingredients.Remove(ingredients);
                data.SaveChanges();

                MessageBox.Show("Ingredients data has been remove");
                loadIngredientsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose the data first!"+ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            loadIngredientsData();
        }
    }
}
