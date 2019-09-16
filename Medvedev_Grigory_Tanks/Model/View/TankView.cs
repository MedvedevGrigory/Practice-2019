using System;
using System.Drawing;

namespace Model
{
    public class TankView : Tank
    {
        Sprite spriteDraw = new Sprite();
        public Position Pos;

        public TankView(Position pos, Direction direction)
        {
            Pos = pos;
            Direction = direction;
            switch (direction)
            {
                case Direction.LEFT:
                    sprite = Image.FromFile(@"..\..\..\Sprites\TankL.png");
                    break;
                case Direction.RIGHT:
                    sprite = Image.FromFile(@"..\..\..\Sprites\TankR.png");
                    break;
                case Direction.UP:
                    sprite = Image.FromFile(@"..\..\..\Sprites\TankU.png");
                    break;
                case Direction.DOWN:
                    sprite = Image.FromFile(@"..\..\..\Sprites\TankD.png");
                    break;
            }
        }

        public Direction Direction { get; set; }

        public void Draw(Graphics graphics)
        {
            spriteDraw.Draw(graphics, Pos, size, sprite);
        }
    }
}
