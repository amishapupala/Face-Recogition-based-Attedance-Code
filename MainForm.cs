

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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame; //to store image or current frame
        Capture grabber; // object for camera
        HaarCascade face;    // Haar classifier
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        string dat1, dat2, dat3;
        String strConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //  eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") || (textBox2.Text != "") || (textBox3.Text != ""))
                {
                    //Trained face counter
                    ContTrain = ContTrain + 1;

                    //Get a gray frame from capture device
                    gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face,
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                        break;
                    }

                    //resize face detected image for force to compare the same size with the 
                    //test image with cubic interpolation type method
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    trainingImages.Add(TrainedFace);
                    string user_data;
                    user_data = textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text;

                    labels.Add(user_data);

                    //Show face added in gray scale
                    imageBox1.Image = TrainedFace;

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }
                    String strCommandText;
                    strCommandText = "Insert Into [Student] ([StudentName], [StudentID], [Email_id]) Values ('" + textBox1.Text + "', '" + textBox2.Text + "' ,'" + textBox3.Text + "' )";

                    //  System.Data.OleDb.SqlCommand objSqlCommand = new System.Data.OleDb.SqlCommand();
                    SqlCommand objSqlCommand = new SqlCommand();

                    try
                    {
                        //  objSqlCommand.Connection = new System.Data.OleDb.OleDbConnection(strConnectionString);

                        objSqlCommand.Connection = new SqlConnection(strConnectionString);

                        //if (objSqlCommand.Connection.State == System.Data.ConnectionState.Closed)
                        //{
                          //  objSqlCommand.Connection.Open();
                        //}
                        if(objSqlCommand.Connection.State==ConnectionState.Closed)
                        {
                            objSqlCommand.Connection.Open();
                        }
                        //objSqlCommand.CommandText = strCommandText;
                        //objSqlCommand.CommandType = System.Data.CommandType.Text;
                        //objSqlCommand.ExecuteNonQuery();
                        objSqlCommand.CommandText = strCommandText;
                        objSqlCommand.CommandType = CommandType.Text;
                        objSqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Record saved sucessfully.");
                    }
                    catch (Exception ex)
                    {
                        if (objSqlCommand.Connection.State == ConnectionState.Open)
                        {
                            objSqlCommand.Connection.Close();
                        }
                        //MessageBox.Show("Error while saving the record.");
                    }

                    MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    imageBox1.Image = null;


                }
                else
                {
                    MessageBox.Show("Failed", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void FrameGrabber(object sender, EventArgs e)
        {
            Thread.Sleep(300);
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            int num_faces;
            num_faces = facesDetected.GetLength(0);
            if (num_faces <= 1)
            {
                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    if (num_faces <= 1)
                    {



                        t = t + 1;
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                        if (trainingImages.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.010);
                            //MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                            //Eigen face recognizer
                            EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                               trainingImages.ToArray(),
                               labels.ToArray(),
                              0,
                               ref termCrit);


                            string[] arr;
                            name = recognizer.Recognize(result);
                            arr = name.Split(';');
                            dat1 = arr[0];
                            dat2 = arr[1];
                            dat3 = arr[2];

                            //Draw the label for each face detected and recognized
                            currentFrame.Draw(dat1, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                        }

                        NamePersons[t - 1] = name;
                        NamePersons.Add("");

                    }
                    //Set the number of faces detected on the scene
                    label3.Text = facesDetected[0].Length.ToString();

                    num_faces = num_faces + 1;
                    //Set the region of interest on the faces

                    //    gray.ROI = f.rect;
                    //    MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                    //       eye,
                    //       1.1,
                    //       10,
                    //       Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    //       new Size(20, 20));
                    //    gray.ROI = Rectangle.Empty;

                    //    foreach (MCvAvgComp ey in eyesDetected[0])
                    //    {
                    //        Rectangle eyeRect = ey.rect;
                    //        eyeRect.Offset(f.rect.X, f.rect.Y);
                    //        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    //    }


                }
                t = 0;

                //Names concatenation of persons recognized
                //for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                //{
                //    names = names + NamePersons[nnn] + ", ";
                //}
                names = NamePersons[0];

                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
                label4.Text = dat1;
                label8.Text = dat2;
                label9.Text = dat3;
                names = "";
                return;
                //Clear the list(vector) of names
                // NamePersons.Clear();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today.Date.Date;
        }
        private long GenerateReport()
        {
            string strCommandText;
            strCommandText = "Select [StudentName], 'Present' as [Status] From [Attendance] Where [AttendanceDate] = @dtpDate Union all Select [StudentName], 'Absent' as [Status] From [Student] where Studentname not in(select [Studentname] from [Attendance] where AttendanceDate = @dtpDate) ";
            //strCommandText = "Select [StudentName] From [Attendance] Where [AttendanceDate] = @dtpDate"; 
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataTable objDataTable = new DataTable();
            try
            {
                objSqlDataAdapter.SelectCommand = new SqlCommand();
                objSqlDataAdapter.SelectCommand.Connection = new SqlConnection(strConnectionString);
                objSqlDataAdapter.SelectCommand.CommandText = strCommandText;
                objSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@dtpDate", dtpDate.Value);
                objSqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable.Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private long CheckAttendance()
        {
            string strCommandText;
            string adate = dtpDate.Value.ToShortDateString();
            strCommandText = "Select 1 From [Attendance] Where [StudentName] = '" + label4.Text + "'";

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataTable objDataTable = new DataTable();
            try
            {
                objSqlDataAdapter.SelectCommand = new SqlCommand();
                objSqlDataAdapter.SelectCommand.Connection = new SqlConnection(strConnectionString);
                objSqlDataAdapter.SelectCommand.CommandText = strCommandText;
                objSqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable.Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (CheckAttendance() > 0)
            {
                String strCommandText;
                strCommandText = "Insert Into [Attendance] ([StudentName], [AttendanceDate]) Values ('" + label4.Text + "', '" + dtpDate.Value + "' )";
                SqlCommand objSqlCommand = new SqlCommand();
                try
                {
                    objSqlCommand.Connection = new SqlConnection(strConnectionString);
                    if (objSqlCommand.Connection.State == ConnectionState.Closed)
                    {
                        objSqlCommand.Connection.Open();
                    }
                    objSqlCommand.CommandText = strCommandText;
                    objSqlCommand.CommandType = CommandType.Text;
                    objSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Record saved sucessfully.");
                }

                catch (Exception ex)
                {
                    if (objSqlCommand.Connection.State == ConnectionState.Open)
                    {
                        objSqlCommand.Connection.Close();
                    }
                    MessageBox.Show("Error while saving the record.");
                }
            }
            else
            {
                String strCommandText;
                strCommandText = "Insert Into [Attendance] ([StudentName], [AttendanceDate]) Values ('" + label4.Text + "', '" + dtpDate.Value + "' )";
                SqlCommand objSqlCommand = new SqlCommand();
                try
                {
                    objSqlCommand.Connection = new SqlConnection(strConnectionString);
                    if (objSqlCommand.Connection.State == ConnectionState.Closed)
                    {
                        objSqlCommand.Connection.Open();
                    }
                    objSqlCommand.CommandText = strCommandText;
                    objSqlCommand.CommandType = CommandType.Text;
                    objSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Record saved sucessfully.");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    if (objSqlCommand.Connection.State == ConnectionState.Open)
                    {
                        objSqlCommand.Connection.Close();
                    }
                    MessageBox.Show("Error while saving the record.");
                }
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport rep = new frmReport();
            rep.Show();
            //GenerateReport();
        }
    }

}