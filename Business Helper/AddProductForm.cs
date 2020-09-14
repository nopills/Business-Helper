using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Helper
{
    public partial class AddProductForm : Form
    {   
        readonly string DbPath = Directory.GetCurrentDirectory() + @"\BH.db";
        public AddProductForm()
        {
            InitializeComponent();
            
            comboBoxUnit.Items.Clear();
            comboBoxUnit.Items.AddRange(DbEditor.GetAllUnits());

            comboBox2.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllProductForm AllProductFrm = (AllProductForm)this.Owner;
            if (File.Exists(DbPath))
            {
                DbEditor.AddItem(textBoxStuffName.Text, Convert.ToDouble(textBoxPrice.Text), Convert.ToDouble(textBoxVAT.Text), comboBoxUnit.Text);                            
                AllProductFrm.comboBoxItems.Items.Clear();
                AllProductFrm.comboBoxItems.Items.AddRange(DbEditor.GetAllItems());
                this.Hide();

            }
            else { throw new Exception("Database \"BH.db\" not found"); }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
