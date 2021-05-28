using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
if (UsernameTextBox.Text == "")
{
	MessageBox.Show("Please provide User name");
	UsernameTextBox.Focus();
	return;
}
//
if (PasswordTextBox.Text == "")
{
	MessageBox.Show("Please provide password");
	
	PasswordTextBox.Focus();
	return;
}

if (UsernameTextBox.Text != "admin" || PasswordTextBox.Text != "admin")
{
	MessageBox.Show("Invalid User name or password");
	UsernameTextBox.Text = "";
	PasswordTextBox.Text = "";
	UsernameTextBox.Focus();
	return;
}
    
            this.Hide();
            FrmPrincipal fp = new FrmPrincipal();
            fp.Show();
          
        }
        }
    }
