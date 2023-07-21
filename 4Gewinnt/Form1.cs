using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{
    public partial class Form1 : Form
    {
        //private List<PictureBoxTemplate> cell;
        private int iSizeOfAll = 100;

        public Form1()
        {            
            InitializeComponent();
            this.Width = iSizeOfAll * 7 + 15;
            this.Height = iSizeOfAll * 6 + 38;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBoxTemplate item in Rule.cell)
            {
                Controls.Add(item);
                item.Show();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width > this.Height)
            {
                iSizeOfAll = (this.Height -38) / 6;
            }
            else
            {
                iSizeOfAll = ((this.Width -15) /7);
            }

            int counter = 0;
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Rule.cell[counter].Location = new Point(x* iSizeOfAll, y* iSizeOfAll);
                    Rule.cell[counter].Width= iSizeOfAll;
                    Rule.cell[counter].Height = iSizeOfAll;
                    counter++;
                }
            }
        }
    }
}
