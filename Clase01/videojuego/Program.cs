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
            string key = "";
            string p = "P";
            string limit = "█";
            bool end = false;
            bool alive = true;
            int min = 0;
            int max = 50;
            int bCant = 10;
            int c = 0;
            Random r = new Random();
            int x = max / 2;
            int y = max / 2;
            int[] bX = new int[bCant];
            int[] bY = new int[bCant];
            int randNum;
            int i = 0;
            string[] bombs = new string[bCant];
            string[] enemies = new string[4];
            int[] eX = new int[enemies.Length];
            int[] eY = new int[enemies.Length];

            /*while (i != bCant)
            {
                randNum = r.Next(min + 1, max - 1);
                bX[i] = randNum;
                randNum = r.Next(min + 1, max - 1);
                bY[i] = randNum;
                bombs[i] = "B";
                i++;
            }*/
            //i = 0;
            for (i = 0; i < bCant; i++)
            {
                randNum = r.Next(min + 1, max - 1);
                bX[i] = randNum;
                randNum = r.Next(min + 1, max - 1);
                bY[i] = randNum;
                bombs[i] = "B";
            }
            for (i = 0; i < enemies.Length; i++)
            {
                randNum = r.Next(min + 1, max - 1);
                eX[i] = randNum;
                randNum = r.Next(min + 1, max - 1);
                eY[i] = randNum;
                enemies[i] = "E";
            }

            i = 0;
            while (i != bCant)
            {
                if (bX[i] == x && bY[i] == y)
                {
                    x = r.Next(min + 1, max - 1);
                    y = r.Next(min + 1, max - 1);
                }
                i++;
            }
            Console.SetCursorPosition(0, y + 2);
            Console.WriteLine("W A S D para mover a P. Presione x para salir");
            while (end == false)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
                }
                i = 0;
                while (i != bCant)
                {
                    Console.SetCursorPosition(bX[i], bY[i]);
                    Console.WriteLine(bombs[i]);
                    i++;
                }

                for (i = 0; i < enemies.Length; i++)
                {
                    /*randNum = r.Next(0, 8);
                    if ((randNum / 2) == 0 && eX[i] + 1 != max)
                    {
                        eX[i] += 1;
                    }
                    else if ((randNum / 2) != 0 && eX[i] - 1 != min)
                    {
                        eX[i] -= 1;
                    }*/

                    if (c < max && eX[i] +1 != max)
                    {
                        eX[i] += 1;
                    }
                    else if (c < max / 2 && eX[i] - 1 != min)
                    {
                        eX[i] -= 1;
                    }

                    Console.SetCursorPosition(eX[i], eY[i]);
                    Console.WriteLine(enemies[i]);
                }

                Console.SetCursorPosition(x, y);
                if (alive == true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey();

                        if (x == max || y == max || x == min + 1 || y == min + 1)
                        {
                            Console.WriteLine(limit);
                        }
                        else if (x != max || y != max || x != min + 1 || y != min + 1)
                        {
                            Console.WriteLine(p);
                        }
                        key = Console.ReadKey().KeyChar.ToString();
                        if (key == "w" && y > min + 1 || key == "W" && y > min + 1)
                        {
                            y -= 1;
                        }
                        if (key == "s" && y <= max - 1 || key == "S" && y <= max - 1)
                        {
                            y += 1;
                        }
                        if (key == "a" && x > min + 1 || key == "A" && x > min + 1)
                        {
                            x -= 1;
                        }
                        if (key == "d" && x <= max - 1 || key == "D" && x <= max - 1)
                        {
                            x += 1;
                        }
                        if (key == "x" || key == "X")
                        {
                            end = true;
                        }
                    }
                    i = 0;
                    while (i != bCant)
                    {
                        if (x == bX[i] && y == bY[i])
                        {
                            alive = false;
                        }
                        i++;
                    }

                    i = 0;
                    while (i != enemies.Length)
                    {
                        if (x == eX[i] && y == eY[i])
                        {
                            alive = false;
                        }
                        i++;
                    }
                }
                System.Threading.Thread.Sleep(300);
                Console.Clear();

                if (alive == false)
                {
                    Console.SetCursorPosition(x, y);
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("Game over");
                    key = Console.ReadKey().KeyChar.ToString();
                    if (key == "x" || key == "X")
                    {
                        end = true;
                    }
                }
                if (c != max)
                    c++;
                else
                    c = 0;
                
                Console.Clear();

                /*
                 a tener en cuenta en la creación de enemigos:
                 while (true)
                {
                    if(Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey();
                    }
                    Console.Clear(); algo asi como dibujo
                    Syste.Threading.Thread.Sleep(500); setear para ajustar el "dormir" del while, asi los enemigos no son demasiado rapidos.

                    Hacer clases para mejorar la prolijidad.

                    ignorar los bin y obj al comitear.
                }
                 */
            }
        }

    }

}


