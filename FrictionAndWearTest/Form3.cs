using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrictionAndWearTest
{
    public partial class Form3 : Form
    {
        public string tstaff;
        public string tno;
        public string wcode;
        public string matcode;
        public string weight;

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

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
