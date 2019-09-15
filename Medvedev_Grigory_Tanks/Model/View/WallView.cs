using System;
using System.Drawing;

namespace Model
{
    public class WallView : Wall
    {
        Sprite spriteDraw = new Sprite();
        public Position Pos;

        public WallView(Position pos)
        {
            Pos = pos;
            sprite = Image.FromFile(@"..\..\..\Sprites\Wall.png");
        }

        public void Draw(Graphics graphics)
        {
            spriteDraw.Draw(graphics, Pos, size, sprite);
        }
    }
}
