﻿using Business_Helper.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
