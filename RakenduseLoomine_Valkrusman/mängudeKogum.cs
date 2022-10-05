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
    public partial class mängudeKogum : Form
    {
        public Button nupp,nupp1,nupp2;
            public mängudeKogum( string Nupp)
            {

                this.ClientSize = new System.Drawing.Size(300, 300);
                nupp = new Button
                {
                    Text=Nupp,
                    //Text = "matemaatika",
                    Location = new System.Drawing.Point(30, 50),
                    Size = new System.Drawing.Size(100, 50),
                    BackColor = System.Drawing.Color.AliceBlue,

                };
               

                nupp1 = new Button
                {
                    Text = Nupp,
                    //Text = "mäng",
                    Location = new System.Drawing.Point(50, 50),
                    Size = new System.Drawing.Size(100, 50),
                    BackColor = System.Drawing.Color.AliceBlue,

                };
              

                nupp2 = new Button
                {
                    Text = Nupp,
                    //Text = "Pilt",
                    Location = new System.Drawing.Point(70, 50),
                    Size = new System.Drawing.Size(100, 50),
                    BackColor = System.Drawing.Color.AliceBlue,

                };
                this.Controls.Add(nupp);

            }
        
    }
}
