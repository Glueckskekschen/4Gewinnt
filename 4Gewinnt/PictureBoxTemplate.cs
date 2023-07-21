using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{
    internal class PictureBoxTemplate:PictureBox
    {
        //Yellow = 1 / Red = 2 / Nothing = 0
        public char owner= '0';
        public bool isSet = false;
        public int index;

        public PictureBoxTemplate(int index, int x, int y, int width, int height)
        {
            this.Name = "PB_" + index;
            this.index = index;
            this.Size = new Size(width, height);
            this.Image = _4Gewinnt.Properties.Resources.empty;
            this.Location= new Point(x,y);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnClick(EventArgs e)
        {
            
            if(Rule.isTurnValid(this.index))
            {
                
            }
            
        }

        public void MakeYellow()
        {
            this.Image = _4Gewinnt.Properties.Resources.yellow;
            
        }

        public void MakeRed()
        {
            this.Image = _4Gewinnt.Properties.Resources.red;
        }
    }
}
