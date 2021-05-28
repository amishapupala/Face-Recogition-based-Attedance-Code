using System;
using System.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace MultiFaceRec
{
    public partial class frmReport : Form
    {
        String strConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today.Date.Date;
            GenerateReport();
        }
        private void GenerateReport()
        {
            string strCommandText;
            strCommandText = "Select [StudentName], 'Present' as [Status] From [Attendance] Where [AttendanceDate] = @dtpDate Union Select [StudentName], 'Absent' as [Status] From [Student] where Studentname not in(select [Studentname] from [Attendance] where AttendanceDate = @dtpDate Order by [Studentname]) ";
            System.Data.OleDb.OleDbDataAdapter objOleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            System.Data.DataTable objDataTable = new System.Data.DataTable();
            try
            {
                objOleDbDataAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand();
                objOleDbDataAdapter.SelectCommand.Connection = new System.Data.OleDb.OleDbConnection(strConnectionString);
                objOleDbDataAdapter.SelectCommand.CommandText = strCommandText;
                objOleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@dtpDate",  dtpDate.Value);
                objOleDbDataAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;
                objOleDbDataAdapter.Fill(objDataTable);
                if (objDataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No Record Found");
                    return;
                }                
                dataGridView1.DataMember = objDataTable.TableName;
                //dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = objDataTable;
                dataGridView1.Refresh();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
