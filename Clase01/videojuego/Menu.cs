using System;


namespace videojuego
{
    class Menu
    {
        private ConsoleKeyInfo key;
        public bool GameMenu()
        {
            Clima c = new Clima();
            c.ShowWeather();
            WelcomeMsj msj = new WelcomeMsj();
            HighScore hs = new HighScore();
            msj.InsertMsj();
            Console.WriteLine(msj.ReadMsj());
            Console.WriteLine("Bienvenido. Oprima la letra P para iniciar el juego, pulse X para salir.");
            hs.ReadHScore();

            while (true)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.P:
                        Console.Clear();
                        return false;
                        break;
                    case ConsoleKey.X:
                        return true;
                        break;
                    default:
                        Console.WriteLine("Datos invalidos. Por favor ingrese lo solicitado.");
                        break;
                }
            }
        }
    }
}
