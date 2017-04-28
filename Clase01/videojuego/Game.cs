using System;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace videojuego
{
    [Serializable]
    struct Position
    {
        public int x;
        public int y;
    }

    class Game
    {
        bool end = false;
        bool alive = true;
        PositionSave ps = new PositionSave();
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream jugadorPos;
        Personaje p;
        Position pPos;
        Menu menu = new Menu();
        HighScore puntuacionMax = new HighScore();
        Enemies[] enemies = new Enemies[5];
        Bombs[] bombs = new Bombs[5];
        PickUp[] pickUps = new PickUp[5];
        //Clima clm = new Clima();

        public void Jugar()
        {
            ConsoleKeyInfo key;
            Random r = new Random();

            end = menu.GameMenu();
            //clm.ShowWeather();

            if (!File.Exists("Position.txt"))
            {
                jugadorPos = File.Create("Position.txt");
                pPos.x = 5;
                pPos.y = 5;
            }
            else
            {
                using (jugadorPos = File.OpenRead("Position.txt"))
                    pPos = (Position)bFormatter.Deserialize(jugadorPos);
            }
            jugadorPos.Close();

            p = new Personaje(pPos.x, pPos.y);
            p.Draw();

            if (end == false && alive == true)
            {
                for(int i = 0; i < enemies.Length; i++)
                {
                    enemies[i] = new Enemies(r.Next(0, 84), r.Next(0, 29));
                    enemies[i].Draw();
                }
                for (int i = 0; i < bombs.Length; i++)
                {
                    bombs[i] = new Bombs(r.Next(0, 84), r.Next(0, 29));
                    bombs[i].Draw();
                }
                for (int i = 0; i < pickUps.Length; i++)
                {
                    pickUps[i] = new PickUp(r.Next(0, 84), r.Next(0, 29));
                    pickUps[i].Draw();
                }
            }

            while (end == false && alive == true)
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    p.Move(key);
                    alive = p.Exit(key);
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                p.Draw();

                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].Move();
                    enemies[i].Draw();
                    enemies[i].Collition(p);
                    if (p.GetHp() <= 0)
                        alive = false;
                }

                for (int i = 0; i < bombs.Length; i++)
                {
                    bombs[i].Collition(p);
                    if (p.GetHp() <= 0)
                        alive = false;
                }

                for (int i = 0; i < pickUps.Length; i++)
                {
                    pickUps[i].Collition(p);
                    pickUps[i].Draw();
                }

                if (alive == false)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    System.Threading.Thread.Sleep(1000);
                    puntuacionMax.SetHScore(pickUps[0].GetScore());
                }
                if (end == true)
                {
                    Console.Clear();
                    Console.WriteLine("Hasta la proxima!");
                    System.Threading.Thread.Sleep(1000);
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score: " + pickUps[0].GetScore());
                Console.WriteLine("Vidas restantes: " + p.GetHp());
                System.Threading.Thread.Sleep(90);

            }

            Console.Clear();
            ps.SavePos(p, pPos);
            Console.ReadKey();
        }
    }
}
