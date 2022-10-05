using System;
using System.Drawing;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{

    public class PildidApp : Form
    {
        TableLayoutPanel tableLayoutPanel;
        PictureBox pictureBox;
        CheckBox checkBox;
        Button close_btn, show_btn, clear_btn;
        FlowLayoutPanel flowLayoutPanel;
        OpenFileDialog openFileDialog;
        ColorDialog colorDialog;
        public PildidApp()
        {
            this.Text = "Pildid";
            this.Size = new System.Drawing.Size(790, 440);
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
            show_btn.Click += Tegevus;
            clear_btn.Click += Tegevus;
            close_btn.Click += Tegevus;
            Button[] buttons = { clear_btn, show_btn, close_btn };
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

