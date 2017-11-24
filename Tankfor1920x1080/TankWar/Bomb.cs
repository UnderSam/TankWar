using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    class Bomb : Element
    {
        private int count = 0;
        private static Image[] bimg = new Image[]
        {
            Resources.Little_die1,
            Resources.Little_die2,
            Resources.Little_die3,
        };
        public Bomb(int x, int y)
            :base(x,y)
        {
        }
        public override void Draw(Graphics g)
        {
            if(count <bimg.Length)
            {
                g.DrawImage(bimg[count],this.X, this.Y);
                count++;
            }
            else
            {
                Singleton.Instance.RemoveElement(this);
            }
        }

    }
}
