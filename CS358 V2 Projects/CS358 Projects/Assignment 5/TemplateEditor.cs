using System.Drawing;
using System.Windows.Forms;

namespace CS358_Projects.Assignment_5
{
    public class TemplateEditor
    {
       

        #region "edit the reciept template code"
        //-------------------------------------------------------//
        //-------------------------------------------------------//
        

        public class TemplateDialog
        {
            public static Transactions.RecieptTemplate Template = Transactions.LoadTemplate();
            public DialogResult ShowDialog() //creates the dialog controls and functions...
            {

                // 
                // prompt (this dialog)
                // 
                Form prompt = new Form()
                {
                    AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F),
                    AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font,
                    ClientSize = new System.Drawing.Size(353, 311),
                    Name = "Form1",
                    Text = "Reciept Template Editor",

                };

                Label label1 = new Label() { AutoSize = true, Location = new Point(6, 16), Name = "label1", Size = new Size(98, 13), Text = "Welcome Message" };
                TextBox textBox1 = new TextBox() { Location = new Point(110, 13), Name = "textBox1", Size = new Size(212, 20), Text = Template.welcomeMessage };
                TextBox textBox2 = new TextBox() { Location = new Point(110, 39), Name = "textBox2", Size = new Size(212, 20), Text = Template.storeName };
                Label label2 = new Label() { AutoSize = true, Location = new Point(41, 42), Name = "label2", Size = new Size(63, 13), Text = "Store Name" };
                TextBox textBox3 = new TextBox() { Location = new Point(110, 65), Name = "textBox3", Size = new Size(212, 20), Text = Template.location };
                Label label3 = new Label() { AutoSize = true, Location = new Point(56, 68), Name = "label3", Size = new Size(48, 13), Text = "Location" };
                TextBox textBox4 = new TextBox() { Location = new Point(110, 91), Name = "textBox4", Size = new Size(212, 20), Text = Template.phonenumber };
                Label label4 = new Label() { AutoSize = true, Location = new Point(26, 94), Name = "label4", Size = new Size(78, 13), Text = "Phone Number" };
                TextBox textBox5 = new TextBox() { Location = new Point(116, 19), Name = "textBox5", Size = new Size(206, 20), Text = Template.website };
                Label label5 = new Label() { AutoSize = true, Location = new Point(64, 22), Name = "label5", Size = new Size(46, 13), Text = "Website" };
                TextBox textBox6 = new TextBox() { Location = new Point(116, 45), Name = "textBox6", Size = new Size(206, 20), Text = Template.thankYouMessage };
                Label label6 = new Label() { AutoSize = true, Location = new Point(4, 48), Name = "label6", Size = new Size(106, 13), Text = "Thank You Message" };
                Label label7 = new Label()
                {
                    AutoSize = true,
                    Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(45, 142),
                    Name = "label7",
                    Size = new Size(289, 18),
                    Text = "------------------------Items-------------------------"
                };
                prompt.Controls.Add(label7); //add the control to form since it does not belong to a groupbox
                GroupBox groupBox1 = new GroupBox() { Location = new Point(12, 12), Name = "groupBox1", Size = new Size(329, 127), TabStop = false, Text = "Header" };
                prompt.Controls.Add(groupBox1); //add the control to form

                groupBox1.Controls.Add(label1);
                groupBox1.Controls.Add(textBox1);
                groupBox1.Controls.Add(label2);
                groupBox1.Controls.Add(textBox2);
                groupBox1.Controls.Add(label3);
                groupBox1.Controls.Add(textBox4);
                groupBox1.Controls.Add(textBox3);
                groupBox1.Controls.Add(label4);

                GroupBox groupBox2 = new GroupBox()
                {
                    Location = new System.Drawing.Point(12, 175),
                    Name = "groupBox2",
                    Size = new System.Drawing.Size(329, 85),
                    TabStop = false,
                    Text = "Footer"
                };
                prompt.Controls.Add(groupBox2); //add the control to form

                groupBox2.Controls.Add(label6);
                groupBox2.Controls.Add(textBox6);
                groupBox2.Controls.Add(label5);
                groupBox2.Controls.Add(textBox5);

                // layout crap... 
                groupBox1.ResumeLayout(false);
                groupBox1.PerformLayout();
                groupBox2.ResumeLayout(false);
                groupBox2.PerformLayout();
                prompt.ResumeLayout(false);
                prompt.PerformLayout();
                groupBox1.SuspendLayout();
                groupBox2.SuspendLayout();
                prompt.SuspendLayout();

                // 
                // Confirmation Button
                // 
                Button Confirmation = new Button()
                {
                    DialogResult = DialogResult.OK,
                    Location = new Point(187, 276),
                    Name = "Confirmation",
                    Size = new Size(75, 23),
                    TabIndex = 0,
                    Text = "OK",
                    UseVisualStyleBackColor = true
                };
                prompt.Controls.Add(Confirmation); //adds the control to the dialog
                Confirmation.Click += (sender, e) =>
                {
                    // put contents into the template
                    Template.welcomeMessage = textBox1.Text;
                    Template.storeName = textBox2.Text;
                    Template.location = textBox3.Text;
                    Template.phonenumber = textBox4.Text;
                    Template.website = textBox5.Text;
                    Template.thankYouMessage = textBox6.Text;

                    prompt.Close(); //closes dialog...
                };

                // 
                // Cancellation Button
                // 
                Button Cancellation = new Button()
                {
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(266, 276),
                    Name = "Cancellation",
                    Size = new Size(75, 23),
                    TabIndex = 1,
                    Text = "Cancel",
                    UseVisualStyleBackColor = true
                };
                prompt.Controls.Add(Cancellation);
                Cancellation.Click += (sender, e) => { prompt.Close(); }; //closes dialog

                prompt.ShowDialog();
                return prompt.DialogResult; //allows for code such as (if templatedialog.ShowDialog() == DialogResult.OK)

            }
        }

        #endregion

     
    }
}
