using Business_Helper.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Helper
{
    public partial class CurrencyForm : Form
    {
        public CurrencyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                DbEditor.AddCurrency(new Currency { Name = textBox1.Text, Code = textBox2.Text });
                Form1 MainForm = (Form1)this.Owner;
                MainForm.comboBox3.Items.Clear();
                MainForm.comboBox3.Items.AddRange(DbEditor.GetAllCurrency());
                this.Hide();

            } else
            {
               MessageBox.Show("Поля ввода не могут быть пустыми", "Внимание",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
