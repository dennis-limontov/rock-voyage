using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class Countdown : UIBase
    {
        private TextMeshProUGUI _text;
        private int _countdown = 3;
        private const string GO = "LET'S ROCK!!!";

        public override void Enter()
        {
            base.Enter();
            _countdown = 3;
            StartCoroutine(CountdownCoroutine());
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _text = GetComponent<TextMeshProUGUI>();
        }

        private IEnumerator CountdownCoroutine()
        {
            while (_countdown >= 0)
            {
                if (_countdown == 0)
                {
                    _text.text = GO;
                }
                else
                {
                    _text.text = _countdown.ToString();
                }
                _countdown--;
                DOTween.Sequence()
                    .Append(transform.DOScale(3f, 1f))
                    .Append(transform.DOScale(1f, 0f));

                yield return new WaitForSeconds(1f);
            }

            SceneEvents.OnCountdownEnded?.Invoke();
        }
    }
}