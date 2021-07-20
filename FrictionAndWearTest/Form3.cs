using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Reflection;

namespace FrictionAndWearTest
{
    public partial class Form3 : Form
    {
        public string tstaff;
        public string tno;
        public string wcode;
        public string matcode;
        public string weight; 
        string[] ports = SerialPort.GetPortNames();
        private object ComboBox2;
        LinkedList<double[]> datas = new LinkedList<double[]>();
        Stopwatch stopWatch = new Stopwatch();

        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            tstaffBox.Text = tstaff;
            tstaffBox.Enabled = false;
            tnoBox.Text = tno;
            tnoBox.Enabled = false;
            wcodeBox.Text = wcode;
            wcodeBox.Enabled = false;
            matcodeBox.Text = matcode;
            matcodeBox.Enabled = false;
            weightBox.Text = weight;
            weightBox.Enabled = false;
            portStatusLabel.Text = "No Port Found.";
            connStatus.Text = "No connection.";
            portStatusLabel.BackColor = System.Drawing.Color.Transparent;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backForm = new Form1();
            this.Hide();
            DialogResult dialogResult = backForm.ShowDialog();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (string port in ports)
            {
                comboBox2.Items.Add(port);
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox2.Items.Count == 0)
            {
                MessageBox.Show("No Port Found. Check Test unit cables.");
            }
            else
            {
                portStatusLabel.Text = "Port Found.";
                portStatusLabel.BackColor = System.Drawing.Color.LimeGreen;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Edit")
            {
                tstaffBox.Enabled = true;
                tnoBox.Enabled = true;
                wcodeBox.Enabled = true;
                matcodeBox.Enabled = true;
                weightBox.Enabled = true;
                button3.Text = "Lock";
            }
            else {
                tstaffBox.Enabled = false;
                tnoBox.Enabled = false;
                wcodeBox.Enabled = false;
                matcodeBox.Enabled = false;
                weightBox.Enabled = false;
                button3.Text = "Edit";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button5.Enabled = true;
            if (serialPort1.IsOpen == false)
            {
                serialPort1.ReadTimeout = 100;
                serialPort1.PortName = comboBox2.Text;
                serialPort1.BaudRate = Convert.ToInt16(comboBox1.Text);
                try
                {
                    serialPort1.Open();
                    portStatusLabel.Text = "Port Opened.";
                    portStatusLabel.BackColor = System.Drawing.Color.LimeGreen;
                    connStatus.Text = "Connection Established.";

                    timer1.Interval = Int32.Parse(textBox9.Text);
                    timer1.Start();
                    stopWatch.Start();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Error: " + hata.Message);
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stopWatch.Stop();
            button4.Enabled = true;
            button5.Enabled = false;
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                portStatusLabel.Text = "Port Stoped.";
                portStatusLabel.BackColor = System.Drawing.Color.Yellow;
                connStatus.Text = "Connection Closed";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string result = serialPort1.ReadExisting();

                result = result.Split('\n')[0];
                //Console.WriteLine(sonuc);
                //Console.WriteLine(String.IsNullOrEmpty(sonuc));
                //Console.WriteLine(String.IsNullOrWhiteSpace(sonuc));

                if (String.IsNullOrEmpty(result))
                {
                    result = "0";
                }
                else
                {
                    takenData.Text = result + "";
                    double a = Convert.ToDouble(result);
                    double b = Convert.ToDouble(weightBox.Text);
                    resultOfCoefficent.Text = (a / b).ToString();
                    long mseconds = stopWatch.ElapsedMilliseconds;
                    timeOutput.Text = mseconds.ToString();
                    double[] dates = { mseconds, (double)(a / b) };
                    datas.AddLast(dates);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
                timer1.Stop();
                stopWatch.Stop();
            }

        }

        private void connStatus_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Time";
                oSheet.Cells[1, 2] = "Value";
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "B1").Font.Bold = true;
                oSheet.get_Range("A1", "B1").VerticalAlignment =
                Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                string[,] saNames = new string[datas.Count, 2];

                for (int i = 0; i < datas.Count; i++)
                {
                    var value = datas.ElementAt(i);
                    saNames[i, 0] = value[0].ToString();
                    saNames[i, 1] = value[1].ToString();
                }

                //Fill A2:BN with an array of values .
                string lastrow = "B" + (datas.Count + 1).ToString();

                oSheet.get_Range("A2", lastrow).Value2 = saNames;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                //oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                //oRng = oSheet.get_Range("A1", "D1");
                //oRng.EntireColumn.AutoFit();

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }
    }
}
