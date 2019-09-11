using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    class Tank : Object, IMovable
    {
        public Tank(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public eDirection Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
