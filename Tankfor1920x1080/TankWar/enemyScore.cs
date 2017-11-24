using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public class enemyScore : Element
    {
        private static Image _100 = Resources.score100;
        private static Image _200 = Resources.score200;
        private static Image _300 = Resources.score300;
        private int time = 0;
        public enemyScore(int x,int y,int type)
            :base(x,y)
        {
            this.type = type;
        }
        private int type;

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public override void Draw(Graphics g)
        {
            if (time < 3)
            {
                switch (Type)
                {
                    case 0:
                        g.DrawImage(_100, this.X + time, this.Y + time);
                        break;
                    case 1:
                        g.DrawImage(_200, this.X + time, this.Y + time);
                        break;
                    case 2:
                        g.DrawImage(_300, this.X + time, this.Y + time);
                        break;
                    default: break;
                }
                time++;
            }
            else
            {
                Singleton.Instance.RemoveElement(this);
            }
        }
    }
}
