using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuego
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            bool anima = false;
            bool vivo = true;
            bool sepuede = true;
            string tecla = "";
            /* 
             string pj = "(~O3O)~";
             string pj2 = "(~OwO)~";
             string limite = "(/O_O)/";
             string muerte = "(oX_X)o";
             */
            string pj = "☺";
            string pj2 = "☻";
            string limite = "█";
           //string muerte = "X";
            int min = 0;
            int max = 50;
            int cantb = max / 4;
            Random random = new Random();
            int x = max / 2;
            int y = max / 2;
            int[] xb = new int[cantb];
            int[] yb = new int[cantb];
            int randomNumber;
            int i = 0;
            string[] bombas = new string[cantb];
            while (i != cantb)
            {
                randomNumber = random.Next(min + 1, max - 1);
                xb[i] = randomNumber;
                randomNumber = random.Next(min + 1, max - 1);
                yb[i] = randomNumber;
                bombas[i] = "♠";
                i++;
            }
             i = 0;
            while (i != cantb)
            {
                if (xb[i] == x && yb[i] == y)
                {
                    x = random.Next(min + 1, max - 1);
                    y = random.Next(min + 1, max - 1);
                }
                i++;
            }
            Console.SetCursorPosition(0, y + 3);
            Console.WriteLine("Bienvenido al Juego, use WASD para mover al personaje(☺) y presione x para salir");
            while (end == false)
            {

                i = 0;
                while (i != cantb)
                {
                    Console.SetCursorPosition(xb[i], yb[i]);
                    Console.WriteLine(bombas[i]);
                    i++;
                }
                Console.SetCursorPosition(x, y);
                if (vivo == true)
                {

                    if (x == max || y == max || x == min + 1 || y == min + 1)
                    {
                        sepuede = false;
                        Console.WriteLine(limite);
                    }
                    else if (x != max || y != max || x != min + 1 || y != min + 1)
                    {
                        sepuede = true;

                    }
                    if (sepuede == true)
                    {
                        if (anima == false)
                        {
                            Console.WriteLine(pj);
                            anima = true;
                        }
                        else
                        {
                            Console.WriteLine(pj2);
                            anima = false;
                        }
                    }

                    tecla = Console.ReadKey().KeyChar.ToString();
                    if (tecla == "w" && y > min + 1 || tecla == "W" && y > min + 1)
                    {
                        y -= 1;
                    }
                    if (tecla == "s" && y <= max - 1 || tecla == "S" && y <= max - 1)
                    {
                        y += 1;
                    }
                    if (tecla == "a" && x > min + 1 || tecla == "A" && x > min + 1)
                    {
                        x -= 1;
                    }
                    if (tecla == "d" && x <= max - 1 || tecla == "D" && x <= max - 1)
                    {
                        x += 1;
                    }
                    if (tecla == "x" || tecla == "X")
                    {
                        end = true;
                    }
                    i = 0;
                    while (i != cantb)
                    {
                        if (x == xb[i] && y == yb[i])
                        {
                            vivo = false;
                        }
                        i++;
                    }

                }
                Console.Clear();
                if (vivo == false)
                {
                    Console.SetCursorPosition(x, y);
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("GAME OVER");
                    tecla = Console.ReadKey().KeyChar.ToString();
                    if (tecla == "x" || tecla == "X")
                    {
                        end = true;
                    }
                }
                Console.Clear();
               
            }
                }
        
        }
           
        }
    

