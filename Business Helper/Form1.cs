using Business_Helper.EF.Models;
using Business_Helper.Excel;
using Business_Helper.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddToolStripMenuItem.Click += new EventHandler(OnAddItem);
            RemoveToolStripMenuItem.Click += new EventHandler(RemoveItem);

            // Подгрузка из БД продавцов
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(DbEditor.GetAllSellers());
                     
            // Подгрузка из БД покупателей
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(DbEditor.GetAllCustomers());

            // Подгрузка из БД валюты
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(DbEditor.GetAllCurrency());
           
            //contextMenu.Click += new EventHandler(OnAddItem);
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            if (dataGrid.CurrentRow != null)
                dataGrid.Rows.RemoveAt(dataGrid.CurrentRow.Index); //dataGrid.SelectedCells[0].RowIndex
        }

        private void OnAddItem(object sender, EventArgs e)
        {
            AllProductForm ItemsForm = new AllProductForm();
            ItemsForm.Owner = this;
            ItemsForm.Show();
        }
        
       
        double ostatok = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            double mysumm = 0;
            if (tbMySumm.Text == String.Empty || Convert.ToDouble(tbMySumm.Text) <= 0)
            {
                MessageBox.Show("Значение суммы не может быть пустым и должно быть больше нуля.", "Внимание",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
            }
            else
            if (dataGrid.RowCount == 1)
            {
                MessageBox.Show("Таблица с товаром не может быть пустой.", "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                mysumm = Convert.ToDouble(tbMySumm.Text);
                Summator summ = new Summator(mysumm, Convert.ToDouble(lblSumm.Text));

                double cnt = summ.Count;
                double priceWithoutVat = 0;

                for (int i = 0; i < dataGrid.RowCount - 1; i++)
                {
                    dataGrid[1, i].Value = cnt;
                }


                textBox1.Text += summ.Count + "\t" + summ.Ostatok;
                ostatok = summ.Ostatok;



                for (int i = 0; i < dataGrid.RowCount - 1; i++)
                {
                    while (Convert.ToDouble(dataGrid[5, i].Value) <= ostatok)
                    {
                        if (Convert.ToDouble(dataGrid[5, i].Value) <= ostatok)
                        {
                            ostatok -= Convert.ToDouble(dataGrid[5, i].Value);
                            dataGrid[1, i].Value = Convert.ToDouble(dataGrid[1, i].Value) + 1;
                        }
                    }
                }


                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    priceWithoutVat += Convert.ToDouble(dataGrid[5, i].Value) * Convert.ToDouble(dataGrid[1, i].Value);
                }
                label4.Text = (mysumm - priceWithoutVat).ToString();
                lblSumm.Text = String.Format("{0:0.00}", priceWithoutVat);
            }
            
           



            /*
            double[] stuff = new double[dataGrid.RowCount-1];           
            for (int i = 0; i < stuff.Length; i++)
            {
                stuff[i] = Convert.ToDouble(dataGrid[5, i].Value);
            }

            var result = Summator.Summ(Convert.ToInt32(tbMySumm.Text), stuff);

            foreach (var s in result)
            {
                textBox1.Text += s + Environment.NewLine;
            }
            */
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        
            
        }

        private void tbMySumm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void dataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double vatWithoutPrice = 0;
            double priceWithoutVat = 0;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                vatWithoutPrice += Convert.ToDouble(dataGrid[6, i].Value);
                priceWithoutVat += Convert.ToDouble(dataGrid[5, i].Value);
            }
            lblVAT.Text = String.Format("{0:0.00}", vatWithoutPrice);
            lblSumm.Text = String.Format("{0:0.00}", priceWithoutVat);
        }

        private void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double vatWithoutPrice = 0;
            double priceWithoutVat = 0;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                vatWithoutPrice += Convert.ToDouble(dataGrid[6, i].Value);
                priceWithoutVat += Convert.ToDouble(dataGrid[5, i].Value);
            }
            lblVAT.Text = String.Format("{0:0.00}", Math.Round(vatWithoutPrice, 2));
            lblSumm.Text = String.Format("{0:0.00}", priceWithoutVat);
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //ExcelWorkbook excelFile = new ExcelWorkbook();
            //string path = excelFile.NewFile();
           // MessageBox.Show(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellerForm SellerForm = new SellerForm();
            SellerForm.Owner = this;
            SellerForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerForm CustomerForm = new CustomerForm();
            CustomerForm.Owner = this;
            CustomerForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedIndex.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sellerId = comboBox1.SelectedIndex + 1;
            int customerId = comboBox2.SelectedIndex + 1;
            int currencyId = comboBox3.SelectedIndex + 1;
            if (sellerId <= 0 && customerId <= 0 && currencyId <= 0)
            {
                MessageBox.Show("Выберите продавца, покупателя и валюту из существующих или добавьте новые.", "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);           
            }
            else
            {
                string examplePath = Directory.CreateDirectory(Application.StartupPath + "/Example").FullName;
                string filePath;
               
                if (!File.Exists($"{examplePath}/Factura.xlsx"))
                {
                    File.WriteAllBytes($"{examplePath}/Factura.xlsx", Resource.Factura);
                }

                Seller Seller = DbEditor.GetSellerById(sellerId);
                Customer Customer = DbEditor.GetCustomerById(customerId);
                Currency Currency = DbEditor.GetCurrencyById(currencyId);
                
                ExcelWorkbook WorkBook = new ExcelWorkbook($"{examplePath}/Factura.xlsx", Seller, Customer);
        
              
                WorkBook.facturaNumber = numericUpDown1.Value.ToString();
                WorkBook.facturaDate = dateTimePicker1.Value.ToString("dd MMMM yyyy");
                WorkBook.payDocumentNumber = numericUpDown2.Value.ToString();
                WorkBook.payDocumentDate = dateTimePicker2.Value.ToString("dd MMMM yyyy"); ;
                WorkBook.currencyCode = Currency.Code;
                WorkBook.Currency = Currency.Name;


                using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
                {
                    SaveFileDialog.Filter = "Файлы Excel (*.xlsx) | *.xlsx";
                    if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = SaveFileDialog.FileName;
                        if (WorkBook.CreateFile(filePath) == null)
                        {
                            throw new Exception("Ошибка создания файла");
                        }
                    }
                }
            }
           

           
                
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
               
               
            
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrencyForm CustomerForm = new CurrencyForm();
            CustomerForm.Owner = this;
            CustomerForm.Show();
        }
    }
}
