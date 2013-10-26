using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FinalUI
{
    public partial class Form2 : Form
    {
        public  int view_flag=0;
		public cfeature_vector[] featurein ;
		public cfeature_vector current_features ;
        public double[] distence;
        public static String textRecognised;
        public static String brokenString;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        public void vector_dump(cfeature_vector fetu)
		{
            String path = "C:/OCR/temp/tempVector.txt";
			FileStream filedump=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write) ;

			StreamWriter str=new StreamWriter(filedump);
			for (int i=0;i<6;i++)
			{
				for (int j=0;j<4;j++)
				{
					for (int k=0;k<8;k++)
					{
						str.Write(fetu.tracks[i].sectors[j].relations[k]) ;
						str.Write('v') ;
					}
				}
			}
			str.Close() ;
			filedump.Close() ;

		}

		public void fix_scale()
		{
			double []sum ;
			int h=0 ;
			sum=new double [28] ;

			for (int i=0;i<6;i++)
			{
				for (int j=0;j<4;j++)
				{
					sum[h]=new double() ;
					sum[h]=0 ;
					for (int k=0;k<8;k++)
					{
						sum[h]+=current_features.tracks[i].sectors[j].relations[k] ;
					}
					h++ ;
				
				}
			}
			h=0 ;
			for (int i=0;i<28;i++)
			{
				if (sum[i]==0)
					sum[i]=1 ;
			}


			for (int i=0;i<6;i++)
			{
				for (int j=0;j<4;j++)
				{
					
					for (int k=0;k<8;k++)
					{
						current_features.tracks[i].sectors[j].relations[k]/=sum[h];

					}
					h++ ;
				}
			
			}
        }
		

		public void get_stuff(Bitmap pict,int swtch,int x1, int y1, int x2, int y2)
		{
			
			int counter=0 ;
			double Xctot=0 ;
			double Yctot=0;
			int Xc;
			int Yc ;
			double Rmax=0 ;
			double track_step=0 ;
			cpixel_node [] pixels ;
			//cfeature_vector fetu1 ;
			//get black pixel count
			for (int i=y1;i<y2;i++)
			{
				for (int j=x1;j<x2;j++)
				{
					if (pict.GetPixel(j,i)==Color.FromArgb(0,0,0) )
					{
						counter++ ;
						Xctot+=j ;
						Yctot+=i ;
					}
				}
			}
			Xc=(int)Xctot/counter ;
			Yc=(int)Yctot/counter ;

			pixels=new cpixel_node [counter] ;
			int k=0 ;

			
	
			// get pixels
            for (int i = y1; i < y2; i++)
            {
                for (int j = x1; j < x2; j++)
                {
					if (pict.GetPixel(j,i)==Color.FromArgb(0,0,0) )
					{
						pixels[k]=new cpixel_node() ;
						pixels[k].x=j ;
						pixels[k].y=i ;
						k++ ;
					}
				}
			}
			//get rmx
			double xtot=0 ;
			double ytot=0 ;
			double rmaxtemp ;
			int xrmx=0;
			int yrmx=0;

			for ( int i=0;i<counter;i++)
			{
				xtot=Xc-pixels[i].x ;
				xtot*=xtot ;//squareing
				ytot=Yc-pixels[i].y ;
				ytot*=ytot ;//squareing

				rmaxtemp=xtot+ytot ;
				rmaxtemp=Math.Sqrt(rmaxtemp) ;

				if(rmaxtemp>Rmax)
				{
					Rmax=rmaxtemp ;
					xrmx=pixels[i].x ;
					yrmx=pixels[i].y ;
				}
			}
			track_step=Rmax/5 ;
	

			//get secotrs track elakh
			for ( int i=0;i<counter;i++)
			{
				if( pixels[i].x!=Xc && pixels[i].y!=Yc )
				{
					pixels[i].get_relation(pict) ;
					pixels[i].get_sector(Xc,Yc) ;
					pixels[i].get_track(Xc,Yc,track_step) ;
				}
			}
			//stuff for documentsition
			for ( int i=0;i<counter;i++)
			{
				pict.SetPixel(pixels[i].x,pixels[i].y,Color.Black) ;
			}
			//pict.SetPixel(Xc,Yc,Color.Black) ;
			//pict.SetPixel(xrmx,yrmx,Color.Black) ;
			//pict.Save(destin.Text) ;
            //pict.Save(destin.Text);
			
			//end doc stuf


			current_features=new cfeature_vector() ;
			
				current_features.feature_extractor(pixels,counter) ;
			fix_scale();
			//if (swtch==1)
				//vector_dump(current_features) ;
		}

        public void get_stuff(Bitmap pict, int swtch, int x1, int y1, int x2, int y2, String des,String or)
        {

            int counter = 0;
            double Xctot = 0;
            double Yctot = 0;
            int Xc;
            int Yc;
            double Rmax = 0;
            double track_step = 0;
            cpixel_node[] pixels;
            //cfeature_vector fetu1 ;
            //get black pixel count
            for (int i = y1; i < y2; i++)
            {
                for (int j = x1; j < x2; j++)
                {
                    if (pict.GetPixel(j, i) == Color.FromArgb(0, 0, 0))
                    {
                        counter++;
                        Xctot += j;
                        Yctot += i;
                    }
                }
            }
            Xc = (int)Xctot / counter;
            Yc = (int)Yctot / counter;

            pixels = new cpixel_node[counter];
            int k = 0;



            // get pixels
            for (int i = y1; i < y2; i++)
            {
                for (int j = x1; j < x2; j++)
                {
                    if (pict.GetPixel(j, i) == Color.FromArgb(0, 0, 0))
                    {
                        pixels[k] = new cpixel_node();
                        pixels[k].x = j;
                        pixels[k].y = i;
                        k++;
                    }
                }
            }
            //get rmx
            double xtot = 0;
            double ytot = 0;
            double rmaxtemp;
            int xrmx = 0;
            int yrmx = 0;

            for (int i = 0; i < counter; i++)
            {
                xtot = Xc - pixels[i].x;
                xtot *= xtot;//squareing
                ytot = Yc - pixels[i].y;
                ytot *= ytot;//squareing

                rmaxtemp = xtot + ytot;
                rmaxtemp = Math.Sqrt(rmaxtemp);

                if (rmaxtemp > Rmax)
                {
                    Rmax = rmaxtemp;
                    xrmx = pixels[i].x;
                    yrmx = pixels[i].y;
                }
            }
            track_step = Rmax / 5;


            //get secotrs track elakh
            for (int i = 0; i < counter; i++)
            {
                if (pixels[i].x != Xc && pixels[i].y != Yc)
                {
                    pixels[i].get_relation(pict);
                    pixels[i].get_sector(Xc, Yc);
                    pixels[i].get_track(Xc, Yc, track_step);
                }
            }
            //stuff for documentsition
            for (int i = 0; i < counter; i++)
            {
                pict.SetPixel(pixels[i].x, pixels[i].y, Color.Black);
            }
            //pict.SetPixel(Xc,Yc,Color.Black) ;
            //pict.SetPixel(xrmx,yrmx,Color.Black) ;
            //pict.Save(destin.Text) ;
 
            pict.Save(des);

            //end doc stuf


            current_features = new cfeature_vector();

            current_features.feature_extractor(pixels, counter);
            fix_scale();
            if (swtch == 1)
                vector_dump(current_features);
        }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			
			Application.Run(new Form1());

		}


		public void Contour(Bitmap x, Bitmap x2)
		{
			Color y ;
			String nm="bb" ;
			y=new Color() ;
			for (int i=0;i<x.Width;i++)
			{
				for (int j=0;j<x.Height;j++)
				{
					nm=j.ToString() ;
					tb1.Text =nm ;

					y =x.GetPixel(i,j) ;
					y.ToKnownColor() ;
					//y.Equals(Color.Black) ;
					if (y == Color.FromArgb(0,0,0))
					{
						//x.SetPixel(i,j,Color.Tomato) ;
						if(x.GetPixel(i-1,j-1)==Color.FromArgb(0,0,0)  && x.GetPixel(i-1,j)==Color.FromArgb(0,0,0) && x.GetPixel(i-1,j+1)==Color.FromArgb(0,0,0) && x.GetPixel(i,j-1)==Color.FromArgb(0,0,0) && x.GetPixel(i,j+1)==Color.FromArgb(0,0,0) && x.GetPixel(i+1,j-1) ==Color.FromArgb(0,0,0) && x.GetPixel(i+1,j)==Color.FromArgb(0,0,0)  && x.GetPixel(i+1,j+1)==Color.FromArgb(0,0,0) )
						{
							x2.SetPixel(i,j,Color.White) ;
							
						}
					}
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=false ;
			Bitmap x,x2 ;
			
			if (checkBox1.Checked==true)
			{
				x=new Bitmap(origin.Text) ;
				x2=new Bitmap(origin.Text) ;
				//picBox1.Image=x2 ;
			}
			else
			{
				x=new Bitmap(picBox1.Image) ;
				x2=new Bitmap(picBox1.Image) ;
			}


			Contour(x, x2);
			

			x2.Save(destin.Text) ;


            get_stuff(x2, 1, 0, 0, x.Width, x.Height);
			picBox1.Image=x2 ;

			button1.Enabled=true ;
		}

        public Bitmap starRun(String or)
        {
            button1.Enabled = false;
            Bitmap x, x2;

            //if (checkBox1.Checked == true)
            {
                x = new Bitmap(or);
                x2 = new Bitmap(or);
                // x = new Bitmap(origin.Text);
                // x2 = new Bitmap(origin.Text);
                //picBox1.Image=x2 ;
            }
           /* else
            {
                x = new Bitmap(Image.FromFile(or));
                x2 = new Bitmap(Image.FromFile(or));
            }*/


            Contour(x, x2);

            String des = "C:/OCR/temp/temp.jpg";
            x2.Save(des);


            get_stuff(x2, 1, 0, 0, x.Width, x.Height,des,or);

            featurein = new cfeature_vector[21];
            distence = new double[21];
            for (int i = 0; i < 21; i++)
            {
                featurein[i] = new cfeature_vector();
                string str = "c:/ocr/perm/" + i + ".txt";
                FileStream fileread = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Read);
                feature_read(i, fileread);

                get_distence(featurein[i], i);

                //StreamReader sr = new StreamReader(str);
                fileread.Close();
            }

            // find max
            double max = distence[0];
            int maxi = 0;
            char letter = 'u';
            for (int i = 0; i < 21; i++)
                if (distence[i] < max)
                {
                    maxi = i;
                    max = distence[i];
                }
            switch (maxi)
            {
                case 0: letter = 'A';
                    break;
                case 1: letter = 'B';
                    break;
                case 2: letter = 'C';
                    break;
                case 3: letter = 'D';
                    break;
                case 4: letter = 'E';
                    break;
                case 5: letter = 'F';
                    break;
                case 6: letter = 'G';
                    break;
                case 7: letter = 'H';
                    break;
                case 8: letter = 'I';
                    break;
                case 9: letter = 'J';
                    break;
                case 10: letter = 'K';
                    break;
                case 11: letter = 'L';
                    break;
                case 12: letter = 'M';
                    break;
                case 13: letter = 'N';
                    break;
                case 14: letter = 'O';
                    break;
                case 15: letter = 'P';
                    break;
                case 16: letter = 'Q';
                    break;
                case 17: letter = 'R';
                    break;
                case 18: letter = 'S';
                    break;
                case 19: letter = 'T';
                    break;
                case 20: letter = 'W';
                    break;

            }

            //new char search
            System.IO.StreamReader file = new System.IO.StreamReader("C:/OCR/new/char.txt");
            string line;
            int fileCount = 0;

            if ((line = file.ReadLine()) != null)
            {
                fileCount = line.Length;
            }
            file.Close();

            featurein = new cfeature_vector[fileCount];
            distence = new double[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                featurein[i] = new cfeature_vector();
                string str = "c:/ocr/new/" + i + ".txt";
                FileStream fileread = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Read);
                feature_read(i, fileread);

                get_distence(featurein[i], i);

                //StreamReader sr = new StreamReader(str);
                fileread.Close();
            }

            // find max
            //distence[0] = 100000000;

            double max2;
            if(fileCount==0)
                max2=1000000;
            else
            max2= distence[0];
            int maxi2 = 0;
            char letter2 = 'u';
            for (int i = 0; i < fileCount; i++)
                if (distence[i] < max2)
                {
                    maxi2 = i;
                    max2 = distence[i];
                }


            if (max2 < max)
            {
                char tempLetter = line[maxi2];
                textRecognised = tempLetter.ToString();
            }
            else
                textRecognised = letter.ToString();

            return x2;
        }

		public void feature_read(int pos,FileStream fileread)
		{
			//FileStream fileread=new FileStream(path1.Text,FileMode.OpenOrCreate,FileAccess.Read);
			StreamReader rite=new StreamReader(fileread) ;
			string st1;
			
			
			st1 =rite.ReadToEnd() ;
			
			int i=0,f=0;
			
			string []strVals = st1.Split('v');
			
			for ( i=0;i<6;i++)
			{
				for (int j=0;j<4;j++)
				{
					for (int k=0;k<8;k++)
					{
						double currVal = double.Parse(strVals[f]);
						f++ ;
						featurein[pos].tracks[i].sectors[j].relations[k]=currVal  ;
					}
				}
			}			
							
		rite.Close() ;
		}

		public void get_distence(cfeature_vector vec2,int num)
		{
			double x=0,y=0,z=0,zf=0;

			for (int i=0;i<6;i++)
			{
				for (int j=0;j<4;j++)
				{
					for (int k=0;k<8;k++)
					{
						x=current_features.tracks[i].sectors[j].relations[k];
						y=vec2.tracks[i].sectors[j].relations[k];
						z=x-y ;
						z*=z;
						zf+=z ;


					}
				}
			}
			distence[num]=new double() ;
			distence[num]=zf ;
            
		}

		public void tb1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		
		private void file_read_Click(object sender, System.EventArgs e)
		{
			
			

			#region Delay it Now
			/*for(int h=0;h<st1.Length;h++)
			{
				if (st1[i]!='v')
				{
					st2[j]=st1[i] ;
					j++ ;
				}
				else
				{
					val=int.Parse(st2);
					j=0 ;
					featurein[k].tracks[l].sectors[m].relations[n]=val  ;
					if (n==7)
					{
						n=0;
						if (m==3)
						{
							m=0;
							if (l==5)
							{
								l=0 ;

							}
							else
							{
								l++ ;
								if (k!=maxl-1)
								{
									k++ ;
								}
							}
						}
						else
						{
							m++;
						}
					}
					else
					{
						n++;

					}
				}

				

				

				}*/
			#endregion
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.ShowDialog();
			this.origin.Text = dlg.FileName;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.ShowDialog();
			this.destin.Text = dlg.FileName;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.ShowDialog();
			this.path1.Text = dlg.FileName;
		}

		//not needed
		public void button6_Click(object sender, System.EventArgs e)
		{
			button6.Enabled=false ;
			featurein = new cfeature_vector[21];
			distence=new double [21] ;
			for (int i=0; i<21; i++)
			{
				featurein[i]=new cfeature_vector() ;
				string str ="c:/ocr/"+ i + ".txt";
				FileStream fileread=new FileStream(str,FileMode.OpenOrCreate,FileAccess.Read);
				feature_read(i,fileread);
				
				get_distence(featurein[i],i);

				//StreamReader sr = new StreamReader(str);
				fileread.Close() ;				
			}

			// find max
			double max=distence[0] ;
			int maxi=0 ;
			char letter='u' ;
			for (int i=0;i<21;i++)
				if (distence[i]<max)
				{
					maxi=i ;
					max=distence[i] ;
				}
			switch(maxi)
			{
				case 0:letter='A';
					break ;
				case 1:letter='B';
					break ;
				case 2:letter='C';
					break ;
				case 3:letter='D';
					break ;
				case 4:letter='E';
					break ;
				case 5:letter='F';
					break ;
				case 6:letter='G';
					break ;
				case 7:letter='H';
					break ;
				case 8:letter='I';
					break ;
				case 9:letter='J';
					break ;
				case 10:letter='K';
					break ;
				case 11:letter='L';
					break ;
				case 12:letter='M';
					break ;
				case 13:letter='N';
					break ;
				case 14:letter='O';
					break ;
				case 15:letter='P';
					break ;
				case 16:letter='Q';
					break ;
				case 17:letter='R';
					break ;
				case 18:letter='S';
					break ;
				case 19:letter='T';
					break ;
				case 20:letter='W';
					break ;
				
			}
				
			
			label1.Text=letter.ToString() ;

			button6.Enabled=true ;
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void about1_Click(object sender, System.EventArgs e)
		{
		
		}

		
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void picBox1_Click(object sender, System.EventArgs e)
		{
		
		}
        Point pt ;
		int count =0 ;
		private void picBox1_MouseMove(object sender, MouseEventArgs e)
		{
			Graphics g=Graphics.FromImage(picBox1.Image) ;
			if (e.Button==MouseButtons.Left && count!=0 )
			{
                Pen p=new Pen(Color.Black,10);
				g.FillEllipse(new SolidBrush(Color.Black),pt.X,pt.Y,10,10) ;
				g.FillEllipse(new SolidBrush(Color.Black),e.X,e.Y,10,10) ;

				g.DrawLine(p,pt.X+5,pt.Y+5,e.X+5,e.Y+5);
			}
			pt=new Point(e.X,e.Y) ;
			count=1 ;
			picBox1.Invalidate();
		}

		private void picBox1_MouseUp(object sender, MouseEventArgs e)
		{
			count=0 ;
		}

		private void picBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(picBox1.Image,e.ClipRectangle);
		
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color.Black),picBox1.Location.X-1,picBox1.Location.Y-1,picBox1.Width+1,picBox1.Height+1);
		}

		private void button2_Click_1(object sender, System.EventArgs e)
		{
			picBox1.Image=new Bitmap(picBox1.Width+2,picBox1.Height+2);

		}

        Bitmap change(Bitmap x, int a, int b)
        {
            //label8.Text = "x.width="+x.Width+" x.height="+x.Height+" a,b="+a+","+b;
            
            //if (a >= x.Width-1 || b >= x.Height-1 || a<1 || b<1)
            if (a >= 100 || b >= 100 || a < 1 || b < 1)
            {
             //   listBox1.Items.Add(a.ToString() + " " + b.ToString() + " :(\n");
                return x;
            }
            listBox1.Items.Add(a.ToString() + " " + b.ToString() + " :)\n");
            int i=a;
            int j=b;
            x.SetPixel(i, j, Color.Red);
            if (x.GetPixel(i - 1, j - 1) == Color.FromArgb(0, 0, 0) || x.GetPixel(i - 1, j) == Color.FromArgb(0, 0, 0) || x.GetPixel(i - 1, j + 1) == Color.FromArgb(0, 0, 0) || x.GetPixel(i, j - 1) == Color.FromArgb(0, 0, 0) || x.GetPixel(i, j + 1) == Color.FromArgb(0, 0, 0) || x.GetPixel(i + 1, j - 1) == Color.FromArgb(0, 0, 0) || x.GetPixel(i + 1, j) == Color.FromArgb(0, 0, 0) || x.GetPixel(i + 1, j + 1) == Color.FromArgb(0, 0, 0))
            {
                x.SetPixel(i, j, Color.White);                
            }

            if (j<95)
            {
                change(x, i , j+2);
            }
            else
                change(x, i+2, 2);

            return x;
        }

        public string identify(int x1, int x2, int y1, int y2, Bitmap x, int iii)
        {
            get_stuff(x, 1, x1, y1, x2, y2);

            button6.Enabled = false;
            featurein = new cfeature_vector[21];
            distence = new double[21];
            for (int i = 0; i < 21; i++)
            {
                featurein[i] = new cfeature_vector();
                string str = "c:/ocr/perm/" + i + ".txt";
                FileStream fileread = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Read);
                feature_read(i, fileread);

                get_distence(featurein[i], i);

                //StreamReader sr = new StreamReader(str);
                fileread.Close();
            }

            // find max
            double max = distence[0];
            int maxi = 0;
            char letter = 'u';
            for (int i = 0; i < 21; i++)
                if (distence[i] < max)
                {
                    maxi = i;
                    max = distence[i];
                }
            switch (maxi)
            {
                case 0: letter = 'A';
                    break;
                case 1: letter = 'B';
                    break;
                case 2: letter = 'C';
                    break;
                case 3: letter = 'D';
                    break;
                case 4: letter = 'E';
                    break;
                case 5: letter = 'F';
                    break;
                case 6: letter = 'G';
                    break;
                case 7: letter = 'H';
                    break;
                case 8: letter = 'I';
                    break;
                case 9: letter = 'J';
                    break;
                case 10: letter = 'K';
                    break;
                case 11: letter = 'L';
                    break;
                case 12: letter = 'M';
                    break;
                case 13: letter = 'N';
                    break;
                case 14: letter = 'O';
                    break;
                case 15: letter = 'P';
                    break;
                case 16: letter = 'Q';
                    break;
                case 17: letter = 'R';
                    break;
                case 18: letter = 'S';
                    break;
                case 19: letter = 'T';
                    break;
                case 20: letter = 'W';
                    break;

            }


            //new char search
            System.IO.StreamReader file = new System.IO.StreamReader("C:/OCR/new/char.txt");
            string line;
            int fileCount = 0;

            if ((line = file.ReadLine()) != null)
            {
                fileCount = line.Length;
            }
            file.Close();

            featurein = new cfeature_vector[fileCount];
            distence = new double[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                featurein[i] = new cfeature_vector();
                string str = "c:/ocr/new/" + i + ".txt";
                FileStream fileread = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Read);
                feature_read(i, fileread);

                get_distence(featurein[i], i);

                //StreamReader sr = new StreamReader(str);
                fileread.Close();
            }

            // find max

            double max2 = distence[0];
            int maxi2 = 0;
            for (int i = 0; i < fileCount; i++)
                if (distence[i] < max2)
                {
                    maxi2 = i;
                    max2 = distence[i];
                }
            char tempLetter = line[maxi2];

            if (max2 < max)
                textRecognised = tempLetter.ToString();
            else
                textRecognised = letter.ToString();

            if (iii == 1)
                brokenString += "\n";

            brokenString += "" + textRecognised.ToString();

            return textRecognised.ToString();
        }

        //Not needed
        private void button7_Click(object sender, EventArgs e)
        {
            int gl = 0;
            int last = -1;
            Bitmap x = new Bitmap(picBox1.Image);
            int out1=1;

            for (int j = 0; j < x.Height; j++)
            {
                if (gl == 1)
                {
              //      for (int k = 0; k < x.Width; k++) x.SetPixel(k, j-1, Color.Blue);
                    gl = 0;
                }
                if (last != -1)
                {
                    listBox1.Items.Add(">> now finding char in lines from " + last + " to " + j+" <<");
                    //read this line
                    int bef, aft;
                    bef = 1;
                    aft = 0;
                    int te=0;
                    for (int pix = 0; pix < x.Width; pix++)
                    {
                        int flag = 0;
                        for (int line = last; line < j; line++)
                        {
                            if (bef == 1 && x.GetPixel(pix, line) == Color.FromArgb(0, 0, 0))
                            {
                                int x1, x2, y1, y2;
                             //   for (int k = last; k < j; k++) x.SetPixel(pix - 1, k, Color.Red);
                                listBox1.Items.Add("TL.. "+pix + " "+last+" ");
                                x1 = pix;
                                y1 = last;
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
                                        x2 = pix;
                                        y2 = j-1;
                                        for (int k = x1; k < x2; k++) x.SetPixel(k, y1, Color.Blue);
                                        for (int k = x1; k < x2; k++) x.SetPixel(k, y2, Color.Blue);
                                        for (int k = y1; k < y2; k++) x.SetPixel(x1, k, Color.Blue);
                                        for (int k = y1; k < y2; k++) x.SetPixel(x2, k, Color.Blue);
                                        string c = identify(x1, x2, y1, y2, x,0);
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
                    if(out1==1 && y == Color.FromArgb(0, 0, 0))
                    {
                    //    listBox1.Items.Add(j);
                        if (gl == 0)
                        {
              //              for (int k = 0; k < x.Width; k++) x.SetPixel(k, j - 1, Color.Blue);
                            last = j;
                            gl = 1;
                        }
                        out1 = 0;
                        while(out1==0)
                        {
                            j++;
                         //   listBox1.Items.Add(j);
                            int flag=0;
                            for (int k = 0; i < x.Width; i++)
                                if( x.GetPixel(k,j) == Color.FromArgb(0,0,0))
                                    flag = 1;
                            if(flag==0)
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

            picBox2.Image = x;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }
	}
}
