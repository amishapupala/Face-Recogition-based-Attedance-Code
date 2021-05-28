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
    public partial class frm_ForgotPassword : Form
    {
        public frm_ForgotPassword()
        {
            InitializeComponent();
        }

        private void frm_ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_ForgotCode.Text=="recognition")
            {
                MessageBox.Show("Username:admin Passowrd:admin","Face Recognition Attendance System",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("You are not authenticated users", "Face Recognition Attendance System",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
