using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public enum eDirection
    {
        LEFT, RIGHT, UP, DOWN
    }

    public interface IMovable
    {
        eDirection Direction { get; set; }
        int Speed { get; set; }
    }
}
