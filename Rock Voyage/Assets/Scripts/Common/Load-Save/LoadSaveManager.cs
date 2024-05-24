using Newtonsoft.Json;
using JsonHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using static Newtonsoft.Json.JsonConvert;

namespace RockVoyage
{
    public static class LoadSaveManager
    {
        private static Dictionary<string, string> loadedDataStorage = new Dictionary<string, string>();
        public static Dictionary<string, ILoadSaveRoot> loadSaveRoots = new Dictionary<string, ILoadSaveRoot>();

        private static readonly string SAVE_FOLDER_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.GAME_NAME);
        private static readonly string SAVE_FILE_PATH = Path.Combine(SAVE_FOLDER_PATH, "save.json");
        private static readonly string SAVE_FILE_PATTERN = "*.json";

        static LoadSaveManager()
        {
            DefaultSettings = (() => new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                ContractResolver = new ShouldSerializeContractResolver(),
            });
        }

        public static void Add(string name, ILoadSaveRoot loadSave)
        {
            loadSaveRoots[name] = loadSave;
            if (loadedDataStorage.Remove(name, out string value))
            {
                PopulateObject(value, loadSave);
            }
        }

        public static void Remove(string name)
        {
            if (loadSaveRoots.Remove(name, out ILoadSaveRoot removed))
            {
                loadedDataStorage[name] = SerializeObject(removed);
            }
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

            loadedDataStorage = DeserializeObject<Dictionary<string, string>>(
                File.ReadAllText(SAVE_FILE_PATH));
            string sceneName;
            loadedDataStorage.Remove("SceneName", out sceneName);
            sceneName ??= Constants.Scenes.START_CITY;
            if (SceneManager.GetSceneByName(sceneName) == default)
            {
                MapEvents.OnSceneLoaded += SceneLoadedHandler;
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneLoadedHandler(null);
            }
        }

        public static void Save()
        {
            var deserialized = loadSaveRoots.ToDictionary(x => x.Key,
                x => SerializeObject(x.Value));
            deserialized = deserialized.Concat(loadedDataStorage).ToDictionary(x => x.Key, x => x.Value);
            deserialized.Add("SceneName", GameCharacteristics.MapInfo.SceneName);
            string serializedData = SerializeObject(deserialized);
            serializedData = Format(serializedData);

            if (!Directory.Exists(SAVE_FOLDER_PATH))
            {
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }
            File.WriteAllText(SAVE_FILE_PATH, serializedData);
        }

        private static string Format(string serializedData)
        {
            return serializedData.Replace("\\r", "\r").Replace("\\n", "\n");
        }

        private static void SceneLoadedHandler(HouseInfo info)
        {
            MapEvents.OnSceneLoaded -= SceneLoadedHandler;
            var deserialized = new Dictionary<string, string>(loadedDataStorage);
            foreach (var keyValue in deserialized)
            {
                if (loadSaveRoots.TryGetValue(keyValue.Key, out ILoadSaveRoot loadSave))
                {
                    PopulateObject(keyValue.Value, loadSave);
                    loadedDataStorage.Remove(keyValue.Key);
                }
            }
        }
    }
}