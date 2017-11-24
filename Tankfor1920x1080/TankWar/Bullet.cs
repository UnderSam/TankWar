using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public abstract class Bullet : Member
    {
        public int power;
        public Bullet(Characters whos,int life,int width,int height,int speed,int power)
            :base(whos.X+whos.Width/2-6,whos.Y+whos.Height/2-6,life,speed,width,height,whos.dir)
        {
            this.power = power;
        }
        public override void Move()
        {
            if(this.X>660 || this.X<0 || this.Y>660 || this.Y<0)
            {
                this.Life = 0;
                Singleton.Instance.RemoveElement(this);
            }
            AdjustDirection();
        }
    }
}
