using System;
using System.IO;
using System.Text;

namespace videojuego
{
    class WelcomeMsj
    {
        private string msj;
        public WelcomeMsj()
        {
            msj = "";
        }

        public void InsertMsj()
        {
            if (!(File.Exists("Msj.txt")))
            {
                Console.WriteLine("Ingrese bienvenida");
                msj = Console.ReadLine();
                Console.WriteLine("Saludo guardado");
                FileStream file = new FileStream("Msj.txt", FileMode.Create, FileAccess.Write);
                if (file.CanWrite)
                {
                    byte[] bufferus = Encoding.ASCII.GetBytes(msj);
                    file.Write(bufferus, 0, bufferus.Length);
                }
                file.Flush();
                file.Close();
            }
        }

        public string ReadMsj()
        {
            try
            {
                FileStream file = new FileStream("Msj.txt", FileMode.Open, FileAccess.Read);
                byte[] bufferus = new byte[1024];
                int bytesread = file.Read(bufferus, 0, bufferus.Length);
                return Encoding.ASCII.GetString(bufferus, 0, bytesread);
            }
            catch (Exception e)
            {
                Console.WriteLine("sin mensaje");
                return "";
            }
        }
    }
}
