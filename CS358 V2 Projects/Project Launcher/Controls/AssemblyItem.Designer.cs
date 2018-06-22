namespace Launcher
{
    partial class AssemblyItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CtrlContainer = new MiTheme.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new MiTheme.Panel();
            this.button2 = new MiTheme.Button();
            this.button1 = new MiTheme.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlContainer
            // 
            this.CtrlContainer.BackColor = System.Drawing.Color.PowderBlue;
            this.CtrlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlContainer.Location = new System.Drawing.Point(0, 33);
            this.CtrlContainer.Name = "CtrlContainer";
            this.CtrlContainer.Size = new System.Drawing.Size(530, 0);
            this.CtrlContainer.TabIndex = 0;
            this.CtrlContainer.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CtrlContainer_ControlAdded);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path to assembly";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 33);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Customization = "9fX1/6x0AP/XkQH/76ka/++pGv/T09P/";
            this.button2.Font = new System.Drawing.Font("Verdana", 8F);
            this.button2.Image = null;
            this.button2.Location = new System.Drawing.Point(468, 6);
            this.button2.Name = "button2";
            this.button2.NoRounding = false;
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "▲";
            this.toolTip1.SetToolTip(this.button2, "Show/Hide");
            this.button2.Transparent = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Customization = "9fX1/6x0AP/XkQH/76ka/++pGv/T09P/";
            this.button1.Font = new System.Drawing.Font("Verdana", 8F);
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(497, 6);
            this.button1.Name = "button1";
            this.button1.NoRounding = false;
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.toolTip1.SetToolTip(this.button1, "Unload Assembly");
            this.button1.Transparent = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AssemblyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Controls.Add(this.CtrlContainer);
            this.Controls.Add(this.panel1);
            this.Name = "AssemblyItem";
            this.Size = new System.Drawing.Size(530, 33);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MiTheme.Panel CtrlContainer;
        private System.Windows.Forms.Label label1;
        private MiTheme.Panel panel1;
        private MiTheme.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private MiTheme.Button button2;
    }
}
