using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar.Properties;
namespace TankWar
{
    public class eBullet : Bullet
    {
        private static Image enemybullet = Resources.ebulet1;
        public eBullet(Characters whos, int life, int speed, int power)
            :base(whos,life, enemybullet.Width, enemybullet.Height,speed,power)
        {

        }
        public override void Draw(Graphics g)
        {
            base.Move();
            g.DrawImage(enemybullet, this.X, this.Y);
        }
    }
}
