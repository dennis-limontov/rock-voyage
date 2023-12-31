using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RockVoyage
{
    public static class LoadSaveManager
    {
        public static Dictionary<string, ILoadSave> loadSaveList = new Dictionary<string, ILoadSave>();

        private static readonly string SAVE_FOLDER_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.GAME_NAME);
        private static readonly string SAVE_FILE_PATH = Path.Combine(SAVE_FOLDER_PATH, "save.json");
        private static readonly string SAVE_FILE_PATTERN = "*.json";

        static LoadSaveManager()
        {
            JsonConvert.DefaultSettings = (() => new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            });
        }

        public static void Add(string name, ILoadSave loadSave)
        {
            loadSaveList[name] = loadSave;
        }

        public static void Remove(string name)
        {
            loadSaveList.Remove(name);
        }

        public static string[] GetSavedGamesList()
        {
            string[] savedGames = Directory.GetFiles(SAVE_FOLDER_PATH, SAVE_FILE_PATTERN);
            for (int i = 0; i < savedGames.Length; i++)
            {
                savedGames[i] = Path.GetFileNameWithoutExtension(savedGames[i]);
            }
            return savedGames;
        }

        public static void Load()
        {
            if (!File.Exists(SAVE_FILE_PATH))
            {
                return;
            }

            string serializedData = File.ReadAllText(SAVE_FILE_PATH);
            KeyValuePair<string, string>[] deserialized = JsonConvert
                .DeserializeObject<KeyValuePair<string, string>[]>(serializedData);
            foreach (var keyValue in deserialized)
            {
                if (loadSaveList.TryGetValue(keyValue.Key, out ILoadSave loadSave))
                {
                    loadSave.Load(keyValue.Value);
                }
            }
        }

        public static void Save()
        {
            string serializedData = JsonConvert.SerializeObject(loadSaveList.Select(x
                => new KeyValuePair<string, string>(x.Key, x.Value.Save())));

            if (!Directory.Exists(SAVE_FOLDER_PATH))
            {
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }
            File.WriteAllText(SAVE_FILE_PATH, serializedData);
        }
    }
}