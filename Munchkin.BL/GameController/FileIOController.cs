using Munchkin.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class FileIOController
    {
        private string filePath;
        private StreamWriter streamWriter;
        private JsonWriter jsonWriter;
        private JsonSerializer jsonSerializer;

        public FileIOController(string filePath)
        {
            this.filePath =  @"A:\Programowanie\C#\Kurs\Apps\Munchkin\Saves\GameSaves.txt";
            streamWriter = new StreamWriter(filePath);
            jsonWriter = new JsonTextWriter(streamWriter);
            jsonSerializer = new JsonSerializer();
            CreateFile();
        }

        private void CreateFile()
        {
            using FileStream fs = File.Create(filePath);
        }

        public List<Game> ReadSavedGame()
        {
            List<Game> games;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                games = JsonConvert.DeserializeObject<List<Game>>(json);
            }
            return games;
        }

        public void SaveGame(Game game)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, game);
            }
        }
    }
}
