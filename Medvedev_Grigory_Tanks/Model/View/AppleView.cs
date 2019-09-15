using System;
using System.Drawing;

namespace Model
{
    public class AppleView : Apple
    {
        Sprite spriteDrow = new Sprite();
        Position Pos;

        public AppleView(Position pos)
        {
            Pos = pos;
            sprite = Image.FromFile(@"..\..\..\Sprites\KolobokR.png");
        }

        public void Draw(Graphics graphics)
        {
            spriteDrow.Draw(graphics, Pos, size, sprite);
        }
    }
}
