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
        Button pildid, matemaatika, mäng;
        public kõikMängud()
        {
            this.Size = new System.Drawing.Size(600, 300);
            BackColor = Color.LightCyan;
            pildid = new Button()
            {
                Text = "PildiApp",
                Location = new System.Drawing.Point(100, 125),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            matemaatika = new Button()
            {
                Text = "matemaatika",
                Location = new System.Drawing.Point(250, 125),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LawnGreen,
            };
            mäng = new Button()
            {
                Text = "mäng",
                Location = new System.Drawing.Point(400, 125),
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
