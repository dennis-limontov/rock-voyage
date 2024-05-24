using JsonHelpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    [Serializable, DataContract, JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PlayersList : ILoadSaveRoot, IEnumerable<KeyValuePair<string, PlayerCharacteristics>>
    {
        public static readonly PlayersList Instance = new PlayersList();

        public string Name => nameof(PlayersList);

        [DataMember]
        [JsonConverter(typeof(ReusableDictionaryConverter<string, PlayerCharacteristics>))]
        private Dictionary<string, PlayerCharacteristics> players
            = new Dictionary<string, PlayerCharacteristics>(Constants.PLAYERS_MAX);

        public static PlayerCharacteristics CurrentPlayer => Instance[Instance.CurrentPlayerName];

        private string _currentPlayerName;
        public string CurrentPlayerName
        {
            get => _currentPlayerName;
            set
            {
                _currentPlayerName = value;
                players.TryAdd(value, new PlayerCharacteristics());
            }
        }

        public static void Reset()
        {
            Instance.Clear();
            Instance.CurrentPlayerName = "Player";
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Instance.AddLoadSaveable();
        }

        private PlayersList() { }

        #region IEnumerable
        public PlayerCharacteristics this[string name] => players[name];

        public int Length => players.Count;

        public void Clear()
        {
            players.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<KeyValuePair<string, PlayerCharacteristics>> GetEnumerator() =>
            ((IEnumerable<KeyValuePair<string, PlayerCharacteristics>>)players).GetEnumerator();
        #endregion
    }
}
