using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public abstract class Member : Element
    {
        public Direction dir;
        private int life;
        private int speed;
        private int width;
        private int height;
        private bool isHitMap = false; 
        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

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

        public bool IsHitMap
        {
            get
            {
                return isHitMap;
            }

            set
            {
                isHitMap = value;
            }
        }

        public Member(int x,int y,int life,int speed,int width,int height,Direction dir)
            :base(x,y)
        {
            this.dir = dir;
            this.life = life;
            this.speed = speed;
            this.width = width;
            this.height = height;
        }

        public abstract void Move();
        
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        public virtual void AdjustDirection()
        {
           
           
                switch (dir)
                {
                    case Direction.up:
                        this.Y -= Speed;
                        break;
                    case Direction.left:
                        this.X -= Speed;
                        break;
                    case Direction.down:
                        this.Y += Speed;
                        break;
                    case Direction.right:
                        this.X += Speed;
                        break;
                }
        }

        
    }
}
