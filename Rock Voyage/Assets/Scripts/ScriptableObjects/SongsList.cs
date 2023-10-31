using System.Linq;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SongsList")]
    public class SongsList : ScriptableObject
    {
        [SerializeField]
        private SongInfo[] _songs;
        public SongInfo this[string song] => _songs
            .Where(x => x.SongName.Equals(song))
            .FirstOrDefault();
        public SongInfo this[int index] => _songs[index];

        public int Length => _songs.Length;
    }
}