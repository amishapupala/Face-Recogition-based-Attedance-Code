using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace MultiFaceRec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count =1;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if(count==3)
            {
                MessageBox.Show("Your attempts exceded. Restart Application  ", "Face Recognition Attendence System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }

            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                count++;
                if (UsernameTextBox.Text =="")
                {
                    MessageBox.Show("Please Enter User Name","Face Recognition Attendence System",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    UsernameTextBox.Focus();
                }
                if(PasswordTextBox.Text=="")
                {
                 
               
                    MessageBox.Show("Please Enter Password", "Face Recognition Attendence System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordTextBox.Focus();
                }

                    return;
            }
        
           
            if (UsernameTextBox.Text != "admin" || PasswordTextBox.Text != "admin")
            {
                count++;
                MessageBox.Show("Invalid User Name or Password", "Face Recognition Attendence System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
                UsernameTextBox.Focus();
                return;
            }

            this.Hide();
            FrmPrincipal fp = new FrmPrincipal();
            fp.Show();

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmr_SB_Tick(object sender, EventArgs e)
        {
            SBP3_Date.Text = DateTime.Today.ToString();
            SBP5_Showtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_ForgotPassword frmFP = new frm_ForgotPassword();
            frmFP.Show();
        }
    }
}
