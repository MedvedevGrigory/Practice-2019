using System;
using System.Drawing;

namespace Model
{
    public class KolobokView : Kolobok, IMovable
    {
        Sprite spriteDrow = new Sprite();
        public Position Pos;
        private readonly int frameCount = 2;
        public Image currentSprite;

        public KolobokView(Position pos)
        {
            Pos = pos;
            sprite[0] = Image.FromFile(@"..\..\..\Sprites\KolobokL.png");
            sprite[1] = Image.FromFile(@"..\..\..\Sprites\KolobokR.png");
            sprite[2] = Image.FromFile(@"..\..\..\Sprites\KolobokU.png");
            sprite[3] = Image.FromFile(@"..\..\..\Sprites\KolobokD.png");
            currentSprite = sprite[1];
        }

    public Direction Direction { get; set; } = Direction.RIGHT;

        public void Draw(Graphics graphics)
        {
            spriteDrow.Draw(graphics, Pos, size, currentSprite, frameCount);
        }
    }
}
