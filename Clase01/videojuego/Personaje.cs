using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videojuego
{
    class Personaje
    {
        int y;
        int x;
        char skin;
        int hp;

        public Personaje(int x, int y)
        {
            this.y = y;
            this.x = x;
            skin = 'P';
            hp = 3;
        }

        public void Move(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.W:
                    if (y > 1) y--;
                    break;
                case ConsoleKey.S:
                    if (y < 29) y++;
                    break;
                case ConsoleKey.A:
                    if (x > 0) x--;
                    break;
                case ConsoleKey.D:
                    if (x < 84) x++;
                    break;
                default:
                    return;
            }
        }

        public bool Exit(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape) return false;
            else return true;
        }

        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(skin);
        }

        public void SetX(int x) {this.x = x;}
        public void SetY(int y) {this.y = y;}
        public void SetSkin(char s) {skin = s;}
        public int GetX() {return x;}
        public int GetY() {return y;}
        public char GetSkin() {return skin;}
        public int GetHp() {return hp;}
        public void Damage()
        {
            if (hp > 0)
            {
                hp--;
                if (y < 29) y++;
            }
        }
    }
}
