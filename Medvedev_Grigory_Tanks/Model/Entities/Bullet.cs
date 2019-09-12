using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    class Bullet : GameObject, IMovable
    {
        public Bullet(int x, int y, int width, int height, eDirection direction, int speed) : base(x, y, width, height)
        {
            Direction = direction;
            Speed = speed;
        }

        public eDirection Direction { get; set; }
        public int Speed { get; set; }
    }
}
