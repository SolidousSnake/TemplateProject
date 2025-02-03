using System.IO;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Data.Persistent;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Code.Runtime.Services.SaveLoad
{
    public class JsonSaveLoadService : ISaveLoadService
    {
        private readonly string _filePath = Application.persistentDataPath + Constants.PlayerProgress;

        public void Save(PlayerProgress progress)
        {
            string json = JsonConvert.SerializeObject(progress);
            File.WriteAllText(_filePath, json);
        }
        
        public PlayerProgress Load()
        {
            if (!File.Exists(_filePath))
                return new PlayerProgress();
        
            string json = File.ReadAllText(_filePath);
            PlayerProgress progress = JsonConvert.DeserializeObject<PlayerProgress>(json);
            return progress;
        }

        public void Reset() => Save(new PlayerProgress());
    }
}