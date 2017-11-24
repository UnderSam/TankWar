using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public abstract class Element
    {
        private int x;
        public int X
        {
            get{return x;}
            set{x = value;}
        }
        private int y;
        public int Y
        {
            get{return y;}
            set{ y = value;}
        }
        public Element(int x,int y)
        {
            this.x = x;
            this.y= y;
        }
        public abstract void Draw(Graphics g);
    }
}
