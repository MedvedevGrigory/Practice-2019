using System.Drawing;

namespace Model
{
    public class WaterView : WallView
    {
        public WaterView(Position pos) : base(pos)
        {
            sprite = Image.FromFile(@"..\..\..\Sprites\Water.png");
        }
    }
}
