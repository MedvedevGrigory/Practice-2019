using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bullet : MovableObject
    {
        public static Size size = new Size()
        {
            width = 10,
            height = 10
        };

        public bool isEnemyBullet;

        public Bullet(bool isEnemyBullet)
        {
            this.isEnemyBullet = isEnemyBullet;
        }
    }
}
