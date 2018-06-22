namespace CS358_Projects.Assignment_5
{
    partial class Recycle_Shop_V2
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ButtonEditTemplate = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonYearlyPaymentForward = new System.Windows.Forms.Button();
            this.labelYearPayment = new System.Windows.Forms.Label();
            this.buttonYearlyPaymentBack = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonQuorterPaymentForward = new System.Windows.Forms.Button();
            this.labelQuorterPayments = new System.Windows.Forms.Label();
            this.buttonQuorterPaymentBack = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonMonthPaymentForward = new System.Windows.Forms.Button();
            this.labelMonthPayments = new System.Windows.Forms.Label();
            this.buttonMonthPaymentBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add to reciept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addtolistbutton);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.Calculate);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDown1.Location = new System.Drawing.Point(121, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.Calculate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(181, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Price:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(74, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.AddItemToDatabaseButton);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(9, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 163);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(237, 138);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(229, 112);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Price";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(229, 112);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 41);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 19;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(74, 67);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Update";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.EditItemInDatabaseButton);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Price";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(74, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(229, 112);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(74, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 23);
            this.button7.TabIndex = 21;
            this.button7.Text = "Delete";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.DeleteItemInDatabaseButton);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Name";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(74, 14);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ButtonEditTemplate);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.printPreviewControl1);
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 394);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reciept Preview";
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.AutoZoom = false;
            this.printPreviewControl1.Document = this.printDocument1;
            this.printPreviewControl1.Location = new System.Drawing.Point(20, 19);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(339, 340);
            this.printPreviewControl1.TabIndex = 18;
            this.printPreviewControl1.Zoom = 1D;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // ButtonEditTemplate
            // 
            this.ButtonEditTemplate.Location = new System.Drawing.Point(277, 365);
            this.ButtonEditTemplate.Name = "ButtonEditTemplate";
            this.ButtonEditTemplate.Size = new System.Drawing.Size(82, 23);
            this.ButtonEditTemplate.TabIndex = 14;
            this.ButtonEditTemplate.Text = "Edit Template";
            this.ButtonEditTemplate.UseVisualStyleBackColor = true;
            this.ButtonEditTemplate.Click += new System.EventHandler(this.ButtonEditTemplate_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(206, 365);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(65, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "Print";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NewTransaction);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(127, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.AddTransactionToList);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox4);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(9, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 93);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transaction";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(90, 59);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(139, 21);
            this.comboBox4.TabIndex = 16;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(9, 58);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 15;
            this.button9.Text = "View";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "------------------------------------------------------------------------";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 126);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonYearlyPaymentForward);
            this.panel1.Controls.Add(this.labelYearPayment);
            this.panel1.Controls.Add(this.buttonYearlyPaymentBack);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.buttonQuorterPaymentForward);
            this.panel1.Controls.Add(this.labelQuorterPayments);
            this.panel1.Controls.Add(this.buttonQuorterPaymentBack);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.buttonMonthPaymentForward);
            this.panel1.Controls.Add(this.labelMonthPayments);
            this.panel1.Controls.Add(this.buttonMonthPaymentBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 26);
            this.panel1.TabIndex = 19;
            // 
            // buttonYearlyPaymentForward
            // 
            this.buttonYearlyPaymentForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonYearlyPaymentForward.Location = new System.Drawing.Point(621, 0);
            this.buttonYearlyPaymentForward.Name = "buttonYearlyPaymentForward";
            this.buttonYearlyPaymentForward.Size = new System.Drawing.Size(20, 24);
            this.buttonYearlyPaymentForward.TabIndex = 9;
            this.buttonYearlyPaymentForward.Text = ">";
            this.buttonYearlyPaymentForward.UseVisualStyleBackColor = true;
            this.buttonYearlyPaymentForward.Click += new System.EventHandler(this.buttonYearlyPaymentForward_Click);
            // 
            // labelYearPayment
            // 
            this.labelYearPayment.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelYearPayment.Location = new System.Drawing.Point(464, 0);
            this.labelYearPayment.Name = "labelYearPayment";
            this.labelYearPayment.Size = new System.Drawing.Size(157, 24);
            this.labelYearPayment.TabIndex = 8;
            this.labelYearPayment.Text = "Year payments: $0.00";
            this.labelYearPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonYearlyPaymentBack
            // 
            this.buttonYearlyPaymentBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonYearlyPaymentBack.Location = new System.Drawing.Point(444, 0);
            this.buttonYearlyPaymentBack.Name = "buttonYearlyPaymentBack";
            this.buttonYearlyPaymentBack.Size = new System.Drawing.Size(20, 24);
            this.buttonYearlyPaymentBack.TabIndex = 10;
            this.buttonYearlyPaymentBack.Text = "<";
            this.buttonYearlyPaymentBack.UseVisualStyleBackColor = true;
            this.buttonYearlyPaymentBack.Click += new System.EventHandler(this.buttonYearlyPaymentBack_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(419, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 24);
            this.label12.TabIndex = 7;
            this.label12.Text = "|";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonQuorterPaymentForward
            // 
            this.buttonQuorterPaymentForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonQuorterPaymentForward.Location = new System.Drawing.Point(399, 0);
            this.buttonQuorterPaymentForward.Name = "buttonQuorterPaymentForward";
            this.buttonQuorterPaymentForward.Size = new System.Drawing.Size(20, 24);
            this.buttonQuorterPaymentForward.TabIndex = 5;
            this.buttonQuorterPaymentForward.Text = ">";
            this.buttonQuorterPaymentForward.UseVisualStyleBackColor = true;
            this.buttonQuorterPaymentForward.Click += new System.EventHandler(this.buttonQuorterPaymentForward_Click);
            // 
            // labelQuorterPayments
            // 
            this.labelQuorterPayments.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelQuorterPayments.Location = new System.Drawing.Point(242, 0);
            this.labelQuorterPayments.Name = "labelQuorterPayments";
            this.labelQuorterPayments.Size = new System.Drawing.Size(157, 24);
            this.labelQuorterPayments.TabIndex = 4;
            this.labelQuorterPayments.Text = "Quorter 1 payments: $0.00";
            this.labelQuorterPayments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonQuorterPaymentBack
            // 
            this.buttonQuorterPaymentBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonQuorterPaymentBack.Location = new System.Drawing.Point(222, 0);
            this.buttonQuorterPaymentBack.Name = "buttonQuorterPaymentBack";
            this.buttonQuorterPaymentBack.Size = new System.Drawing.Size(20, 24);
            this.buttonQuorterPaymentBack.TabIndex = 6;
            this.buttonQuorterPaymentBack.Text = "<";
            this.buttonQuorterPaymentBack.UseVisualStyleBackColor = true;
            this.buttonQuorterPaymentBack.Click += new System.EventHandler(this.buttonQuorterPaymentBack_Click);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(197, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 24);
            this.label9.TabIndex = 3;
            this.label9.Text = "|";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMonthPaymentForward
            // 
            this.buttonMonthPaymentForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMonthPaymentForward.Location = new System.Drawing.Point(177, 0);
            this.buttonMonthPaymentForward.Name = "buttonMonthPaymentForward";
            this.buttonMonthPaymentForward.Size = new System.Drawing.Size(20, 24);
            this.buttonMonthPaymentForward.TabIndex = 1;
            this.buttonMonthPaymentForward.Text = ">";
            this.buttonMonthPaymentForward.UseVisualStyleBackColor = true;
            this.buttonMonthPaymentForward.Click += new System.EventHandler(this.buttonMonthPaymentForward_Click);
            // 
            // labelMonthPayments
            // 
            this.labelMonthPayments.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMonthPayments.Location = new System.Drawing.Point(20, 0);
            this.labelMonthPayments.Name = "labelMonthPayments";
            this.labelMonthPayments.Size = new System.Drawing.Size(157, 24);
            this.labelMonthPayments.TabIndex = 0;
            this.labelMonthPayments.Text = "January payments: $0.00";
            this.labelMonthPayments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMonthPaymentBack
            // 
            this.buttonMonthPaymentBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMonthPaymentBack.Location = new System.Drawing.Point(0, 0);
            this.buttonMonthPaymentBack.Name = "buttonMonthPaymentBack";
            this.buttonMonthPaymentBack.Size = new System.Drawing.Size(20, 24);
            this.buttonMonthPaymentBack.TabIndex = 2;
            this.buttonMonthPaymentBack.Text = "<";
            this.buttonMonthPaymentBack.UseVisualStyleBackColor = true;
            this.buttonMonthPaymentBack.Click += new System.EventHandler(this.buttonMonthPaymentBack_Click);
            // 
            // Recycle_Shop_V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(644, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Recycle_Shop_V2";
            this.Text = "Recycle Shop V2 - Assignment 5";
            this.Load += new System.EventHandler(this.Recycle_Shop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonEditTemplate;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelYearPayment;
        private System.Windows.Forms.Button buttonYearlyPaymentBack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonQuorterPaymentForward;
        private System.Windows.Forms.Label labelQuorterPayments;
        private System.Windows.Forms.Button buttonQuorterPaymentBack;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonMonthPaymentForward;
        private System.Windows.Forms.Label labelMonthPayments;
        private System.Windows.Forms.Button buttonMonthPaymentBack;
        private System.Windows.Forms.Button buttonYearlyPaymentForward;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}