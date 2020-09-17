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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            Form1 MainFrm = (Form1)this.Owner;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 &&
               textBox4.Text.Length != 0 && textBox5.Text.Length != 0 && textBox6.Text.Length != 0 &&
               textBox7.Text.Length != 0 && textBox8.Text.Length != 0 && textBox9.Text.Length != 0)
            {
                Customer customer = new Customer
                {
                    Name = textBox1.Text,
                    INN = textBox2.Text,
                    KPP = textBox3.Text,
                    Adress = textBox4.Text,
                    Sender = textBox5.Text,
                    CheckingAcc = textBox6.Text,
                    BIK = textBox7.Text,
                    BankName = textBox8.Text,
                    CorpAcc = textBox9.Text
                };
                DbEditor.AddCustomer(customer);
               
                Form1 MainForm = (Form1)this.Owner;
                MainForm.comboBox2.Items.Clear();
                MainForm.comboBox2.Items.AddRange(DbEditor.GetAllCustomers());
                this.Hide();
            }
            else
                MessageBox.Show("Присутствуют незаполненные поля", "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
