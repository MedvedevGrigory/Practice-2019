using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wall : FixObject
    {
        public Size size = new Size()
        {
            width = 50,
            height = 50
        };
    }
}
