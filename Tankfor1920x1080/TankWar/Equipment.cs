using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    class Equipment : Module
    {
       
        private static Image imgStar = Resources.star;
        private static Image imgTimer = Resources.time;
        private static Image imgGrenade = Resources.grenade;
        private static Image imgUpgrate = Resources.upgrate;
        private static Image imgPistol = Resources.pistol;
        
        private int flag;

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public Equipment(int x,int y,int flag)
            :base(x,y,imgStar.Width,imgStar.Height)
        {
            this.flag = flag;
        }

        public override void Draw(Graphics g)
        {
            if (Singleton.Instance.PlayerNum == 1)
            {
                switch (flag)
                {
                    case 0:
                        g.DrawImage(imgStar, this.X, this.Y);
                        break;
                    case 1:
                        g.DrawImage(imgGrenade, this.X, this.Y);
                        break;
                    case 2:
                        g.DrawImage(imgTimer, this.X, this.Y);
                        break;
                    case 3:
                        g.DrawImage(imgPistol, this.X, this.Y);
                        break;
                    case 4:
                        g.DrawImage(imgUpgrate, this.X, this.Y);
                        break;
                    default: break;
                }
            }
            else if (Singleton.Instance.PlayerNum == 2)
            {
                switch (flag)
                {
                    case 5:
                        g.DrawImage(imgStar, this.X, this.Y);
                        break;
                    case 6:
                        g.DrawImage(imgPistol, this.X, this.Y);
                        break;
                    case 7:
                        g.DrawImage(imgUpgrate, this.X, this.Y);
                        break;
                    default: break;
                }
            }
        }

    }
}
