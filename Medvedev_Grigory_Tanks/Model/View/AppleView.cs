using System;
using System.Drawing;

namespace Model
{
    public class AppleView : Apple
    {
        Sprite sprite = new Sprite();
        Position Pos;

        public AppleView(Position pos)
        {
            Pos = pos;
        }
        
        public void Draw(Graphics graphics)
        {
        }
    }
}
