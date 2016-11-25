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
    public partial class addEditIngredients : Form
    {
        smk_restaurantEntities data = new smk_restaurantEntities();
        Helper helper = new Helper();
        string ingredientsName = "";
        int type;
        public addEditIngredients(int type, string ingredientsName)
        {
            InitializeComponent();
            this.type = type;
            this.ingredientsName = ingredientsName;

            if (this.type == 1)
            {
                loadForm(ingredientsName);
            }
        }

        private void loadForm(string ingredientsName)
        {
            var ing = data.Ingredients.Where(x=>x.ingredientsName.Equals(ingredientsName)).First();
            label1.Text = ing.ingredientsId.ToString();
            textBox1.Text = ing.ingredientsName;
            numericUpDown1.Value = ing.stock;
            textBox2.Text = ing.price.ToString();
            textBox3.Text = ing.unit;
            button2.Text = "Edit";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var a in this.Controls.OfType<TextBox>().Where(x => x.Text == "" || x.Text == string.Empty))
            {
                MessageBox.Show("Please complete the field!");
                return;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Minimum stock is 1");
                return;
            }

            if (decimal.Parse(textBox2.Text) <= 0)
            {
                MessageBox.Show("Price can't less than zero or zero");
                return;
            }

            if (this.type == 0)
            {
                Ingredient ing = new Ingredient();
                ing.ingredientsName = textBox1.Text;
                ing.stock = int.Parse(numericUpDown1.Value.ToString());
                ing.unit = textBox3.Text;
                ing.price = decimal.Parse(textBox2.Text);

                try
                {
                    data.Ingredients.Add(ing);
                    data.SaveChanges();
                    MessageBox.Show("Ingredients has been added");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Ingredient ing = data.Ingredients.Find(int.Parse(label1.Text));
                ing.ingredientsName = textBox1.Text;
                ing.stock = int.Parse(numericUpDown1.Value.ToString());
                ing.unit = textBox3.Text;
                ing.price = decimal.Parse(textBox2.Text);

                try
                {
                    data.SaveChanges();
                    MessageBox.Show("Ingredients has been updated");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
    }
}
