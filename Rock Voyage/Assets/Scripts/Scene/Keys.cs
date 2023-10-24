using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class Keys : MonoBehaviour
    {
        [SerializeField]
        private BlackSabbathParanoid _bsParanoidSO;

        [SerializeField]
        private HorizontalLayoutGroup _keysLayoutGroup;

        [SerializeField]
        private GameObject _keyPrefab;

        private char[] _resultKeys;
        public char[] ResultKeys => _resultKeys;

        private float _penalty;
        public float Penalty => _penalty;

        public static float noteLength;

        private void Start()
        {
            string[] _songKeys = _bsParanoidSO.KeysArray.text.Split(Environment.NewLine);
            int bars = int.Parse(_songKeys[0].Split(' ')[0]); // 113
            int divider = int.Parse(_songKeys[0].Split(' ')[1]); // 2
            _resultKeys = new char[bars * divider * 4];
            int k = 0;
            for (int i = 1; i < _songKeys.Length; i++)
            {
                string[] keyInfo = _songKeys[i].Split(' '); // w 0.5 1
                char key = char.Parse(keyInfo[0]); // w
                float keyDuration = float.Parse(keyInfo[1]); // 0.5
                int keyAmount = int.Parse(keyInfo[2]); // 1
                for (int j = 0; j < keyDuration * keyAmount * divider; j++)
                {
                    if (key == '_')
                    {
                        _resultKeys[k] = ' ';
                    }
                    else
                    {
                        _resultKeys[k] = key;
                    }
                    
                    GameObject _newKey = Instantiate(_keyPrefab,
                        _keysLayoutGroup.transform);
                    _newKey.GetComponentInChildren<TextMeshProUGUI>().text
                        = _resultKeys[k++].ToString();
                }
            }

            _penalty = 1 / (bars * divider * 4);
            noteLength = _bsParanoidSO.MusicForGroup.length / _resultKeys.Length;
        }
    }
}