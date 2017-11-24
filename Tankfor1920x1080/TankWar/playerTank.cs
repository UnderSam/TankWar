using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankWar.Properties;  // 要使用圖片必須引入properties

namespace TankWar
{
    public class playerTank : Player 
    {
        private int FireTime = 0;
        private static Image[] whiteTank = new Image[] {
            Resources.white1,
            Resources.white2,
            Resources.white3,
            Resources.white4,

            Resources.bWhite1,
            Resources.bWhite2,
            Resources.bWhite3,
            Resources.bWhite4,

            Resources.bbwhite1,
            Resources.bbwhite2,
            Resources.bbwhite3,
            Resources.bbwhite4
        };
        private static Image[] greenTank = new Image[] {
            Resources.green1,
            Resources.green2,
            Resources.green3,
            Resources.green4,

            Resources.bgreeben1,
            Resources.bgreeben2,
            Resources.bgreeben3,
            Resources.bgreeben4,

            Resources.bbgreen1,
            Resources.bbgreen2,
            Resources.bbgreen3,
            Resources.bbgreen4
        };
        private static Image[] pinkTank = new Image[] {
            Resources.pink1,
            Resources.pink2,
            Resources.pink3,
            Resources.pink4,

            Resources.bpink1,
            Resources.bpink2,
            Resources.bpink3,
            Resources.bpink4,

            Resources.bbpink1,
            Resources.bbpink2,
            Resources.bbpink3,
            Resources.bbpink4
        };
        private static Image[] yellowTank = new Image[] {
            Resources.yellow1,
            Resources.yellow2,
            Resources.yellow3,
            Resources.yellow4,

            Resources.bYellow1,
            Resources.bYellow2,
            Resources.bYellow3,
            Resources.bYellow4,

            Resources.bbYellow1,
            Resources.bbYellow2,
            Resources.bbYellow3,
            Resources.bbYellow4
        };
        private static Image[][] decidTank = new Image[][]
        {
            whiteTank,
            greenTank,
            pinkTank,
            yellowTank
        };
        private bool playerIsDead_bool = false;

        public bool PlayerIsDead_bool
        {
            get
            {
                return playerIsDead_bool;
            }

            set
            {
                playerIsDead_bool = value;
            }
        }

        public playerTank(int colors, int x,int y,int speed,int life,Direction dir,int tag)
            :base(x,y, decidTank[colors], speed,life,dir,tag)
        {
            this.TankType = 0;
            
        }
        
        public void Keydown(KeyEventArgs e)  //如果有鍵盤被按了就觸發
        {
            if (BornTime < 48)
                return;
            switch(e.KeyCode)
            {
                case (Keys)87:  //W
                    isUp = true;
                    break;
                case (Keys)65:  //A
                    isLeft = true;
                    break;
                case (Keys)83:  //S
                    isDown = true;
                    break;
                case (Keys)68:  //D
                    isRight = true;
                    break;
                case (Keys)32:  //space
                    Fire();
                    break;
                default: break;
            }
            if (e.KeyCode==Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
                isMove = true;
            AdjustDirection(); //判斷完方向後調整
        }

        public void otherKeydown(int control)  //如果有鍵盤被按了就觸發
        {
            if (BornTime < 48)
                return;
            switch (control)
            {
                case 87:  //W
                    isUp = true;
                    break;
                case 65:  //A
                    isLeft = true;
                    break;
                case 83:  //S
                    isDown = true;
                    break;
                case 68:  //D
                    isRight = true;
                    break;
                case 32:  //space
                    Fire();
                    break;
                default: break;
            }
            if (control == 87 || control == 65 || control == 83 || control == 68)
                isMove = true;
            AdjustDirection(); //判斷完方向後調整
        }

        public void KeyUp(KeyEventArgs e)   //如果有鍵盤放開了就觸發
        {
            
            switch (e.KeyCode)
            {
                case Keys.W:
                    isUp = false;
                    break;
                case Keys.A:
                    isLeft = false;
                    break;
                case Keys.S:
                    isDown = false;
                    break;
                case Keys.D:
                    isRight = false;
                    break;
                default: break;
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                isMove = false;
            }
            AdjustDirection(); //判斷完方向後調整
        }


        public void otherKeyUp(int control)  //如果有鍵盤被按了就觸發
        {
            switch (control)
            {
                case 87:  //W
                    isUp = false;
                    break;
                case 65:  //A
                    isLeft = false;
                    break;
                case 83:  //S
                    isDown = false;
                    break;
                case 68:  //D
                    isRight = false;
                    break;
                default: break;
            }
            if (control == 87 || control == 65 || control == 83 || control == 68)
                isMove = false;
            AdjustDirection(); //判斷完方向後調整
        }

        public override void Reborn()
        {
            if (IsLive != 2 && IsLive>=0) {
                this.X = 0;
                this.Y = 0;
            }

            Singleton.Instance.AddElement(new Born(this.X, this.Y));
        }
        
    }
}
