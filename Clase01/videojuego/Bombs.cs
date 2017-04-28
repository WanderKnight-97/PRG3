using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videojuego
{
    class Bombs
    {
        int x;
        int y;
        string skin = "B";

        public Bombs(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(skin);
        }

        public void Collition(Personaje p)
        {
            if (p.GetX() == x && p.GetY() == y) p.Damage();
        }
    }
}
