using Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
