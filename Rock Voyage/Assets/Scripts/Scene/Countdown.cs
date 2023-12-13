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
        private const float TIME = 1f;
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
            float scale = transform.localScale.x;
            while (_countdown >= 0)
            {
                _text.text = (_countdown == 0) ? GO : _countdown.ToString();
                _countdown--;
                DOTween.Sequence()
                    .Append(transform.DOScale(scale * 2, TIME))
                    .Append(transform.DOScale(scale, 0f));

                yield return new WaitForSeconds(TIME);
            }

            SceneEvents.OnCountdownEnded?.Invoke();
        }
    }
}