using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RockVoyage
{
    public static class LoadSaveManager
    {
        public static Dictionary<string, ILoadSave> loadSaveList = new Dictionary<string, ILoadSave>();

        private static readonly string SAVE_FOLDER_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.GAME_NAME);
        private static readonly string SAVE_FILE_PATH = Path.Combine(SAVE_FOLDER_PATH, "save.json");

        public static void Load()
        {
            string[] serializedData;

            if (!File.Exists(SAVE_FILE_PATH))
            {
                return;
            }
            serializedData = File.ReadAllLines(SAVE_FILE_PATH);
            foreach (string line in serializedData)
            {
                (string Key, string Value) keyValue
                    = JsonConvert.DeserializeObject<(string, string)>(line);
                if (loadSaveList.TryGetValue(keyValue.Key, out ILoadSave loadSave))
                {
                    loadSave.Load(keyValue.Value);
                }
            }
        }

        public static void Save()
        {
            string[] serializedData = new string[loadSaveList.Count];
            int i = 0;
            foreach (KeyValuePair<string, ILoadSave> keyValue in loadSaveList)
            {
                serializedData[i++] = JsonConvert.SerializeObject((keyValue.Key,
                    keyValue.Value.Save()));
            }

            if (!Directory.Exists(SAVE_FOLDER_PATH))
            {
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }
            File.WriteAllLines(SAVE_FILE_PATH, serializedData);
        }
    }
}