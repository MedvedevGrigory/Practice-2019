using System;
using System.Drawing;

namespace Model
{
    public class TankView : Tank
    {
        Sprite spriteDraw = new Sprite();
        public Position Pos;
        public Image currentSprite;

        public TankView(Position pos, Direction direction)
        {
            Pos = pos;
            Direction = direction;

            sprite[0] = Image.FromFile(@"..\..\..\Sprites\TankL.png");
            sprite[1] = Image.FromFile(@"..\..\..\Sprites\TankR.png");
            sprite[2] = Image.FromFile(@"..\..\..\Sprites\TankU.png");
            sprite[3] = Image.FromFile(@"..\..\..\Sprites\TankD.png");
        }

        public Direction Direction { get; set; }

        public void Draw(Graphics graphics)
        {
            spriteDraw.Draw(graphics, Pos, size, currentSprite);
        }
    }
}
