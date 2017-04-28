using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videojuego
{
    class Enemies
    {
        int x;
        int y;
        int c = 0;
        char skin = 'E';
        bool d = true;

        public Enemies(int x, int y)
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

        public void Move()
        {
            

            if (x < 84 && x > 0 && d == true)
                x++;
            if (x == 83 || x == 1)
                d =! d;
            if (x < 84 && x > 0 && d == false)
                x--;

            /*if (c < 84 && x + 1 != 84)
                x += 1;
            else if (c < 84 / 2 && x - 1 != 0)
                x -= 1;*/
        }
        
        public void SetC(int c) { this.c = c; }
        public int GetC() { return c; }
    }
}
