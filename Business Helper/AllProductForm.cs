using Business_Helper.Data;
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
    public partial class AllProductForm : Form
    {
        //public List<Product> ProductList;
        public AllProductForm()
        {
            InitializeComponent();
            comboBoxItems.Items.Clear();
            comboBoxItems.Items.AddRange(DbEditor.GetAllItems());
            comboBox2.SelectedIndex = 1;
        }

        public double _vatWithoutPrice { get; private set; }
        private void AllProductForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm AddProductFrm = new AddProductForm();
            AddProductFrm.Owner = this;
            AddProductFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string NameOfItem = comboBoxItems.Text;
            double PriceOfItem = Convert.ToDouble(textBoxPrice.Text);
            double CountOfItem = Convert.ToDouble(textBoxCount.Text);
            string UnitOfItem = labelUnit.Text;
            double VATPercent = Convert.ToDouble(textBoxVAT.Text);
            double SummItemsPrice = PriceOfItem * CountOfItem;

            Form1 mainFrm = (Form1)this.Owner;
            if (comboBoxItems.Text.Length != 0 && textBoxCount.Text.Length != 0 && textBoxPrice.Text.Length != 0 && textBoxVAT.Text.Length != 0 && comboBox2.Text.Length != 0)
            {
                if (comboBox2.SelectedIndex == 1)
                {
                    CalculateVAT vatCalculator = new CalculateVAT(PriceOfItem, VATPercent);
                    double priceWithoutVat = vatCalculator.priceWithoutVat();
                    double vatWithoutPrice = vatCalculator.vatSumm();
                    //MessageBox.Show((Math.Round(vatWithoutPrice * CountOfItem, 2)).ToString());
                    //double SummItemsPrice = VATCalc.SummItemsPrice(CalcVat, CountOfItem);
                    //double SummVAT = VATCalc.SummAllVat(VATPercent, CountOfItem);
                    priceWithoutVat = Math.Round(priceWithoutVat * CountOfItem, 2);
                    vatWithoutPrice = Math.Round(vatWithoutPrice * CountOfItem, 2);
                    mainFrm.dataGrid.Rows.Add(NameOfItem, CountOfItem, UnitOfItem, String.Format("{0:0.00}", PriceOfItem), VATPercent, String.Format("{0:0.00}", SummItemsPrice), vatWithoutPrice, priceWithoutVat);
                    
                    
                   
                    //mainFrm.lblVAT.Text = String.Format("{0:0.00}", vatWithoutPrice * CountOfItem);
                    // mainFrm.ChangedSummLabel = String.Format("{0:0.00}", SummItemsPrice);
                    //  mainFrm.ChangeVATLabel = String.Format("{0:0.00}", SummVAT);
                }
            }
        }

        private void comboBoxItems_SelectedValueChanged(object sender, EventArgs e)
        {
            var ResultItem = DbEditor.GetItem(comboBoxItems.SelectedItem.ToString());
            textBoxPrice.Text = Convert.ToString(ResultItem.Item1);
            textBoxVAT.Text = Convert.ToString(ResultItem.Item2);
            labelUnit.Text = ResultItem.Item3;
        }

        private void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {    
                e.Handled = true;
        }
    }
}
