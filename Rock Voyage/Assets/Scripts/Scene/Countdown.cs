using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class Countdown : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private int countdown = 3;
        private const string GO = "LET'S ROCK!!!";

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            SceneEvents.OnSongChosen += SongChosenHandler;
            transform.parent.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            SceneEvents.OnSongChosen -= SongChosenHandler;
        }

        private void SongChosenHandler()
        {
            transform.parent.gameObject.SetActive(true);
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            while (countdown >= 0)
            {
                if (countdown == 0)
                {
                    _text.text = GO;
                }
                else
                {
                    _text.text = countdown.ToString();
                }
                countdown--;
                DOTween.Sequence()
                    .Append(transform.DOScale(3f, 1f))
                    .Append(transform.DOScale(1f, 0f));

                yield return new WaitForSeconds(1f);
            }

            SceneEvents.OnCountdownEnded?.Invoke();
            transform.parent.gameObject.SetActive(false);
        }
    }
}