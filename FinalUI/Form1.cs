using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;

namespace FinalUI
{
    public partial class Form1 : Form
    {
        bool fileSelected = false;
        String res;
        String correct;

        public Form1()
        {
            InitializeComponent();
        }

        private void listen_Click(object sender, EventArgs e)
        {
            status.Text = "Playing";
            System.IO.StreamReader file = new System.IO.StreamReader("C:/OCR/file.txt");
            String line = "";
            String contents ="";
            while ((line = file.ReadLine()) != null)
            {
               contents += line;
            }
            file.Close();
            SpeechSynthesizer reader = new SpeechSynthesizer();
            reader.SpeakAsync(contents);
            //Read file
            //reader.SpeakAsync(fileContents);
            status.Text = "Stopped";
            status.Text = "Ready";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip listenTip = new ToolTip();
            listenTip.ShowAlways = true;
            listenTip.SetToolTip(listen, "Click here to listen what is recognised.");

            ToolTip clearTip = new ToolTip();
            clearTip.ShowAlways = true;
            clearTip.SetToolTip(clear, "Click here to clear the current image.");

            ToolTip browseTip = new ToolTip();
            browseTip.ShowAlways = true;
            browseTip.SetToolTip(browse, "Click here to upload an image.");

            ToolTip textTip = new ToolTip();
            textTip.ShowAlways = true;
            textTip.SetToolTip(text, "Click here to view the recognised text file.");

            ToolTip recogTip = new ToolTip();
            recogTip.ShowAlways = true;
            recogTip.SetToolTip(recognise, "Click here to view recognise the uploaded image.");

            ToolTip playTip = new ToolTip();
            playTip.ShowAlways = true;
            playTip.SetToolTip(resume, "Resume.");

            ToolTip pauseTip = new ToolTip();
            pauseTip.ShowAlways = true;
            pauseTip.SetToolTip(pause, "Pause.");

            ToolTip editTip = new ToolTip();
            editTip.ShowAlways = true;
            editTip.SetToolTip(pause, "Click here to make changes in the uploaded image.");

            ToolTip dispTip = new ToolTip();
            dispTip.ShowAlways = true;
            dispTip.SetToolTip(display, "Click here to view the edited image.");
            /*
            listen.Enabled = false;
            text.Enabled = false;
            pause.Enabled = false;
            resume.Enabled = false;*/
            edit.Enabled = false;
            speech.Enabled = false;
            display.Enabled = false;
            save.Enabled = false;

            pause.BackgroundImage = Image.FromFile(@"G:/FinalUI/pause.jpg");
            resume.BackgroundImage = Image.FromFile(@"G:/FinalUI/play.png");

            //pictureBox2.BackgroundImage = Image.FromFile(@"C:/Documents and Settings/205111007/Desktop/FinalUI/disp.jpg");
            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Pause
        private void pause_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer reader = new SpeechSynthesizer();
            if (reader.State == SynthesizerState.Speaking)
            {
                reader.Pause();
            }
            status.Text = "Paused";
        }

        //resume
        private void resume_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer reader = new SpeechSynthesizer();
            if (reader.State == SynthesizerState.Paused)
            {
                reader.Resume();
            }
            status.Text = "Playing";
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        //Create image from text
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(@"G:/FinalUI/temp.bmp");

            RectangleF rectf = new RectangleF(200, 200, 200, 200);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.DrawString("yourText", new Font("Thaoma", 20), Brushes.Black, rectf);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            g.Flush();

            pictureBox1.Image = bmp;
        }


        //Recognise processing
        private void recognise_Click_1(object sender, EventArgs e)
        {
                    
            Form2 f = new Form2();
            pictureBox3.Image = f.starRun(fileName.Text);
            
            int Maxitem = 0;
            Maxitem = 50000;
            toolStripProgressBar1.Maximum = 50000; 
            toolStripProgressBar1.Value = 0;

            for (int i = 0; i < Maxitem; i++)
            {
                //System.Threading.Thread.Sleep(100);
                toolStripProgressBar1.Value += 1;
                status.Text = "In Progress";
            }

            status.Text = "Complete";
            toolStripProgressBar1.Value = 0;
            if (listType.Text == "Character")
            {
                result.Text = "Recognised character is: " + Form2.textRecognised;
                System.IO.File.WriteAllText("C:/OCR/file.txt", Form2.textRecognised);

                res = Microsoft.VisualBasic.Interaction.InputBox("The recognised character is: " + Form2.textRecognised + ". Is it correct(y/n)?", "Are you staisfied?", "Y");
                if (res.Equals("y") || res.Equals("Y"))
                {
                    //MessageBox.Show("Thank you. Character recorded");
                    //saveThisCharacter();
                }
                else
                {
                    correct = Microsoft.VisualBasic.Interaction.InputBox("Enter the actual character", "Correct character", "");
                    trainNewCharacter(correct);
                }
            }
            else
            {
                MessageBox.Show("Click on Break Apart to recognise the paragraph");
            }
            
        }

        //Add the character(correctly recognised) to the text file
        private void saveThisCharacter()
        {
            //Append to the text file being saved(in temp folder)

            string[] lines = { "" };
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
        }

        //Creating new training set as per user's respone
        private void trainNewCharacter(String correct)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:/OCR/new/char.txt");
            string line;
            int fileCount = 0;

            if((line = file.ReadLine()) != null)
            {
                fileCount = line.Length;
            }
            file.Close();
            //MessageBox.Show(fileCount.ToString());
            //fileCount++;
            System.IO.File.Move(@"C:/OCR/temp/tempVector.txt", @"C:/OCR/new/" + fileCount + ".txt");
            File.AppendAllText("C:/OCR/new/char.txt", correct); 
        }


        //Read file for no. of entries
        private void readInfoFile()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
                //counter will give the maxCount
            }
            file.Close();

            //Append new entry
           // File.AppendAllText("C:\\perls.txt", "first part\n"); 

        }

        private void browse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            int size = 0;
            Form2 f = new Form2();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;                
                    fileSelected = true;
                    fileName.Text = file;

                 
                    pictureBox1.Image = Image.FromFile(file);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    height.Text = pictureBox1.Image.Height.ToString();
                    width.Text = pictureBox1.Image.Width.ToString();
                }
                catch (IOException)
                {
                    MessageBox.Show("Error in selecting file");
                }
            }

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("You have not selected any file");
                fileSelected = false;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            status.Text = "Ready";
            pictureBox1.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
        }

        private void control_Enter(object sender, EventArgs e)
        {

        }


        //Voice to text
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
          SpeechRecognizer recognizer = new SpeechRecognizer();

          // Create a simple grammar that recognizes "red", "green", or "blue".
          Choices colors = new Choices();
          colors.Add(new string[] { "red", "green", "blue" });

          // Create a GrammarBuilder object and append the Choices object.
          GrammarBuilder gb = new GrammarBuilder();
          gb.Append(colors);

          // Create the Grammar instance and load it into the speech recognition engine.
          Grammar g = new Grammar(gb);
          recognizer.LoadGrammar(g);

          // Register a handler for the SpeechRecognized event.
          recognizer.SpeechRecognized +=
            new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }

    
        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
          MessageBox.Show("Speech recognized: " + e.Result.Text);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            
        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Maxitem = 0;
            Maxitem = 50000;
            toolStripProgressBar1.Maximum = 50000;
            toolStripProgressBar1.Value = 0;
            
            status.Text = "Ready";

            for (int i = 0; i < Maxitem; i++)
            {
                //System.Threading.Thread.Sleep(100);
                toolStripProgressBar1.Value += 1;
            }

            status.Text = "Complete";
            toolStripProgressBar1.Value = 0;


            Form2 f2 = new Form2();
            int gl = 0;
            int last = -1;
            Bitmap x = new Bitmap(pictureBox3.Image);
            int out1 = 1;
            int n1 = 0;
            for (int j = 0; j < x.Height; j++)
            {
                if (gl == 1)
                {
                    //      for (int k = 0; k < x.Width; k++) x.SetPixel(k, j-1, Color.Blue);
                    gl = 0;
                }
                if (last != -1)
                {
                    listBox1.Items.Add(">> now finding char in lines from " + last + " to " + j + " <<");
                    n1 = 1;
                    //read this line
                    int bef, aft;
                    bef = 1;
                    aft = 0;
                    int te = 0;
                    for (int pix = 0; pix < x.Width; pix++)
                    {
                        int flag = 0;
                        for (int line = last; line < j; line++)
                        {
                            if (bef == 1 && x.GetPixel(pix, line) == Color.FromArgb(0, 0, 0))
                            {
                                int x1, x2, y1, y2;
                                //   for (int k = last; k < j; k++) x.SetPixel(pix - 1, k, Color.Red);
                                listBox1.Items.Add("TL.. " + pix + " " + last + " ");
                                x1 = pix-3;
                                y1 = last-3;
                                bef = 0;
                                while (bef == 0)
                                {
                                    pix++;
                                    flag = 0;
                                    for (line = last; line < j; line++)
                                    {
                                        if (x.GetPixel(pix, line) == Color.FromArgb(0, 0, 0))
                                            flag = 1;
                                    }
                                    if (flag == 0)
                                    {
                                        bef = 1;
                                        //  for (int k = last; k < j; k++) x.SetPixel(pix, k, Color.Green);
                                        listBox1.Items.Add("BR.. " + pix + " " + j + " ");
                                        x2 = pix+3;
                                        y2 = j - 1+3;
                                        for (int k = x1; k < x2; k++) x.SetPixel(k, y1, Color.Blue);
                                        for (int k = x1; k < x2; k++) x.SetPixel(k, y2, Color.Blue);
                                        for (int k = y1; k < y2; k++) x.SetPixel(x1, k, Color.Blue);
                                        for (int k = y1; k < y2; k++) x.SetPixel(x2, k, Color.Blue);
                                        string c = f2.identify(x1, x2, y1, y2, x, n1);
                                        if (n1 == 1)
                                        {   
                                            n1 = 0;
                                        }

                                    }
                                }
                                //break;
                            }
                        }
                    }
                    last = -1;
                }
                //      listBox1.Items.Add("outside "+j);
                for (int i = 0; i < x.Width; i++)
                {
                    Color y = x.GetPixel(i, j);
                    y.ToKnownColor();
                    if (out1 == 1 && y == Color.FromArgb(0, 0, 0))
                    {
                        //    listBox1.Items.Add(j);
                        if (gl == 0)
                        {
                            //              for (int k = 0; k < x.Width; k++) x.SetPixel(k, j - 1, Color.Blue);
                            last = j;
                            gl = 1;
                        }
                        out1 = 0;
                        while (out1 == 0)
                        {
                            j++;
                            //   listBox1.Items.Add(j);
                            int flag = 0;
                            for (int k = 0; i < x.Width; i++)
                                if (x.GetPixel(k, j) == Color.FromArgb(0, 0, 0))
                                    flag = 1;
                            if (flag == 0)
                            {
                                out1 = 1;
                                //   for (int k = 0; k < x.Width; k++, listBox1.Items.Add(j + 1+ " "+ k)) x.SetPixel(k,j + 1, Color.Red);
                                i = -1;
                                j++;
                            }
                        }
                    }
                }
            }
            String[] lines = { Form2.brokenString };
            System.IO.File.WriteAllLines("C:/OCR/file.txt", lines);
            pictureBox4.Image = x;
            label2.Text = Form2.brokenString;
            
        }

        private void text_Click_1(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:/OCR/file.txt");
            String line="";
            content.Text = "";
            while ((line = file.ReadLine()) != null)
            {
                content.Text += line + "\n";
            }
            file.Close();
            edit.Enabled = true;
            save.Enabled = true;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            content.ReadOnly = false;
        }

        private void save_Click(object sender, EventArgs e)
        {
            String[] lines = { content.Text };
            System.IO.File.WriteAllLines("C:/OCR/file.txt", lines);
            content.ReadOnly = true;
        }

    }
}