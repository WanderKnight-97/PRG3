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
            //bool anima = false;
            bool vivo = true;
            //bool sepuede = true;

            string tecla = "";
            string p = "P";
            //string pj2 = "p";
            string limite = "█";

            int min = 0;
            int max = 50;
            int bCant = max / 4;
            Random r = new Random();
            int x = max / 2;
            int y = max / 2;
            int[] bX = new int[bCant];
            int[] bY = new int[bCant];
            int randNum;
            int i = 0;
            string[] bombas = new string[bCant];
            while (i != bCant)
            {
                randNum = r.Next(min + 1, max - 1);
                bX[i] = randNum;
                randNum = r.Next(min + 1, max - 1);
                bY[i] = randNum;
                bombas[i] = "B";
                i++;
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
            Console.SetCursorPosition(0, y + 3);
            Console.WriteLine("W A S D para mover al personaje(P). Presione x para salir");
            while (end == false)
            {

                i = 0;
                while (i != bCant)
                {
                    Console.SetCursorPosition(bX[i], bY[i]);
                    Console.WriteLine(bombas[i]);
                    i++;
                }
                Console.SetCursorPosition(x, y);
                if (vivo == true)
                {

                    if (x == max || y == max || x == min + 1 || y == min + 1)
                    {
                        //sepuede = false;
                        Console.WriteLine(limite);
                    }
                    else if (x != max || y != max || x != min + 1 || y != min + 1)
                    {
                        Console.WriteLine(p);
                        //sepuede = true;

                    }
                    /*if (sepuede == true)
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
                    }*/

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
                    while (i != bCant)
                    {
                        if (x == bX[i] && y == bY[i])
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
                }
                 */
            }
                }
        
        }
           
        }
    

