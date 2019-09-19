using System.Drawing;

namespace Model
{
    public class DestroyWallView : WallView
    {
        public DestroyWallView(Position pos) : base(pos)
        {
            sprite = Image.FromFile(@"..\..\..\Sprites\DestroyWall.png");
        }
    }
}
