using System;
using System.Drawing;

namespace Model
{
    public class KolobokView : Kolobok, IMovable
    {
        Sprite spriteDrow = new Sprite();
        public Position Pos;

        public KolobokView(Position pos)
        {
            Pos = pos;
            sprite = Image.FromFile(@"..\..\..\Sprites\KolobokR.png");
        }

        public Direction Direction { get; set; } = Direction.RIGHT;

        public void Draw(Graphics graphics)
        {
            spriteDrow.Draw(graphics, Pos, size, sprite);
        }
    }
}
