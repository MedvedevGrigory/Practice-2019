using System;
using System.Drawing;

namespace Model
{
    public class AppleView : Apple
    {
        Sprite spriteDrow = new Sprite();
        public Position Pos;
        public new Image sprite;

        public AppleView(Position pos)
        {
            Pos = pos;
            sprite = Image.FromFile(@"..\..\..\Sprites\Apple.png");
        }

        public void Draw(Graphics graphics)
        {
            spriteDrow.Draw(graphics, Pos, size, sprite);
        }
    }
}
