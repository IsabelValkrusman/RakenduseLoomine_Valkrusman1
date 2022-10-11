using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{
    public partial class kõikMängud : Form
    {
        TreeView puu;
        Button pildid, matemaatika, mäng;
        TextBox tekst;
        Label silt;


        public kõikMängud()
        {
            Height = 600;
            Width = 1100;
            Text = "Kolm erinevat mängu ja informatsioon nende kohta";
            BackColor = Color.LightBlue;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Informatsioon mängude kohta");
            oksad.Nodes.Add(new TreeNode("PildiApp"));
            oksad.Nodes.Add(new TreeNode("Matemaatika"));
            oksad.Nodes.Add(new TreeNode("Mäng"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            puu.DoubleClick += Puu_DoubleClick;
            this.Controls.Add(puu);
           
            pildid = new Button()
            {
                Text = "PildiApp",
                Location = new System.Drawing.Point(130, 100),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            matemaatika = new Button()
            {
                Text = "matemaatika",
                Location = new System.Drawing.Point(130, 200),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            mäng = new Button()
            {
                Text = "mäng",
                Location = new System.Drawing.Point(130, 300),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            pildid.Click += Pildid_Click;
            matemaatika.Click += Matemaatika_Click;
            mäng.Click += mäng_Click;
            this.Controls.Add(pildid);
            this.Controls.Add(matemaatika);
            this.Controls.Add(mäng);

            


        }
        private void Puu_DoubleClick(object sender, EventArgs e)
        {
            if (tekst.Enabled)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
            

        }
        bool t = false;

        private void Tekst_DoubleClick(object sender, EventArgs e)
        {
            if (t)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }




        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            silt = new Label
            {
                Text = "Minu esimene vorm",
                Size = new Size(100, 20),
                Location = new Point(200, 0)
            };


            if (e.Node.Text == "info")
            {
                tekst = new TextBox
                {
                    Font = new Font("Arial", 34, FontStyle.Italic),
                    Location = new Point(130, 100),
                    Enabled = false
                };
                 tekst.DoubleClick += Puu_DoubleClick;
                this.Controls.Add(tekst);
            }

            else if (e.Node.Text == "PildiApp")
            {
                tekst = new TextBox
                {
                    
                    
                    Text = "Vali enda pilt, ja võid venitada ja kustutada seda!",
                    Width=800,
                    Height=200,
                    Font = new Font("Arial", 15, FontStyle.Italic),
                    Location = new Point(130, 150),
                    Enabled = false
                };
                 tekst.DoubleClick += Puu_DoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "Matemaatika")
            {
                tekst = new TextBox
                {


                    Text = "Lahenda teheid, ja kui ei saa hakkama siis vajuta nuppu ja saad teised tehed!",
                    Width=800,
                    Height=200,
                    Font = new Font("Arial", 15, FontStyle.Italic),
                    Location = new Point(130, 250),
                    Enabled = false
                };
                 tekst.DoubleClick += Puu_DoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "Mäng")
            {
                tekst = new TextBox
                {

                    //TextBox.Size = new Size(228, 25),
                    Text = "Leia õige paar, sul on ainult 10 katset!",
                    Width=800,
                    Height=200,
                    Font = new Font("Arial", 15, FontStyle.Italic),
                    Location = new Point(130, 350),
                    Enabled = false
                };
                 tekst.DoubleClick += Puu_DoubleClick;
                this.Controls.Add(tekst);
            }
        }

        private void mäng_Click(object sender, EventArgs e)
        {
            mängudeKogum Parid = new mängudeKogum();
            Parid.ShowDialog();
        }

        private void Matemaatika_Click(object sender, EventArgs e)
        {
            Matemaatika Matem = new Matemaatika();
            Matem.ShowDialog();
        }

        private void Pildid_Click(object sender, EventArgs e)
        {
         PildidApp PildidApp= new PildidApp();
            PildidApp.ShowDialog();
        }
    }
}
