using System;
using System.IO;
using System.Text;

namespace videojuego
{
    class HighScore
    {
        int hscore;
        string name;
        public HighScore()
        {
            hscore = 0;
            name = "AAA";
        }
        public HighScore(int hscore, string name)
        {
            this.hscore = hscore;
            this.name = name;
        }
        public void SetHScore(int score)
        {
            if (!File.Exists("HIGHSCORE.bin"))
            {
                FileStream hScoreFile = new FileStream("HIGHSCORE.bin", FileMode.Create);
                hScoreFile.Close();
            }
            BinaryWriter bWriter = new BinaryWriter(File.Open("HIGHSCORE.bin", FileMode.Open));
            if (!(score > hscore))
            {
                bWriter.Write(name);
                bWriter.Write(" ");
                bWriter.Write(hscore);
                bWriter.Close();
            }
            if (score > hscore)
            {
                Console.WriteLine("Nuevo record!");
                Console.WriteLine("Ingrese su nombre por favor: ");
                name = Console.ReadLine();
                hscore = score;
                bWriter.Write(name);
                bWriter.Write(" ");
                bWriter.Write(hscore);
                bWriter.Close();
            }
        }

        public void ReadHScore()
        {
            if (File.Exists("HIGHSCORE.bin"))
            {
                BinaryReader bReader = new BinaryReader(File.Open("HIGHSCORE.bin", FileMode.Open));
                Console.Write("HIGHSCORE: " + bReader.ReadString() + " " + bReader.ReadInt32());
                bReader.Close();
            }
        }
    }
}
