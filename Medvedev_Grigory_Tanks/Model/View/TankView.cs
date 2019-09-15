using System;
using System.Drawing;

namespace Model
{
    public class TankView : Tank
    {
        Sprite spriteDraw = new Sprite();
        public Position Pos;

        public TankView(Position pos)
        {
            Pos = pos;
        }

        public Direction Direction { get; set; } = Direction.RIGHT;

        public void Draw(Graphics graphics)
        {
            spriteDraw.Draw(graphics, Pos, size, sprite);
        }
    }
}
