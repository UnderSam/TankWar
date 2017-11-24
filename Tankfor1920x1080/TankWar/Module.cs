using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public abstract class Module : Element
    {
        private int width;
        private int height;

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public Module(int x,int y,int width,int height)
            :base(x,y)
        {
            this.width = width;
            this.height = height;
        }

        public  Rectangle getRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
