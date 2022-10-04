using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RakenduseLoomine_Valkrusman
{
    public partial class mäng : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Random random = new Random(10);
        Icon icons;
        


        public mäng()
        {
            this.Size = new Size(860, 400);

            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 4,

                Location = new System.Drawing.Point(400, 60),
                BackColor = System.Drawing.Color.White


            };
            this.Controls.Add(tableLayoutPanel);

               
           
        }
        

        private void AssignIconsToSquares()
        {
           
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

    }
}
