using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Sprite
    {
        internal void DrawKolobok(Graphics graphics, Position pos, Size size)
        {
            Image image = Image.FromFile(@"..\..\..\Sprites\KolobokR.png");
            graphics.DrawImage(image, new Rectangle(pos.x, pos.y, size.width, size.height));
        }
    }
}
