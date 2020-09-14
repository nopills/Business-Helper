namespace Business_Helper
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBoxVAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.textBoxStuffName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 21);
            this.button2.TabIndex = 21;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 21);
            this.button1.TabIndex = 20;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Начислить",
            "Выделить",
            "Без НДС"});
            this.comboBox2.Location = new System.Drawing.Point(203, 93);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(96, 21);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.Visible = false;
            // 
            // textBoxVAT
            // 
            this.textBoxVAT.Location = new System.Drawing.Point(101, 93);
            this.textBoxVAT.Name = "textBoxVAT";
            this.textBoxVAT.Size = new System.Drawing.Size(96, 20);
            this.textBoxVAT.TabIndex = 18;
            this.textBoxVAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVAT_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "НДС, %";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(101, 67);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(96, 20);
            this.textBoxPrice.TabIndex = 16;
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Цена без НДС";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ед. имзерения";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "шт",
            "кг",
            "м",
            "м2",
            "м3"});
            this.comboBoxUnit.Location = new System.Drawing.Point(101, 39);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(96, 21);
            this.comboBoxUnit.TabIndex = 13;
            // 
            // textBoxStuffName
            // 
            this.textBoxStuffName.Location = new System.Drawing.Point(101, 13);
            this.textBoxStuffName.Name = "textBoxStuffName";
            this.textBoxStuffName.Size = new System.Drawing.Size(332, 20);
            this.textBoxStuffName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Наименование";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 156);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBoxVAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxUnit);
            this.Controls.Add(this.textBoxStuffName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить товар";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBoxVAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.TextBox textBoxStuffName;
        private System.Windows.Forms.Label label1;
    }
}