using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    enum eDirection
    {
        LEFT, RIGHT, UP, DOWN
    }

    interface IMovable
    {
        eDirection Direction { get; set; }
        int Speed { get; set; }
    }
}
