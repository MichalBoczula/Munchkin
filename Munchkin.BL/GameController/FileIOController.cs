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

        public FileIOController(string filePath)
        {
            this.filePath = filePath;
        }

        public Game ReadSavedGame()
        {
            using var reader = new StreamReader(filePath);
            var ele = reader.ReadToEnd();
            Game games = JsonConvert.DeserializeObject<Game>(ele);
            return games;
        }

        public void SaveGame(Game game)
        {
            using StreamWriter streamWriter = File.AppendText(filePath);
            using JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter)
            { 
                Formatting = Formatting.Indented
            };
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(jsonTextWriter, game);
            streamWriter.WriteLine("\n&&");
        }

    }
}
