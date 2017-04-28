using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace videojuego
{
    class PositionSave
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream playerPos;

        public void SavePos(Personaje player, Position pos)
        {
            pos.x = player.GetX();
            pos.y = player.GetY();
            using (playerPos = File.OpenWrite("Position.txt"))
            {
                formatter.Serialize(playerPos, pos);
            }
            playerPos.Close();
        }
    }
}
