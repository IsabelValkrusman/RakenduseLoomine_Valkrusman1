using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace RakenduseLoomine_Valkrusman
{
    public partial class Matemaatika : Form
    {
        PictureBox pictureBox;
        OpenFileDialog openFileDialog;
        Label timeLabel;
        Button close_btn, show_btn, clear_btn;
        TableLayoutPanel tableLayoutPanel;
        NumericUpDown[] vastused = new NumericUpDown[4];//{ summa, lahutamine, jagamine, korrutamine };
        string[,] l_nimed;
        string text;
        string[] tehed = new string[4] { "+", "-", "/", "*" };
        Random random = new Random(10);
        Timer timer = new Timer { Interval = 1000 };
        int[] num1=new int[4];
        int[]num2=new int[4];
       

        public Matemaatika()
        {

            this.Size = new Size(860, 400);

            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 4,

                Location = new System.Drawing.Point(50, 60),
                BackColor = System.Drawing.Color.Cyan

               
            };
            timeLabel = new Label
            {
                Text = "Aega veel",
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(200, 30),
                Font = new Font("Arial", 24, FontStyle.Bold),



            };

            close_btn = new Button
            {
                Text = "Kinni",
            };
            clear_btn = new Button
            {
                Text = "Kustuta",
            };
            show_btn = new Button
            {
                Text = "Näita",
            };
            show_btn.Click += Tegevus;
            clear_btn.Click += Tegevus;
            close_btn.Click += Tegevus;
            Button[] buttons = { clear_btn, show_btn, close_btn };


            string[,] l_nimed = new string[5, 4];
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            this.DoubleClick += Matemaatika_DoubleClick1;
            
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
                for (int j = 0; j < 5; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
                    var l_nimi = "L" + j.ToString() + i.ToString() ;
                    l_nimed[j, i] = l_nimi;
                    if (j == 1) { text = tehed[i]; }
                    else if (j == 3) { text = "="; }
                    //else if(j== 4) { text = "vastus"; }
                    else if (j == 0)
                    {
                        int a = random.Next(10);
                        text = a.ToString();
                        num1[i] = a;
                        
                    }
                    else if (j == 2)
                    {
                        int a = random.Next(10);
                        text = a.ToString();
                        num2[i] =a;
                    }
                     if (j == 4)
                    {
                        vastused[i] = new NumericUpDown 
                        {
                            Name = tehed[i],
                            DecimalPlaces = 2,
                            Minimum=-10
                        };
                        tableLayoutPanel.Controls.Add(vastused[i], j, i);
                    }
                    else
                    {
                        Label l = new Label { Text = text };
                        tableLayoutPanel.Controls.Add(l, j, i);
                    }
                    
                }


            }
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(timeLabel);


        }
        int tik = 0;

        private void Tegevus(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Näita")
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Load(openFileDialog.FileName);
                }
            }
            else if (nupp_sender.Text == "Kustuta")
            {
                pictureBox.Image = null;
            }
            else if (nupp_sender.Text == "Kinni")
            {
                this.Close();
            }
        }

        private void Matemaatika_DoubleClick1(object sender, EventArgs e)
        {
            timer.Start();
            timeLabel.Text = timer.ToString();
            timeLabel.Location = new Point(300, 300);
            tableLayoutPanel.Controls.Add(timeLabel);
        }

        
        private bool Kontroll()
        {
            if (num1[0] + num2[0] == vastused[0].Value 
                && num1[1] - num2[1] == vastused[1].Value 
                && num1[2] / num2[2] == vastused[2].Value 
                && num1[3] * num2[3] == vastused[3].Value)
            {
                return true;

            }
            else { return false; }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tik++;
            timeLabel.Text = tik.ToString();
            if (Kontroll())
            {
                timer.Stop();
                MessageBox.Show("Palju õnne!", "sinu vastused on õiged");
            }
        }
    }
}
