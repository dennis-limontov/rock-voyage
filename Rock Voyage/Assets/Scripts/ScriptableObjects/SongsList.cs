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
            .Where(x => x.SongName.Equals(song))
            .FirstOrDefault();
        public SongInfo this[int index] => _songs[index];

        public int Length => _songs.Length;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<SongInfo> GetEnumerator()
        {
            return new SongsListEnumerator(_songs);
        }

        public class SongsListEnumerator : IEnumerator<SongInfo>
        {
            private SongInfo[] _songs;

            private int position = -1;

            object IEnumerator.Current => Current;

            public SongInfo Current => _songs[position];

            public SongsListEnumerator(SongInfo[] songs)
            {
                _songs = songs;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                position++;
                return (position < _songs.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}