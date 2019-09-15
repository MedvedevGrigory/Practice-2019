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
        bool changeSprite = false;
        int i = 0;
        
        internal void Draw(Graphics graphics, Position pos, Size size, Image sprite)
        {
            if (changeSprite)
            {
                graphics.DrawImage(sprite, new Rectangle(pos.x, pos.y, size.width, size.height), 0, 0, size.width, size.height, GraphicsUnit.Pixel);
            }
            else
            {
                graphics.DrawImage(sprite, new Rectangle(pos.x, pos.y, size.width, size.height), size.width, 0, size.width, size.height, GraphicsUnit.Pixel);
            }

            i++;
            if (i % 5 == 0)
            {
                changeSprite = !changeSprite;
            }
        }
    }
}
