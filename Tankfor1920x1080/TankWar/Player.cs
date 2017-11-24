using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar
{
    public abstract class Player : Characters
    {
        private int tag;
        private Image[] img = new Image[] { };
        protected bool isUp = false, isDown = false, isLeft = false, isRight = false;
        protected bool isMove = false;
        private int tpower = 0;
        private bool penatrate = false;
        private int tankType = 0;
        private int fireCount = 0;
        public Player(int x,int y,Image[] img,int speed,int life,Direction dir,int tag)
            :  base(x,y,life,img[0].Width,img[0].Height, speed, dir)
        {
            this.img = img;
            this.Tag = tag;
            Reborn();
        }
        private int islive = 2; //兩條命
        public int IsLive
                {
                    get
                    {
                        return islive;
                    }

                    set
                    {
                        islive = value;
                    }
                }

        public int Tpower
        {
            get
            {
                return tpower;
            }

            set
            {
                tpower = value;
            }
        }

        public bool Penatrate
        {
            get
            {
                return penatrate;
            }

            set
            {
                penatrate = value;
            }
        }

        public int TankType
        {
            get
            {
                return tankType;
            }

            set
            {
                tankType = value;
            }
        }

        public int Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }

        public int FireCount
        {
            get
            {
                return fireCount;
            }

            set
            {
                fireCount = value;
            }
        }

        public override void AdjustDirection()
        {
            if (isUp && !isDown && !isLeft && !isRight)
            {
                dir = Direction.up;
            }
            else if (!isUp && isDown && !isLeft && !isRight)
            {
                dir = Direction.down;
            }
            else if (!isUp && !isDown && isLeft && !isRight)
            {
                dir = Direction.left;
            }
            else if (!isUp && !isDown && !isLeft && isRight)
            {
                dir = Direction.right;
            }
        }

        public override void Move()
        {
            if (!isMove)
                return;
            
            base.Move();
        }

        public override void Draw(Graphics g)
        {
            if(BornTime<48)
            {
                BornTime++;
                return;
            }
            if (islive < 0)  // 都死了 不在畫坦克
                return;
            Move();
            switch(dir)
            {
                case Direction.up:
                    g.DrawImage(img[(4 * TankType) + 0], this.X, this.Y);
                    break;
                case Direction.left:
                    g.DrawImage(img[(4 * TankType) + 1], this.X, this.Y);
                    break;
                case Direction.down:
                    g.DrawImage(img[(4 * TankType) + 2], this.X, this.Y);
                    break;
                case Direction.right:
                    g.DrawImage(img[(4 * TankType) + 3], this.X, this.Y);
                    break;
            }
        }
        public override void Fire()
        {
           
            switch (Tag) {
                case 0:
                    switch (Tpower)
                    {
                        case 0:
                            Singleton.Instance.AddElement(new myBullet(this, 1, 10, 1, tankType));
                            break;
                        case 1:
                            Singleton.Instance.AddElement(new myBullet(this, 1, 14, 2, tankType));
                            break;
                        case 2:
                            Singleton.Instance.AddElement(new myBullet(this, 1, 18, 3, tankType));
                            break;
                        default: break;
                    }
                    break;
                case 1:
                    switch (Tpower)
                    {
                        case 0:
                            Singleton.Instance.AddElement(new P2Bullet(this, 1, 10, 1, tankType));
                            break;
                        case 1:
                            Singleton.Instance.AddElement(new P2Bullet(this, 1, 14, 2, tankType));
                            break;
                        case 2:
                            Singleton.Instance.AddElement(new P2Bullet(this, 1, 18, 3, tankType));
                            break;
                        default: break;
                    }
                    break;
                }
        }
        public void isDead()
        {
            if (islive == 0 && Life<=0)
            {
                Singleton.Instance.AddElement(new Bomb(this.X - 25, this.Y - 25));
                islive = -1;
                return;
            }
            if(this.Life<=0 && islive !=0)
            {
                BornTime = 0;
                Singleton.Instance.AddElement(new Bomb(this.X - 25, this.Y - 25));
                //Singleton.Instance.SingleIsOver = true;
                islive--;
                Reborn();
                if (islive>0)
                {
                    this.Life++;
                }
            }
        }
    }
}
