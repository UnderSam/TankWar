using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public abstract class Characters : Member
    {
        public Characters(int x,int y,int life,int width,int height,int speed,Direction dir)
            :base(x,y,life,speed, width,height,dir)
        {

        }
        private int bornTime;
        private bool movable = true;
        public int BornTime
        {
            get
            {
                return bornTime;
            }

            set
            {
                bornTime = value;
            }
        }

        public bool Movable
        {
            get
            {
                return movable;
            }

            set
            {
                movable = value;
            }
        }

        public override void Move()  //預設視窗660  - 坦克寬度60  = 600 
        {
            base.AdjustDirection();
            if (this.X > 600) this.X = 600;
            if (this.X< 0) this.X = 0;
            if (this.Y > 600) this.Y = 600;
            if (this.Y < 0) this.Y = 0;
        }

        public abstract void Fire();
        public abstract void Reborn();
    }
}
