using System;
using System.Drawing;

namespace Model
{
    public class KolobokView : Kolobok, IMovable
    {
        Sprite sprite = new Sprite();
        public Position Pos;

        public KolobokView(Position pos)
        {
            Pos = pos;
        }

        public eDirection Direction { get; set; } = eDirection.RIGHT;

        public void Draw(Graphics graphics)
        {
            sprite.DrawKolobok(graphics, Pos, size);
        }
    }
}
