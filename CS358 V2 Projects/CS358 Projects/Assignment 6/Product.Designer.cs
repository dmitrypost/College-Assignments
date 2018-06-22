namespace CS358_Projects.Assignment_6
{
    partial class Product
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
            this.textBoxEx2 = new CS358_Projects.Assignment_6.TextBoxEx();
            this.textBoxEx3 = new CS358_Projects.Assignment_6.TextBoxEx();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEx1 = new CS358_Projects.Assignment_6.TextBoxEx();
            this.SuspendLayout();
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEx2.InitialText = "Description";
            this.textBoxEx2.Location = new System.Drawing.Point(105, 68);
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.Size = new System.Drawing.Size(100, 20);
            this.textBoxEx2.TabIndex = 3;
            this.textBoxEx2.Text = "Description";
            // 
            // textBoxEx3
            // 
            this.textBoxEx3.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEx3.InitialText = "Price";
            this.textBoxEx3.Location = new System.Drawing.Point(105, 42);
            this.textBoxEx3.Name = "textBoxEx3";
            this.textBoxEx3.Size = new System.Drawing.Size(100, 20);
            this.textBoxEx3.TabIndex = 2;
            this.textBoxEx3.Text = "Price";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(69, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(150, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
           
            this.label3.Text = "Product Code";
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEx1.InitialText = "Code";
            this.textBoxEx1.Location = new System.Drawing.Point(105, 16);
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(100, 20);
            this.textBoxEx1.TabIndex = 1;
            this.textBoxEx1.Text = "Code";
            // 
            // Product
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(234, 146);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEx1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxEx3);
            this.Controls.Add(this.textBoxEx2);
            this.Name = "Product";
            this.Text = "Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBoxEx textBoxEx2;
        private TextBoxEx textBoxEx3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private TextBoxEx textBoxEx1;
    }
}