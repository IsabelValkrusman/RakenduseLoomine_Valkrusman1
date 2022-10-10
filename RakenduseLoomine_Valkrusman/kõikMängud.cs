using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{
    public partial class kõikMängud : Form
    {
        TreeView puu;
        Button pildid, matemaatika, mäng;
        TextBox tekst;
     

        public kõikMängud()
        {
            this.Size = new System.Drawing.Size(300, 500);
            BackColor = Color.LightCyan;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            oksad.Nodes.Add(new TreeNode("Info"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);

            if (e.Node.Text == "info")
            {
                tekst = new TextBox
                {
                    Font = new Font("Arial", 34, FontStyle.Italic),
                    Location = new Point(350, 400),
                    Enabled = false
                };
                // tekst.DoubleClick += Tekst_DoubleClick;
                this.Controls.Add(tekst);
            }

            pildid = new Button()
            {
                Text = "PildiApp",
                Location = new System.Drawing.Point(100, 150),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            matemaatika = new Button()
            {
                Text = "matemaatika",
                Location = new System.Drawing.Point(100, 200),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            mäng = new Button()
            {
                Text = "mäng",
                Location = new System.Drawing.Point(100, 250),
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
