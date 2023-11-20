using System;
using System.Collections.Generic;
using System.IO;

namespace RockVoyage
{
    public static class LoadSaveManager
    {
        public static List<ILoadSave> loadSaveList = new List<ILoadSave>();

        private static readonly string SAVE_FOLDER_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.GAME_NAME);
        private static readonly string SAVE_FILE_PATH = Path.Combine(SAVE_FOLDER_PATH, "save.json");

        public static void Load()
        {
            string[] serializedData;
            
            if (File.Exists(SAVE_FILE_PATH))
            {
                serializedData = File.ReadAllLines(SAVE_FILE_PATH);
                for (int i = 0; i < loadSaveList.Count; i++)
                {
                    loadSaveList[i].Load(serializedData[i]);
                }
            }
        }

        public static void Save()
        {
            string[] serializedData = new string[loadSaveList.Count];
            for (int i = 0; i < loadSaveList.Count; i++)
            {
                serializedData[i] = loadSaveList[i].Save();
            }

            if (!Directory.Exists(SAVE_FOLDER_PATH))
            {
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }
            File.WriteAllLines(SAVE_FILE_PATH, serializedData);
        }
    }
}