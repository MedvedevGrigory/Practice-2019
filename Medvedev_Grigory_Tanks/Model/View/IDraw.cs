using System.Drawing;

namespace Model
{
    interface IDraw
    {
        Pos Pos { get; set; }

        void Draw(Graphics graphics);
    }
}
