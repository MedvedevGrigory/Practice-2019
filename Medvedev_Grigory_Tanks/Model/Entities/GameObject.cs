using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Size
    {
        int width, height;
    }

    public class GameObject
    {
        public GameObject()
        {
        }

        public string SpriteURL { get; set; }
        public Size Size { get; set; }
    }
    }
