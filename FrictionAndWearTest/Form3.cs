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
using System.IO;

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
        string filePath = "c:\temp\output.txt";

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
                    File.AppendAllText(filePath, (a / b).ToString()+"\n");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
                timer1.Stop();
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

        }
    }
}
