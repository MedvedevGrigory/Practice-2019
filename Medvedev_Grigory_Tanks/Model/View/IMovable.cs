using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }

    public interface IMovable
    {
        Direction Direction { get; set; }
    }
}
