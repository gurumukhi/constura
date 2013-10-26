using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int Maxitem = 0;
            Maxitem = 50000;
            progressBar1.Maximum = 50000; // your loop max no. 
            progressBar1.Value = 0;

            for (int i = 0; i < Maxitem; i++)
            {
                //System.Threading.Thread.Sleep(100);
                progressBar1.Value += 1;
            }


            MessageBox.Show("completed");
            progressBar1.Value = 0;
            String x = Microsoft.VisualBasic.Interaction.InputBox("Did you know your question goes here?", "Title", "Default Text");
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
