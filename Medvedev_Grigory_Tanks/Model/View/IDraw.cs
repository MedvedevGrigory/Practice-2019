using System.Drawing;

namespace Model
{
    public struct Pos
    {
        int x, y;
    }

    interface IDraw
    {
        Pos Pos { get; set; }

        void Draw(Graphics graphics);
    }
}
