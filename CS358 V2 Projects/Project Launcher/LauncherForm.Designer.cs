namespace Launcher
{
    partial class LauncherForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.TextBox();
            this.miTheme1 = new MiTheme.MiTheme();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new MiTheme.Button();
            this.controlBox1 = new MiTheme.controlBox();
            this.miTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 398);
            this.panel1.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Status.Enabled = false;
            this.Status.Location = new System.Drawing.Point(1, 481);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(549, 20);
            this.Status.TabIndex = 1;
            // 
            // miTheme1
            // 
            this.miTheme1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.miTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.miTheme1.Controls.Add(this.checkBox1);
            this.miTheme1.Controls.Add(this.button1);
            this.miTheme1.Controls.Add(this.Status);
            this.miTheme1.Controls.Add(this.controlBox1);
            this.miTheme1.Customization = "//////+QHv+AgID/";
            this.miTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.miTheme1.Image = null;
            this.miTheme1.Location = new System.Drawing.Point(0, 0);
            this.miTheme1.Movable = true;
            this.miTheme1.Name = "miTheme1";
            this.miTheme1.NoRounding = false;
            this.miTheme1.Sizable = true;
            this.miTheme1.Size = new System.Drawing.Size(551, 502);
            this.miTheme1.SmartBounds = true;
            this.miTheme1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.miTheme1.TabIndex = 2;
            this.miTheme1.Text = "Project Launcher by Dmitry Post";
            this.miTheme1.TitleFont = new System.Drawing.Font("Segoe UI", 12F);
            this.miTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.miTheme1.Transparent = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(234, 458);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Embedded Console";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Customization = "9fX1/6x0AP/XkQH/76ka/++pGv/T09P/";
            this.button1.Font = new System.Drawing.Font("Verdana", 8F);
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(376, 452);
            this.button1.Name = "button1";
            this.button1.NoRounding = false;
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Additional Assembly";
            this.button1.Transparent = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controlBox1
            // 
            this.controlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox1.ChangeColorOnHover = true;
            this.controlBox1.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(230)))));
            this.controlBox1.CloseButtonEnabled = true;
            this.controlBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(183)))), ((int)(((byte)(250)))));
            this.controlBox1.Location = new System.Drawing.Point(427, 3);
            this.controlBox1.MinimizeButtonEnabled = true;
            this.controlBox1.Name = "controlBox1";
            this.controlBox1.RestoreButtonEnabled = false;
            this.controlBox1.ShowStyleMenu = true;
            this.controlBox1.Size = new System.Drawing.Size(120, 30);
            this.controlBox1.TabIndex = 0;
            this.controlBox1.Text = "controlBox1";
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.miTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LauncherForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.miTheme1.ResumeLayout(false);
            this.miTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Status;
        private MiTheme.MiTheme miTheme1;
        private MiTheme.controlBox controlBox1;
        private MiTheme.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

