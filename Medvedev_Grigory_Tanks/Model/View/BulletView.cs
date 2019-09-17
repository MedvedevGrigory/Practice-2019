using System;
using System.Drawing;

namespace Model
{
    public class BulletView : Bullet, IMovable
    {
        Sprite spriteDrow = new Sprite();
        public Position Pos;

        public Direction Direction { get; set; }

        public BulletView(Position pos, Direction direction, bool isEnemyBullet) : base(isEnemyBullet)
        {
            Pos = pos;
            Direction = direction;
            sprite = Image.FromFile(@"..\..\..\Sprites\Bullet.png");
        }

        public void Draw(Graphics graphics)
        {
            spriteDrow.Draw(graphics, Pos, size, sprite);
        }
    }
}
