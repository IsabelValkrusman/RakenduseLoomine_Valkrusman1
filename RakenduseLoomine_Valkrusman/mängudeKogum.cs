using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{
    public partial class mängudeKogum: Form
    {
        FlowLayoutPanel flowLayoutPanel;
        Button close_btn;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "?", "?", "k", "k", "v", "v", "u", "u",
            "e", "e", "a", "a", "t", "t", "n", "n"
        };
        TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
        Label lbl1;
        int r = 0;//rida
        int t = 0;//tulp
        int maksimumKatseid = 10;
        int praegusedKatsed = 0;
        Dictionary<string, bool> leitudPaarid = new Dictionary<string, bool>();
        public Timer timer = new Timer { Interval = 500 };//aeg pildi paari leidmiseks

        Label firstClicked = null;
        Label secondClicked = null;

        public mängudeKogum()
        {
            this.Size = new System.Drawing.Size(900, 900);
            this.Text = "Mäng - leia pildi paar";
            this.MaximizeBox = false;

            tableLayoutPanel1 = new TableLayoutPanel()
            {
                ColumnCount = 4,
                Location = new System.Drawing.Point(3, 4),
                RowCount = 4,
                Size = new System.Drawing.Size(550, 550),
                TabIndex = 0,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                BackColor = System.Drawing.Color.CornflowerBlue,
            };
            close_btn = new Button
            {
                Text = "Kinni",
            };
            close_btn.Click += Tegevus;
            Button[] buttons = {close_btn};

            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            flowLayoutPanel.Controls.AddRange(buttons);
          




            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.Controls.Add(this.tableLayoutPanel1);


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),//näitab kujukesed tähtede asemel
                        Text = "c",
                    };
                    tableLayoutPanel1.Controls.Add(lbl1, r, t);
                    r++;

                }
                t++;
                r = 0;
            }
            foreach(string kaart in icons) // märgime kõik paarid kui mitte leitud
            {   
                if(!leitudPaarid.ContainsKey(kaart))
                {
                    leitudPaarid.Add(kaart, false);
                }
                
            }

            foreach (Control control in tableLayoutPanel1.Controls)//ikoonide randoomne lisamine
            {
                Label iconLabel1 = control as Label;
                if (iconLabel1 != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel1.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel1.ForeColor = iconLabel1.BackColor;
                iconLabel1.Click += Lbl1_Click;
            }
            timer.Tick += Timer_Tick;
        }

        private void Tegevus(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Kinni")
            {
                this.Close();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        private void Lbl1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                if (firstClicked.Text == secondClicked.Text)
                {
                    leitudPaarid[firstClicked.Text] = true;
                    firstClicked = null;
                    secondClicked = null;
                    CheckForWinner();
                    return;
                } else
                {
                    praegusedKatsed += 1;
                    CheckForWinner();
                }
                timer.Start();
                
            }
        }
        public void CheckForWinner()
        {
            bool koikLeitud = false;
            foreach (var item in leitudPaarid) 
            {
              bool leitud = item.Value;
              if(!leitud)
                {
                    if (this.praegusedKatsed < this.maksimumKatseid)
                    {
                        koikLeitud = false;
                        break;
                    } else
                    {
                        MessageBox.Show("Mäng läbi - liiga palju katseid", ":[");
                        break;
                    }
                } else
                {
                   koikLeitud = true;
                }
              
            }
            if (koikLeitud)
            {
                MessageBox.Show("Leitud on kõik paarid! ", "Palju õnne!");
            }
        }
    }
}
