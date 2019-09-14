using System;
using System.Drawing;

namespace Model
{
    public class AppleView : Apple, IDraw
    {
        public AppleView(Size size, Pos pos) : base(size)
        {
            Pos = pos;
        }

        public Pos Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
