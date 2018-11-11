using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Yamb.Modeli;

namespace Yamb
{
    public partial class Form1 : Form
    {
        TextBox[,] textbox = new TextBox[16, 8];
        int i, j;
        System.Timers.Timer t;
        int h, m, s;

        public Form1()
        {
            InitializeComponent();
        }

        private void generisanjePolja()
        {
            Point p;
            p = new Point(5, 5);

            int a = p.X;  //koordinata X
            int b = p.Y;  //koordinata Y

            //if ((textBox1.Text == "") || (textBox2.Text == ""))
            //    MessageBox.Show(" To create a Matrices you need to give up the numbers of columns and rows.,"opps",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //else
            //{
            //    n = Convert.ToInt32(textBox1.Text);// Take the value N -Rows
            //    m = Convert.ToInt32(textBox2.Text);// Take the value M-Columns
            //}

            int[,] matrica;
            int n = 1;

            matrica = new int[16, 8];
            
            for (i = 0; i < 16; i++)
            {
                a = p.X + 35;   //polja ce biti na koordinti X 
                b = b + 25; //kordinata b je promenjena dodavanjem 25 pixela, pa ce polje biti dodato 25 pixela ispod pocetne koordinate

                for (j = 0; j < 8; j++)
                {
                    textbox[i, j] = new TextBox();  //kreira se novo TextBox polje, kreiranje polja ce se nastavljati dok se sve kolone i redovi ne popune

                    string nameOfBox = "A" + Convert.ToString(i);   //setujemo ime TextBox-ovima

                    textbox[i, j].Name = nameOfBox; //dodeljujemo setovano ime jednom redu TextBox-ova, tako da sva polja u jednom redu imaju isti parametar Name
                    textbox[i, j].TextAlign = HorizontalAlignment.Center;
                    textbox[i, j].MaxLength = 3;
                    textbox[i, j].Tag = n;
                    a = a + 30; //promena koordinate X, i na svakih 30 pixela ce biti sledece polje
                    textbox[i, j].Width = 25;
                    textbox[i, j].Height = 25;
                    textbox[i, j].Location = new Point(a, b + 30);  //polja dobijaju lokaciju gde ce biti nalepljena

                    this.Controls.Add(textbox[i, j]);
                    n++;
                    if (textbox[i, j].Name == "A6" || textbox[i, j].Name == "A9" || textbox[i, j].Name == "A15")
                    {
                        textbox[i, j].ReadOnly = true;
                        textbox[i, j].TabStop = false;
                    }
                    textbox[i, j].TextChanged += new EventHandler(TextChange);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generisanjePolja();
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                timerTbox.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }

        public void TextChange(Object sender, EventArgs e)
        {
            //racunanje sume gorenjeg dela forme
            int znj = (int)((TextBox)sender).Tag;
            
            int sum = 0;
            //prvo ide petlja za j pa za i, prolazi se po kolonama a ne redovima zbog zbira
            for (int j = 0; j < 8; j++)
            {
                if (j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                {
                    sum = 0;
                }
                for (int i = 0; i <= 6; i++)
                {
                    if (!String.IsNullOrWhiteSpace(textbox[i, j].Text))
                    {
                        sum += Int32.Parse(textbox[i, j].Text);
                        if (i == 5)
                        {
                            if (sum >= 90)
                            {
                                sum += 30;
                                textbox[i + 1, j].Text = sum.ToString();
                            }
                            else
                                textbox[i + 1, j].Text = sum.ToString();
                        }
                    }
                }
            }
        }
    }
}
