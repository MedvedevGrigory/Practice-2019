using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public struct Pos
    {
        int x, y;
    }

    public struct Size
    {
        int width, height;
    }

    interface IDraw
    {
        Pos Pos { get; set; }
        Size Size { get; set; }

        void Draw(Graphics graphics);
    }
}
