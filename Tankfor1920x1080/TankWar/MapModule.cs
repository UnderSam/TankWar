using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public class MapModule : Element
    {
        private static Image imgbrickUnit = Resources.unitBrick;
        private static Image imgMedalUnit = Resources.medalUnit;
        private static Image imgWaterUnit = Resources.waterUnit;
        private static Image imgWaterFour = Resources.waterFour;
        private static Image imgWater60x120 = Resources.water120x120;
        private static Image imgWater120x120 = Resources.water120x120;
        

        private int type;
        private int itemType;
        private bool isBreakable = false;
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
        private int numMap = 1;
        public bool IsBreakable
        {
            get
            {
                return isBreakable;
            }

            set
            {
                isBreakable = value;
            }
        }
        private int life;
        public int NumMap
        {
            get
            {
                return numMap;
            }

            set
            {
                numMap = value;
            }
        }

        public int Width
        {
            get
            {
                return imgbrickUnit.Width;
            }
            set
            { }
        }

        public int Height
        {
            get
            {
                return imgbrickUnit.Height;
            }
            set { }
        }

        public int ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

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

        public MapModule(int x,int y,int type,int numMap)
            :base(x,y)
        {
            
            this.type = type;
            this.NumMap = numMap;
            switch(type)
            {
                case 0:
                    life = 1;
                    IsBreakable = true;
                    break;
                case 1:
                    life = 4;
                    IsBreakable = true;
                    break;
                case 2:
                    life = 2000;
                    IsBreakable = false;
                    break;
                default:
                    life = 2000;
                    IsBreakable = false;
                    break;
            }
        }
        public void init()
        {
            
        }
        public override void Draw(Graphics g)
        {
            switch(type)
            {
                case 0: //1塊磚頭
                    g.DrawImage(imgbrickUnit, X, Y);
                    break;
                case 1: //1塊金屬
                    g.DrawImage(imgMedalUnit, X, Y);
                    break;
                case 2: //一塊水
                    g.DrawImage(imgWaterUnit, X, Y);
                    break;
                case 3://4塊水
                    g.DrawImage(imgWaterFour, X, Y);
                    break;
                case 4://16塊水
                    g.DrawImage(imgWater120x120, X, Y);
                    break;
                case 5://60x120 water
                    g.DrawImage(imgWater60x120, X, Y);
                    break;
                default: break;

            } 
        }

        public void Create(int numMap)
        {
            switch (numMap)
            {
                case 1: 
                    createMap1(numMap);
                    break;
                case 2: 
                    createMap2(numMap);
                    break;
                case 3: 
                    createMap3(numMap);
                    break;
            }

        }

        public void createMap1(int num)
        {
            if (Singleton.Instance.PlayerNum == 2)  //單人地圖
            {
                BrickUnit(120, 0, num);
                BrickUnit(120, 30, num);
                BrickUnit(120, 60, num);
                BrickUnit(120, 90, num);
                BrickUnit(120, 120, num);
                BrickUnit(0, 120, num);
                BrickUnit(30, 120, num);
                BrickUnit(60, 120, num);
                BrickUnit(90, 120, num);
                //////////////////////////
                WaterFour(300, 60, num);
                BrickUnit(480, 0, num);
                BrickUnit(480, 30, num);
                BrickUnit(480, 60, num);
                BrickUnit(480, 90, num);
                BrickUnit(480, 120, num);
                BrickUnit(510, 120, num);
                BrickUnit(540, 120, num);
                BrickUnit(570, 120, num);
                BrickUnit(600, 120, num);
                BrickUnit(630, 120, num);
                BrickUnit(0, 300, num);
                BrickUnit(30, 300, num);
                BrickUnit(60, 300, num);
                BrickUnit(90, 300, num);
                BrickUnit(120, 300, num);
                BrickUnit(150, 300, num);
                BrickUnit(180, 300, num);
                BrickUnit(210, 300, num);
                BrickUnit(240, 300, num);
                BrickUnit(270, 300, num);
                /////////////////////////////
                MedalFour(300, 270, num);
                MedalUnit(300, 330, num);
                MedalUnit(330, 330, num);
                /////////////////////////////
                BrickUnit(360, 300, num);
                BrickUnit(390, 300, num);
                BrickUnit(420, 300, num);
                BrickUnit(450, 300, num);
                BrickUnit(480, 300, num);
                BrickUnit(510, 300, num);
                BrickUnit(540, 300, num);
                BrickUnit(570, 300, num);
                BrickUnit(600, 300, num);
                BrickUnit(630, 300, num);
                BrickUnit(0, 480, num);
                BrickUnit(30, 480, num);
                BrickUnit(60, 480, num);
                BrickUnit(90, 480, num);
                BrickUnit(120, 480, num);
                BrickUnit(120, 510, num);
                BrickUnit(120, 540, num);
                BrickUnit(120, 570, num);
                BrickUnit(120, 600, num);
                BrickUnit(120, 630, num);
                WaterFour(300, 540, num);
                BrickUnit(480, 480, num);
                BrickUnit(510, 480, num);
                BrickUnit(540, 480, num);
                BrickUnit(570, 480, num);
                BrickUnit(600, 480, num);
                BrickUnit(630, 480, num);
                BrickUnit(480, 510, num);
                BrickUnit(480, 540, num);
                BrickUnit(480, 570, num);
                BrickUnit(480, 600, num);
                BrickUnit(480, 630, num);
            }
            else
            {
                BrickDL(0, 120, num);
                BrickDL(60, 120, num);
                BrickDL(120, 120, num);
                BrickDL(180, 120, num);
                BrickDL(240, 120, num);
                BrickDL(300, 120, num);
                BrickDL(360, 120, num);
                BrickDL(420, 120, num);
                BrickDL(480, 120, num);
                BrickDL(540, 120, num);
                
                BrickDL(0, 300, num);
                BrickDL(60, 300, num);
                BrickDL(120, 300, num);
                BrickDL(180, 300, num);
                BrickDL(240, 300, num);
                BrickDL(300, 300, num);
                BrickDL(360, 300, num);
                BrickDL(420, 300, num);
                BrickDL(480, 300, num);
                BrickDL(540, 300, num);
                BrickDL(0, 480, num);
                
                BrickDL(60, 480, num);
                BrickDL(120, 480, num);
                BrickDL(180, 480, num);
                BrickDL(240, 480, num);
                BrickDL(300, 480, num);
                BrickDL(360, 480, num);
                BrickDL(420, 480, num);
                BrickDL(480, 480, num);
                BrickDL(540, 480, num);
                BrickDL(600, 480, num);
                BrickDL(600, 300, num);
                BrickDL(600, 120, num);

                MedalFour(300, 0, num);
                MedalFour(300, 60, num);
                MedalDL(300, 330, num);
                MedalFour(300, 360, num);
                MedalFour(300, 420, num);
            }
        }

        public void createMap2(int num)
        {
            if (Singleton.Instance.PlayerNum == 2)
            {
                MedalDL(0, 0, num);
                MedalDL(60, 0, num);
                MedalDL(120, 0, num);
                MedalDL(180, 0, num);
                MedalDL(240, 0, num);
                MedalDL(0, 630, num);
                MedalDL(60, 630, num);
                MedalDL(120, 630, num);
                MedalDL(180, 630, num);
                MedalDL(240, 630, num);

                MedalUnit(120, 120, num);
                MedalUnit(120, 150, num);
                MedalUnit(120, 180, num);
                BrickUnit(120, 210, num);
                BrickUnit(120, 240, num);
                BrickUnit(120, 270, num);
                MedalUnit(120, 300, num);
                MedalUnit(120, 330, num);
                MedalUnit(120, 360, num);
                BrickUnit(120, 390, num);
                BrickUnit(120, 420, num);
                BrickUnit(120, 450, num);
                MedalUnit(120, 480, num);
                MedalUnit(120, 510, num);
                MedalUnit(120, 540, num);

                BrickDL(300, 0, num);
                BrickDL(300, 30, num);
                BrickDL(300, 60, num);
                BrickDL(300, 90, num);
                BrickDL(300, 120, num);
                BrickDL(300, 150, num);
                BrickDL(300, 180, num);
                BrickDL(300, 210, num);
                BrickDL(300, 240, num);
                BrickDL(300, 270, num);
                BrickDL(300, 300, num);
                BrickDL(300, 330, num);
                BrickDL(300, 360, num);
                BrickDL(300, 390, num);
                BrickDL(300, 420, num);
                BrickDL(300, 450, num);
                BrickDL(300, 480, num);
                BrickDL(300, 510, num);
                BrickDL(300, 540, num);
                BrickDL(300, 570, num);
                BrickDL(300, 600, num);
                BrickDL(300, 630, num);

                MedalDL(360, 0, num);
                MedalDL(420, 0, num);
                MedalDL(480, 0, num);
                MedalDL(540, 0, num);
                MedalDL(600, 0, num);
                MedalDL(360, 630, num);
                MedalDL(420, 630, num);
                MedalDL(480, 630, num);
                MedalDL(540, 630, num);
                MedalDL(600, 630, num);

                MedalUnit(480, 120, num);
                MedalUnit(480, 150, num);
                MedalUnit(480, 180, num);
                BrickUnit(480, 210, num);
                BrickUnit(480, 240, num);
                BrickUnit(480, 270, num);
                MedalUnit(480, 300, num);
                MedalUnit(480, 330, num);
                MedalUnit(480, 360, num);
                BrickUnit(480, 390, num);
                BrickUnit(480, 420, num);
                BrickUnit(480, 450, num);
                MedalUnit(480, 480, num);
                MedalUnit(480, 510, num);
                MedalUnit(480, 540, num);
        
            }
            else
            {
                BrickFour(0, 240, num);
                BrickFour(0, 300, num);
                BrickDL(0, 360, num);
                WaterFour(120, 120, num);
                WaterFour(120, 420, num);
                WaterFour(480, 120, num);
                WaterFour(480, 420, num);
                BrickFour(600, 240, num);
                BrickFour(600, 300, num);
                BrickUnit(600, 360, num);
                BrickUnit(630, 360, num);
                MedalUnit(120, 300, num);
                MedalUnit(150, 300, num);
                MedalUnit(180, 300, num);
                MedalUnit(210, 300, num);
                MedalUnit(420, 300, num);
                MedalUnit(450, 300, num);
                MedalUnit(480, 300, num);
                MedalUnit(510, 300, num);
                BrickDL(300, 0, num);
                BrickDL(300, 30, num);
                BrickDL(300, 60, num);
                BrickDL(300, 90, num);
                BrickDL(300, 120, num);
                BrickDL(300, 150, num);
                BrickDL(300, 180, num);
                BrickDL(300, 210, num);
                BrickDL(300, 240, num);
                BrickDL(300, 270, num);
                BrickDL(300, 300, num);
                BrickDL(300, 330, num);
                BrickDL(300, 360, num);
                BrickDL(300, 390, num);
                BrickDL(300, 420, num);
                BrickDL(300, 450, num);
                BrickDL(300, 480, num);
                BrickDL(300, 510, num);
                BrickDL(300, 540, num);
                BrickDL(300, 570, num);
                BrickDL(300, 600, num);
                BrickDL(300, 630, num);
            }
        }


        public void createMap3(int num)
        {
            if (Singleton.Instance.PlayerNum == 1)
            {
                MedalFour(60, 60, num);
                MedalFour(480, 480, num);
                MedalUnit(300, 300, num);
                MedalUnit(330, 300, num);
                MedalUnit(480, 90, num);
                MedalUnit(90, 480, num);

                BrickDL(480, 60, num);
                BrickDL(60, 510, num);
                BrickUnit(300, 180, num);
                BrickUnit(330, 180, num);
                BrickUnit(300, 420, num);
                BrickUnit(330, 420, num);
                BrickUnit(180, 300, num);
          
                BrickUnit(510, 90, num);
                BrickUnit(60, 480, num);
              
                WaterDL(0, 300, num);
                WaterDL(60, 300, num);
                WaterDL(120, 300, num);
                BrickDL(180, 300, num);
                BrickDL(240, 300, num);
                BrickDL(360, 300, num);
                BrickDL(420, 300, num);
                WaterDL(480, 300, num);
                WaterDL(540, 300, num);
                WaterDL(600, 300, num);

                WaterUnit(600, 300, num);
                WaterUnit(300, 0, num);
                WaterUnit(300, 30, num);
                WaterUnit(300, 60, num);
                WaterUnit(300, 90, num);
                WaterUnit(300, 120, num);

                WaterUnit(300, 480, num);
                WaterUnit(300, 510, num);
                WaterUnit(300, 540, num);
                WaterUnit(300, 570, num);
                WaterUnit(300, 600, num);
                WaterUnit(300, 630, num);
            }
            else
            {
              
                BrickDL(240, 120, num);
                BrickDL(300, 120, num);
                BrickDL(360, 120, num);
                BrickDL(240, 300, num);
                BrickDL(300, 300, num);
                BrickDL(360, 300, num);
                BrickDL(240, 480, num);
                BrickDL(300, 480, num);
                BrickDL(360, 480, num);
                WaterDL(0, 300, num);
                WaterDL(60, 300, num);
                WaterDL(120, 300, num);
                WaterDL(180, 300, num);
                WaterDL(420, 300, num);
                WaterDL(480, 300, num);
                WaterDL(540, 300, num);
                WaterDL(600, 300, num);
                WaterUnit(300, 180, num);
                WaterUnit(300, 210, num);
                WaterUnit(300, 240, num);
                WaterUnit(300, 360, num);
                WaterUnit(300, 390, num);
                WaterUnit(300, 420, num);
            }
        }

        public void BrickUnit(int x,int y,int numMap)
        {
            
            Singleton.Instance.AddElement(new MapModule(x, y, 0, numMap));
            
        }
        public void BrickDL(int x, int y, int numMap)
        {
            Singleton.Instance.AddElement(new MapModule(x, y, 0, numMap));
            Singleton.Instance.AddElement(new MapModule(x+imgbrickUnit.Width, y, 0, numMap));
        }
        public void BrickFour(int x, int y, int numMap)
        {
            Singleton.Instance.AddElement(new MapModule(x, y, 0, numMap));
            Singleton.Instance.AddElement(new MapModule(x + imgbrickUnit.Width, y, 0, numMap));
            Singleton.Instance.AddElement(new MapModule(x, y + imgbrickUnit.Height, 0, numMap));
            Singleton.Instance.AddElement(new MapModule(x + imgbrickUnit.Width, y + imgbrickUnit.Height, 0, numMap));
        }

        public void MedalUnit(int x, int y, int numMap)
        {
           
            Singleton.Instance.AddElement(new MapModule(x, y, 1, numMap));
            
        }
        public void MedalDL(int x, int y, int numMap)
        {

            Singleton.Instance.AddElement(new MapModule(x, y, 1, numMap));
            Singleton.Instance.AddElement(new MapModule(x+imgMedalUnit.Width, y, 1, numMap));

        }
        public void MedalFour(int x, int y, int numMap)
        {
            Singleton.Instance.AddElement(new MapModule(x, y, 1, numMap));
            Singleton.Instance.AddElement(new MapModule(x + 30, y, 1, numMap));
            Singleton.Instance.AddElement(new MapModule(x, y + 30, 1, numMap));
            Singleton.Instance.AddElement(new MapModule(x + 30, y + 30, 1, numMap));
        }

        public void WaterUnit(int x, int y, int numMap)
        {
            Singleton.Instance.AddElement(new MapModule(x, y, 2, numMap));
            Singleton.Instance.AddElement(new MapModule(x+imgWaterUnit.Width, y, 2, numMap));
        }
        public void WaterDL(int x, int y, int numMap)
        {

            Singleton.Instance.AddElement(new MapModule(x, y, 2, numMap));
            Singleton.Instance.AddElement(new MapModule(x + imgWaterUnit.Width-2, y, 2, numMap));

        }
        public void WaterFour(int x,int y,int numMap)
        {
            Singleton.Instance.AddElement(new MapModule(x, y, 2, numMap));
            Singleton.Instance.AddElement(new MapModule(x + imgWaterUnit.Width-5, y, 2, numMap));
            Singleton.Instance.AddElement(new MapModule(x, y + imgWaterUnit.Height-4, 2, numMap));
            Singleton.Instance.AddElement(new MapModule(x + imgWaterUnit.Width - 5, y + imgWaterUnit.Height - 4, 2, numMap));
        }

        public Rectangle getRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        public void isBreak()
        {
            if (IsBreakable && Life<=0)
            {
                Random rdm = new Random();
                Singleton.Instance.RemoveElement(this);
                if (Singleton.Instance.PlayerNum == 2)
                {
                    if (rdm.Next(5, 20) < 8)
                    {
                        Singleton.Instance.NewMultiEquipX = X;
                        Singleton.Instance.NewMultiEquipY = Y;
                        Singleton.Instance.PassMap = "1/" + Convert.ToString(X) + "/" + Convert.ToString(Y) + "/";
                        Singleton.Instance.IsCreateEquip = true;
                        return;
                    }
                }
                return;
            }
        }
    }
}
