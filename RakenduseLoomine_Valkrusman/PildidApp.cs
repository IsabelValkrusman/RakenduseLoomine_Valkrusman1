using System;
using System.Drawing;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{

    public class PildidApp : Form1
    {
        TableLayoutPanel tableLayoutPanel;
        FlowLayoutPanel flowLayoutPanel;
        PictureBox pictureBox;
        PictureBox pilt;
        CheckBox checkBox;
        Button clear_btn;
        Button show_btn;
        Button close_btn;
        OpenFileDialog openFileDialog;
        int x = 150;
        int y = 450;

        public PildidApp()
        {
            this.Text = "Pildid";
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,

                Location = new System.Drawing.Point(20, 0),
                Size =new System.Drawing.Size(300, 400),

                

                TabIndex = 0,
                BackColor = System.Drawing.Color.White,
            };

            this.Controls.Add(tableLayoutPanel);

            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 15f));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 85f));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 90f));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 10f));
            this.tableLayoutPanel.ResumeLayout(false);


            //this.pilt = new PictureBox
            //{
            //    Image = new Bitmap(@"..\..\france.jpg"),
            //    Location = new Point(x, y),
            //    Size = new Size(100, 100),
            //    SizeMode = PictureBoxSizeMode.Zoom
            //};


            this.pilt = new PictureBox
            {
                Image = new Bitmap(@"..\..\france.jpg"),
                Location = new Point(x, y),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.tableLayoutPanel.Controls.Add(pilt, 10, 0);
            this.tableLayoutPanel.SetCellPosition(pilt, new TableLayoutPanelCellPosition(0, 0));
            this.tableLayoutPanel.SetColumnSpan(pilt, 2);

            this.pictureBox = new System.Windows.Forms.PictureBox
            {

                Image = new Bitmap(@"..\..\france.jpg"),

                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TabIndex = 0,
                TabStop = false,
            };
            this.tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            this.tableLayoutPanel.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(0, 0));
            this.tableLayoutPanel.SetColumnSpan(pictureBox, 2);


            this.checkBox = new CheckBox
            {
                Text = "Venita",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            this.tableLayoutPanel.Controls.Add(checkBox, 1, 0);
            this.Controls.Add(tableLayoutPanel);


            this.close_btn = new Button
            {
                Text = "Pane Kinni",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            this.clear_btn = new Button
            {
                Text = "Näita",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            this.show_btn = new Button
            {
                Text = "Näita",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };

            this.show_btn.Click += Tegevus;
            this.clear_btn.Click += Tegevus;
            this.close_btn.Click += Tegevus;
            Button[] buttons = { clear_btn, show_btn, close_btn };
            this.flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,
                AutoScroll = true,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(300, 50),
            };
            foreach (Button button in buttons)
            {
                this.flowLayoutPanel.Controls.Add(button);
            }
            this.tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 0);

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
            else if (nupp_sender.Text == "kustuta")
            {
                pictureBox.Image = null;
            }
            else if (nupp_sender.Text == "kinni")
            {
                this.Close();
            }
        }
    }
}

