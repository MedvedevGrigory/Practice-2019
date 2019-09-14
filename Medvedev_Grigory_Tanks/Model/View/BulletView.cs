using System;
using System.Drawing;

namespace Model
{
    public class BulletView : Bullet, IDraw
    {
        public BulletView()
        {
        }

        public Pos Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
