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
        private SongInfo _bsParanoidSO;

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
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
        }

        private void Start()
        {
            string[] _songKeys = _bsParanoidSO.KeysArray.text.Split(Environment.NewLine);
            int bars = int.Parse(_songKeys[0].Split(' ')[0]); // 113
            int divider = int.Parse(_songKeys[0].Split(' ')[1]); // 2
            _resultKeys = new char[bars * divider * 4]; // 904 = amount of 1/8 notes
            int m = 0;
            for (int i = 1; i < _songKeys.Length; i++)
            {
                string[] keyInfo = _songKeys[i].Split(' '); // x 4 8 s 1.5 1
                char key = char.Parse(keyInfo[0]); // x s
                float keyDuration = float.Parse(keyInfo[1], CultureInfo.InvariantCulture); // 4 1.5
                int keyAmount = int.Parse(keyInfo[2]); // 8 1
                int notesAmountInMinDuration = (int)(keyDuration * keyAmount * divider); // 64 3
                for (int j = 0; j < keyAmount; j++)
                {
                    var localKey = key;
                    for (int k = 0; k < keyDuration * divider; k++)
                    {
                        _resultKeys[m] = (localKey == '_') ? ' ' : localKey;

                        GameObject _newKey = Instantiate(_keyPrefab, _keysLayoutGroup.transform);
                        _newKey.GetComponentInChildren<TextMeshProUGUI>().text
                            = _resultKeys[m++].ToString();

                        if ((k == 0) && (keyDuration > (1f / divider)))
                        {
                            localKey = ' ';
                        }
                    }
                }
            }

            _penalty = 1f / (bars * divider * 4f); // 1/904
            noteLength = _bsParanoidSO.MusicForGroup.length / _resultKeys.Length; // 164/904 = 41/226

            _keysTransform = GetComponent<RectTransform>();
            GameObject keysCanvas = GetComponentInParent<Canvas>().gameObject;
            keysCanvas.SetActive(false);

            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
        }

        private void Update()
        {
            _keysTransform.position -= new Vector3(_keysSpeed * Time.deltaTime, 0f);
        }

        private void CountdownEndedHandler()
        {
            //_keysSpeed = _keysTransform.sizeDelta.x / _bsParanoidSO.MusicForGroup.length; // 90400/164 = 22600/41
            _keysSpeed = _keyPrefab.GetComponent<RectTransform>().sizeDelta.x * _resultKeys.Length
                / _bsParanoidSO.MusicForGroup.length;
        }
    }
}