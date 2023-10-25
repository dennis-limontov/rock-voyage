using System;
using System.Globalization;
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

        private float _keysSpeed = 0f;

        private RectTransform _keysTransform;

        public static float noteLength;

        private void OnDestroy()
        {
            Events.OnCountdownEnded -= CountdownEndedHandler;
        }

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
                float keyDuration = float.Parse(keyInfo[1],
                    CultureInfo.InvariantCulture); // 0.5
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

            _penalty = 1f / (bars * divider * 4f);
            noteLength = _bsParanoidSO.MusicForGroup.length / _resultKeys.Length;
            _keysTransform = GetComponent<RectTransform>();
            Events.OnCountdownEnded += CountdownEndedHandler;
        }

        private void Update()
        {
            _keysTransform.anchoredPosition -= new Vector2(_keysSpeed
                * Time.deltaTime, 0f);
        }

        private void CountdownEndedHandler()
        {
            _keysSpeed = _penalty * 2250000f;
        }
    }
}