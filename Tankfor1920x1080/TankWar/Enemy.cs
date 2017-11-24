using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public class Enemy : Characters
    {
        
        private static Image[] E1Tank = new Image[] {   //100
            Resources.green1,
            Resources.green2,
            Resources.green3,
            Resources.green4
        };
        private static Image[] E2Tank = new Image[] {  //200
            Resources.pink1,
            Resources.pink2,
            Resources.pink3,
            Resources.pink4
        };
        private static Image[] E3Tank = new Image[] {  //300
            Resources.yellow1,
            Resources.yellow2,
            Resources.yellow3,
            Resources.yellow4
        };
        private Random rdm = new Random();
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

        public bool isDad=false;
        private int timer = 0;
        private static int speed;
        private static int life;
        private static int SetSpeed(int type)
        {
            switch(type)
            {
                case 0:
                    speed = 2;
                    break;
                case 1:
                    speed = 3;
                    break;
                case 2:
                    speed = 4;
                    break;
            }
            return speed;
        }

        private static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    life = 1;
                    break;
                case 1:
                    life = 2;
                    break;
                case 2:
                    life = 3;
                    break;
            }
            return life;
        }

        public Enemy(int x,int y,int type,Direction dir)
            :base(x,y,SetLife(type),E1Tank[0].Width,E1Tank[0].Height,SetSpeed(type),dir)
        {
            this.type = type;
            Reborn();
        }
        public void EnemyAi()
        {
            if (rdm.Next(0,100) < 2)
            {
                switch(rdm.Next(0,4))
                {
                    case 0:
                        dir = Direction.up;
                        break;
                    case 1:
                        dir = Direction.left;
                        break;
                    case 2:
                        dir = Direction.down;
                        break;
                    case 3:
                        dir = Direction.right;
                        break;
                }
            }
        }
        public override void Fire()
        {
            Singleton.Instance.AddElement(new eBullet(this, 1, 15, 1));
        }
        public override void Move()
        {
            if (!Movable)
                return;
            EnemyAi();
            AdjustDirection();
            if(this.X>600 || this.X<0 || this.Y>600 || this.Y<0)
            {
                switch(rdm.Next(0,4))
                {
                    case 0:
                        dir = Direction.up;
                        break;
                    case 1:
                        dir = Direction.left;
                        break;
                    case 2:
                        dir = Direction.down;
                        break;
                    case 3:
                        dir = Direction.right;
                        break;
                }
            }
            base.Move(); 
        }
        public override void Draw(Graphics g)
        {
            if (BornTime < 48)
            {
                BornTime++;
                return;
            }
            if(!Movable)
            {
                timer++;
                if (timer == 150) {
                    Movable = true;
                    //timer = 0;
                }
                    
                if (timer % 10 == 0) //一閃一閃
                    return;
            }
           
            Move();
            switch(type)
            {
                case 0:
                    {
                        switch (dir)
                        {
                            case Direction.up:
                                g.DrawImage(E1Tank[0], this.X, this.Y);
                                break;
                            case Direction.left:
                                g.DrawImage(E1Tank[1], this.X, this.Y);
                                break;
                            case Direction.down:
                                g.DrawImage(E1Tank[2], this.X, this.Y);
                                break;
                            case Direction.right:
                                g.DrawImage(E1Tank[3], this.X, this.Y);
                                break;
                        }
                        break;
                    }
                case 1:
                    switch (dir)
                    {
                        case Direction.up:
                            g.DrawImage(E2Tank[0], this.X, this.Y);
                            break;
                        case Direction.left:
                            g.DrawImage(E2Tank[1], this.X, this.Y);
                            break;
                        case Direction.down:
                            g.DrawImage(E2Tank[2], this.X, this.Y);
                            break;
                        case Direction.right:
                            g.DrawImage(E2Tank[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 2:
                    switch (dir)
                    {
                        case Direction.up:
                            g.DrawImage(E3Tank[0], this.X, this.Y);
                            break;
                        case Direction.left:
                            g.DrawImage(E3Tank[1], this.X, this.Y);
                            break;
                        case Direction.down:
                            g.DrawImage(E3Tank[2], this.X, this.Y);
                            break;
                        case Direction.right:
                            g.DrawImage(E3Tank[3], this.X, this.Y);
                            break;
                    }
                    break;
            }
            if (rdm.Next(0, 100) < 1) Fire();
        }
        public void isDead()
        {
            Singleton.Instance.AddElement(new Bomb(this.X - 25, this.Y - 25));
            if (this.Life <= 0)
            {
                isDad = true;
                Singleton.Instance.RemoveElement(this);
                Singleton.Instance.AddElement(new enemyScore(this.X + this.Width +5, this.Y + 5, type));  
                Singleton.Instance.AddElement(new Equipment(X, Y, rdm.Next(0, 10)));
                switch(type)
                {
                    case 0:
                        Singleton.Instance.ScoreSumOfSingle += 100;
                        break;
                    case 1:
                        Singleton.Instance.ScoreSumOfSingle += 200;
                        break;
                    case 2:
                        Singleton.Instance.ScoreSumOfSingle += 300;
                        break;
                    default:break;
                }
            }
        }
        public override void Reborn()
        {
            Singleton.Instance.AddElement(new Born(this.X, this.Y));
        }

    }
}
