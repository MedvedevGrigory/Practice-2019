using System.Collections.Generic;

namespace Model
{
    public class ListEntities
    {
        public KolobokView Kolobok { get; set; }
        public List<TankView> Tanks { get; set; }
        public List<AppleView> Apples { get; set; }
        public List<WallView> Walls { get; set; }
        public List<BulletView> Bullets { get; set; }
    }
}
