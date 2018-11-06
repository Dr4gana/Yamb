using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yamb.Modeli;

namespace Yamb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextBox[,] textbox = new TextBox[16, 8];
        int i, j;

        private void generisanjePolja()
        {
            Point merlokacionin;// This take the location in form . We have added a label with no text just to take the location and under it to add fields.
            merlokacionin = new Point(5, 5);
            int a = merlokacionin.X;//The coordinate X of the label we give to the int variable a

            int b = merlokacionin.Y;//The coordinate Y

            //if ((textBox1.Text == "") || (textBox2.Text == ""))
            //    MessageBox.Show(" To create a Matrices you need to give up the numbers of columns and rows.,"opps",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //else
            //{
            //    n = Convert.ToInt32(textBox1.Text);// Take the value N -Rows
            //    m = Convert.ToInt32(textBox2.Text);// Take the value M-Columns
            //}

            int[,] Matrica;

            Matrica = new int[16, 8];
            int n = 1;
            for (i = 0; i < 16; i++)
            {
                a = merlokacionin.X + 10; // fields will be at coordinate X 
                b = b + 27;// the coordinate of b is changed with adding in 30 points , so the //field will be added in  30 points under the label1.

                for (j = 0; j < 8; j++)
                {
                    textbox[i, j] = new TextBox();    //  it create the new //textbox field, the creating fields will continue while as we have the //columns and rows.

                    string emriTextBox = "A" + Convert.ToString(i);//We set the name for textbox


                    textbox[i, j].Name = emriTextBox; //give name to textbox
                    textbox[i, j].Tag = n;
                    a = a + 30;// change the coordinate of X and every 25 points will be the next field                    
                    textbox[i, j].Width = 25;
                    textbox[i, j].Height = 25;
                    textbox[i, j].Location = new Point(a, b + 30);//Now the field take the location where it will be pasted.

                    this.Controls.Add(textbox[i, j]);
                    n++;
                    if (textbox[i, j].Name == "A6")
                    {
                        textbox[i, j].BackColor = Color.LightGreen;

                    }
                    textbox[i, j].TextChanged += new EventHandler(LeaveTextBox);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            generisanjePolja();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ModelContext mc = new ModelContext();
            Igrac i = new Igrac() { UserName = textBox1.Text,
                                    Password = textBox2.Text,
                                    Mail = textBox3.Text };

            mc.Igraci.Add(i);
            await mc.SaveChangesAsync();
        }

        public void LeaveTextBox(Object sender, EventArgs e)
            {
                int znj = (int)((TextBox)sender).Tag;

                var sum = new[] { textbox[0, 0], textbox[1, 0], textbox[2, 0], textbox[3, 0], textbox[4, 0], textbox[5, 0] }
                                                .Select(tb => tb.Text)
                                                .Where(s => !String.IsNullOrWhiteSpace(s))
                                                .Sum(s => Int32.Parse(s));

                if (sum >= 90)
                    sum += 30;
                textbox[6, 0].Text = sum.ToString();
            }
        }
    }
