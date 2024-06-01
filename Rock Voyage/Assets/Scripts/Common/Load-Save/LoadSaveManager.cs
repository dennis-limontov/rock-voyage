using Newtonsoft.Json;
using JsonHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

namespace RockVoyage
{
    public static class LoadSaveManager
    {
        private static readonly string SAVE_FOLDER_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.GAME_NAME);
        private static readonly string SAVE_FILE_PATH = Path.Combine(SAVE_FOLDER_PATH, "save.json");
        private static readonly string SAVE_FILE_PATTERN = "*.json";

        public static readonly Dictionary<string, ILoadSaveRoot> loadSaveRoots = new Dictionary<string, ILoadSaveRoot>();
        private static JObject _loadedDataStorage = new JObject();
        private static JObject _tempDataCache;

        private static readonly JsonSerializer _serializer;

        public static bool NeedSave { get; set; }

        static LoadSaveManager()
        {
            JsonConvert.DefaultSettings = (() => new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                ContractResolver = new ShouldSerializeContractResolver(),
            });
            _serializer = JsonSerializer.CreateDefault();
        }

        public static void Add(string name, ILoadSaveRoot loadSave)
        {
            loadSaveRoots[name] = loadSave;
            Populate(loadSave, name);
        }

        public static void Remove(string name)
        {
            if (loadSaveRoots.Remove(name, out ILoadSaveRoot removed) && NeedSave)
            {
                _loadedDataStorage[name] = JObject.FromObject(removed);
            }
        }

        private static void Populate(ILoadSaveRoot loadSave, string key)
        {
            if (_loadedDataStorage.Remove(key, out JToken value))
            {
                using (var reader = value.CreateReader())
                {
                    _serializer.Populate(reader, loadSave);
                }
            }
        }

        public static void Load()
        {
            if (!File.Exists(SAVE_FILE_PATH))
            {
                return;
            }

            NeedSave = false;
            ResetGameData();
            using (var sr = File.OpenText(SAVE_FILE_PATH))
            using (var reader = new JsonTextReader(sr))
            {
                _tempDataCache = _serializer.Deserialize<JObject>(reader);
            }
            JToken sceneNameToken;
            _tempDataCache.Remove("SceneName", out sceneNameToken);
            string sceneName = sceneNameToken?.Value<string>();
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
            var deserialized = new JObject()
            {
                { "SceneName", GameCharacteristics.MapInfo.SceneName }
            };
            deserialized.Merge(JObject.FromObject(loadSaveRoots));
            deserialized.Merge(_loadedDataStorage);

            if (!Directory.Exists(SAVE_FOLDER_PATH))
            {
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }

            using (StreamWriter sw = File.CreateText(SAVE_FILE_PATH))
            using (var writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, deserialized);
            }
        }

        private static void SceneLoadedHandler(HouseInfo info)
        {
            NeedSave = true;
            MapEvents.OnSceneLoaded -= SceneLoadedHandler;
            _loadedDataStorage = new JObject(_tempDataCache);
            foreach (var keyValue in _tempDataCache)
            {
                if (loadSaveRoots.TryGetValue(keyValue.Key, out ILoadSaveRoot loadSave))
                {
                    Populate(loadSave, keyValue.Key);
                }
            }
            _tempDataCache = null;
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

        public static void Reset()
        {
            _loadedDataStorage = new JObject();
        }

        public static void ResetGameData()
        {
            Reset();
            foreach (ILoadSaveRoot loadSave in loadSaveRoots.Values)
            {
                loadSave.Reset();
            }
        }
    }
}