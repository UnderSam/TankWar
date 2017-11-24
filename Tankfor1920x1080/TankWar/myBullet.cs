using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public class myBullet : Bullet
    {
        private static Image mbullet = Resources.bullet1;
        private static Image mbullet2 = Resources.bullet2;
        private static Image mbullet3 = Resources.bullet3;
        private int bullTpye;
        public myBullet(Characters whos,int life,int speed,int power,int Btype)
            :base(whos,life,mbullet.Width,mbullet.Height,speed,power)
        {
            BullTpye = Btype;
        }

        public int BullTpye
        {
            get
            {
                return bullTpye;
            }

            set
            {
                bullTpye = value;
            }
        }

        public override void Draw(Graphics g)
        {
            base.Move();
            switch (BullTpye) {
                case 0:
                    g.DrawImage(mbullet, this.X, this.Y);
                    break;
                case 1:
                    g.DrawImage(mbullet2, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(mbullet3, this.X, this.Y);
                    break;
                default:
                    g.DrawImage(mbullet3, this.X, this.Y);
                    break;
            }
        }
    }
}
