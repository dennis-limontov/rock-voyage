using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SongsList")]
    public class SongsList : ScriptableObject, IEnumerable<SongInfo>
    {
        [SerializeField]
        private SongInfo[] _songs;
        public SongInfo this[string song] => _songs
            .First(x => x.SongName.Equals(song));
        public SongInfo this[int index] => _songs[index];

        public int Length => _songs.Length;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<SongInfo> GetEnumerator()
        {
            return ((IEnumerable<SongInfo>)_songs).GetEnumerator();
        }

        public string GetRandomUnknownSong()
        {
            if (Length <= GameCharacteristics.AvailableSongs.Count)
            {
                return null;
            }
            var unknownSongs = _songs.Select(x => x.SongName)
                .Except(GameCharacteristics.AvailableSongs).ToArray();
            int randomIndex = Random.Range(0, unknownSongs.Length);
            return unknownSongs[randomIndex];
        }
    }
}