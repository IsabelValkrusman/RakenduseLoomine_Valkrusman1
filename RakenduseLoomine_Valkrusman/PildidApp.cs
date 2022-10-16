using Microsoft.Win32.SafeHandles;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{

    public class PildidApp : Form
    {
        Random random = new Random();
        TableLayoutPanel tableLayoutPanel;
        PictureBox pictureBox;
        CheckBox checkBox;
        SoundPlayer soundPlayer;
        Button close_btn, show_btn, clear_btn, color_btn, zoom_btn;
        FlowLayoutPanel flowLayoutPanel;
        OpenFileDialog openFileDialog;
        ColorDialog colorDialog;
        //private object mouseDownLoc;
        
       

        public PildidApp()
        {
            this.Text = "Pildid";
            this.Size = new System.Drawing.Size(790, 440);
            this.soundPlayer = new SoundPlayer(@"..\..\game.wav");
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files(*.jpg) | *.jpg | PNG Files(*.png) | *.png | BMP Files(*.bmp) | *.bmp | All files(*.*) | *.*";
            colorDialog = new ColorDialog();
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(20, 20),
                TabIndex = 0,
                BackColor = System.Drawing.Color.White,
            };
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));






            pictureBox = new System.Windows.Forms.PictureBox
            {
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TabIndex = 0,
                TabStop = false,
                AutoSize = false,
            };
            pictureBox.DoubleClick += PictureBox_DoubleClick;
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel.SetColumnSpan(pictureBox, 2);

            checkBox = new CheckBox
            {
                Text = "Venita",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            tableLayoutPanel.Controls.Add(checkBox, 1, 0);

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
            color_btn = new Button
            {
                Text = "Vali värv",
        };
            zoom_btn = new Button
            {
                Text = "Zoomi pilt",
            };
            show_btn.Click += Tegevus;
            clear_btn.Click += Tegevus;
            close_btn.Click += Tegevus;
            color_btn.Click += Tegevus;
            zoom_btn.Click += Tegevus;
            playSimpleSound();
            
           
            Button[] buttons = { clear_btn, show_btn, close_btn, color_btn, zoom_btn};
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            flowLayoutPanel.Controls.AddRange(buttons);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);

            this.Controls.Add(tableLayoutPanel);

        }

        ////private void pbMap_MouseMove(object sender, MouseEventArgs e)
        ////{
        ////    if (e.Button == MouseButtons.Left)
        ////    {
        ////        Point currentMousePos = e.Location;
        ////        int distanceX = currentMousePos.X - mouseDownLoc.X;
        ////        int distanceY = currentMousePos.Y - mouseDownLoc.Y;
        ////        int newX = zoom_btn.Location.X + distanceX;
        ////        int newY = zoom_btn.Location.Y + distanceY;

        ////        if (newX + zoom_btn.Image.Width < zoom_btn.Image.Width && zoom_btn.Image.Width + newX > zoom_btn.Width)
        ////            zoom_btn.Location = new Point(newX, zoom_btn.Location.Y);
        ////        if (newY + zoom_btn.Image.Height < zoom_btn.Image.Height && zoom_btn.Image.Height + newY > zoom_btn.Height)
        ////            zoom_btn.Location = new Point(zoom_btn.Location.X, newY);
        ////    }
        ////}


        //private void ZoomIn(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //        zoom_btn = e.Location;
        //}




        private void playSimpleSound()
        {

            this.soundPlayer.Play();
        }
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
            else if (nupp_sender.Text == "Vali värv")
            {
                
                this.Nupp_Click();
            }
            //else if (nupp_sender.Text == "Zoomi pilt")
            //{

            //    if (zoomSlider.Value > 0)
            //    {
            //        zoom_btn.Image = null;
            //        zoom_btn.Image = PictureBoxZoom(imgOriginal, new Size(zoomSlider.Value, zoomSlider.Value));
            //    }
            //}
        }

        private void Nupp_Click()
        {
            int red, green, blue;
            red = random.Next(255);
            green = random.Next(255);
            blue = random.Next(255);
            color_btn.BackColor = Color.FromArgb(red, green, blue);
            BackColor = Color.FromArgb(red, green, blue);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDialog.Color;
        }


    }
}

