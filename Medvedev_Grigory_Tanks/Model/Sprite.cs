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
        private const int TimeFactor = 5;
        private const double Increment = 1.0 / TimeFactor;

        private const int FrameCount = 2;
        private double Counter = 0;
        
        internal void Draw(Graphics graphics, Position pos, Size size, Image sprite)
        {
            int currentFrame = (int)Counter;
            Rectangle destRect = new Rectangle(pos.x, pos.y, size.width, size.height);
            graphics.DrawImage(sprite, destRect, size.width * currentFrame, 0, size.width, size.height, GraphicsUnit.Pixel);
            Counter = (Counter + Increment) % FrameCount;
        }
    }
}