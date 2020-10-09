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
    public partial class UnitForm : Form
    {
        public UnitForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                DbEditor.AddUnit(new Unit { Name = textBox1.Text, Code = textBox2.Text });
                AddProductForm AddProductForm = (AddProductForm)this.Owner;
                AddProductForm.comboBoxUnit.Items.Clear();
                AddProductForm.comboBoxUnit.Items.AddRange(DbEditor.GetAllUnits());
                this.Hide();

            }
            else
            {
                MessageBox.Show("Поля ввода не могут быть пустыми", "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
