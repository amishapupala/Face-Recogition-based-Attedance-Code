namespace MultiFaceRec
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tmr_SB = new System.Windows.Forms.Timer(this.components);
            this.SB_Main = new System.Windows.Forms.StatusBar();
            this.SBP1_Status = new System.Windows.Forms.StatusBarPanel();
            this.SBP2_Today = new System.Windows.Forms.StatusBarPanel();
            this.SBP3_Date = new System.Windows.Forms.StatusBarPanel();
            this.SBP4_Time = new System.Windows.Forms.StatusBarPanel();
            this.SBP5_Showtime = new System.Windows.Forms.StatusBarPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBP1_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP2_Today)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP3_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP4_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP5_Showtime)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(183, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(22, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(108, 81);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(176, 26);
            this.PasswordTextBox.TabIndex = 10;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(108, 41);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(176, 26);
            this.UsernameTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.UsernameTextBox);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 218);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(108, 125);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 20);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password?";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tmr_SB
            // 
            this.tmr_SB.Enabled = true;
            this.tmr_SB.Tick += new System.EventHandler(this.tmr_SB_Tick);
            // 
            // SB_Main
            // 
            this.SB_Main.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SB_Main.Location = new System.Drawing.Point(0, 717);
            this.SB_Main.Name = "SB_Main";
            this.SB_Main.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.SBP1_Status,
            this.SBP2_Today,
            this.SBP3_Date,
            this.SBP4_Time,
            this.SBP5_Showtime});
            this.SB_Main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SB_Main.ShowPanels = true;
            this.SB_Main.Size = new System.Drawing.Size(1370, 32);
            this.SB_Main.TabIndex = 14;
            // 
            // SBP1_Status
            // 
            this.SBP1_Status.Name = "SBP1_Status";
            this.SBP1_Status.Text = "Face Recognition Attendance System";
            this.SBP1_Status.Width = 450;
            // 
            // SBP2_Today
            // 
            this.SBP2_Today.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.SBP2_Today.Name = "SBP2_Today";
            this.SBP2_Today.Text = "Today";
            this.SBP2_Today.Width = 60;
            // 
            // SBP3_Date
            // 
            this.SBP3_Date.Icon = ((System.Drawing.Icon)(resources.GetObject("SBP3_Date.Icon")));
            this.SBP3_Date.Name = "SBP3_Date";
            // 
            // SBP4_Time
            // 
            this.SBP4_Time.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.SBP4_Time.Name = "SBP4_Time";
            this.SBP4_Time.Text = "Time";
            this.SBP4_Time.Width = 60;
            // 
            // SBP5_Showtime
            // 
            this.SBP5_Showtime.Name = "SBP5_Showtime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(653, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(705, 42);
            this.label3.TabIndex = 15;
            this.label3.Text = "Face Recognition Attendance System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MultiFaceRec.Properties.Resources._3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SB_Main);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBP1_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP2_Today)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP3_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP4_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBP5_Showtime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Timer tmr_SB;
        internal System.Windows.Forms.StatusBar SB_Main;
        internal System.Windows.Forms.StatusBarPanel SBP1_Status;
        internal System.Windows.Forms.StatusBarPanel SBP2_Today;
        internal System.Windows.Forms.StatusBarPanel SBP3_Date;
        internal System.Windows.Forms.StatusBarPanel SBP4_Time;
        internal System.Windows.Forms.StatusBarPanel SBP5_Showtime;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
    }
}