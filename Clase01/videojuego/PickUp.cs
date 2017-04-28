using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videojuego
{
    class PickUp
    {
        int x;
        int y;
        static int score;
        string skin = "♠";
        bool taken = false;

        public PickUp(int x, int y)
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
            if (p.GetX() == x && p.GetY() == y && taken == false)
            {
                taken = true;
                skin = "";
                score++;
            }
        }

        public int GetScore()
        {
            return score;
        }
    }
}
