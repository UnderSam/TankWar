using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    class Born : Element
    {
        private int bornTimer = 0;
        private static Image[] shiny = new Image[]
        {
            Resources.born1,
            Resources.born2,
            Resources.born3,
            Resources.born4,
        };
        public Born(int x,int y)
            :base(x,y)
        { }
        public override void Draw(Graphics g)
        {
            if (bornTimer < 48)  // 做出閃爍效果
            {
                switch (bornTimer % 8)
                {
                    case 0:
                    case 1:
                        g.DrawImage(shiny[0], this.X, this.Y);
                        break;
                    case 2:
                    case 3:
                        g.DrawImage(shiny[1], this.X, this.Y);
                        break;
                    case 4:
                    case 5:
                        g.DrawImage(shiny[2], this.X, this.Y);
                        break;
                    case 6:
                    case 7:
                        g.DrawImage(shiny[3], this.X, this.Y);
                        break;
                }
                bornTimer++;
            }
        }
    }
}
