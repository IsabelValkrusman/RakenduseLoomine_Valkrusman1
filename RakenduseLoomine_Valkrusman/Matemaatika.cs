using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
        SoundPlayer soundPlayer;
        OpenFileDialog openFileDialog;
        Label timeLabel;
        Button close_btn, show_btn, clear_btn, uued_tehted;
        TableLayoutPanel tableLayoutPanel;
        NumericUpDown[] vastused = new NumericUpDown[4];//{ summa, lahutamine, jagamine, korrutamine };
        string[,] l_nimed = new string[5, 4];
        string text;
        string[] tehted = new string[4] { "+", "-", "/", "*" };
        Random random = new Random(10);
        Timer timer = new Timer { Interval = 1000 };
        int[] num1=new int[4];
        int[]num2=new int[4];
       

        public Matemaatika()
        {

            this.Size = new Size(860, 400);
            this.soundPlayer = new SoundPlayer(@"..\..\game.wav");
            BackColor = Color.LightGreen;
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
                Location = new System.Drawing.Point(600, 250)
            };
            clear_btn = new Button
            {
                Text = "Kustuta",
            };
            show_btn = new Button
            {
                Text = "Näita",
            };

            uued_tehted = new Button
            {
                Text = "Uued tehted",
                Location = new System.Drawing.Point(700, 250)
            };
            show_btn.Click += Tegevus;
            clear_btn.Click += Tegevus;
            close_btn.Click += Tegevus;
            uued_tehted.Click += Tegevus;
            Button[] buttons = { clear_btn, show_btn, close_btn };

            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            this.DoubleClick += Matemaatika_DoubleClick1;

            playSimpleSound();
            Loo_Tehted(); 
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(timeLabel);
            this.Controls.Add(uued_tehted);
            this.Controls.Add(close_btn);
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
                soundPlayer.Stop();
                this.Close();
            }
            else if (nupp_sender.Text == "Uued tehted")
            { 
                Loo_Tehted();
                tik = 0;
            }
        }

        private void playSimpleSound()
        {

            this.soundPlayer.Play();
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

        private void Loo_Tehted()
        {
            Kustuta_Vanad();
            for (int rida = 0; rida < 4; rida++)
            {
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
                for (int tulp = 0; tulp < 5; tulp++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
                    var l_nimi = "L" + tulp.ToString() + rida.ToString();
                    this.l_nimed[tulp, rida] = l_nimi;
                    if (tulp == 1) {
                        text = tehted[rida]; 
                    }
                    else if (tulp == 3) { 
                        text = "="; 
                    }
                 
                    else if (tulp == 0)
                    {
                        int a = random.Next(10);
                        text = a.ToString();
                        num1[rida] = a;

                    }
                    else if (tulp == 2)
                    {
                        int a = random.Next(10);
                        text = a.ToString();
                        num2[rida] = a;
                    }
                    if (tulp == 4)
                    {
                        vastused[rida] = new NumericUpDown
                        {
                            Name = tehted[rida],
                            DecimalPlaces = 2,
                            Minimum = -10
                        };
                        tableLayoutPanel.Controls.Add(vastused[rida], tulp, rida);
                    }
                    else
                    {
                        Label l = new Label { Text = text };
                        tableLayoutPanel.Controls.Add(l, tulp, rida);
                    }

                }


            }
        }

        private void Kustuta_Vanad()
        {
            while (this.tableLayoutPanel.Controls.Count > 0)
            {
                this.tableLayoutPanel.Controls[0].Dispose();
            }
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
