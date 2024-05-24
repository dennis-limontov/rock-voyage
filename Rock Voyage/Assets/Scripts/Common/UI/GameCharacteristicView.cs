using System;
using UnityEngine;

namespace RockVoyage
{
    public class GameCharacteristicView : UIBase
    {
        [SerializeField]
        protected GameAttributes attribute;

        protected string _textFormat;

        public override void Enter()
        {
            base.Enter();
            EventHub.OnValueChanged += UpdateCharacteristic;
        }

        public override void Exit()
        {
            EventHub.OnValueChanged -= UpdateCharacteristic;
            base.Exit();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _textFormat = attribute switch
            {
                GameAttributes.CrowdHappiness or GameAttributes.Energy
                    or GameAttributes.Fame or GameAttributes.PerfomanceQuality => "p2",
                GameAttributes.Money or GameAttributes.MoneyProfit => "0 \\$",
                _ => string.Empty
            };
        }

        protected virtual void UpdateCharacteristic(GameAttributes attribute,
            object oldValue, object newValue)
        {
            if (this.attribute == attribute)
            {
                switch (newValue)
                {
                    case string stringValue:
                        UpdateCharacteristic(oldValue.ToString(), stringValue);
                        break;
                    case IFormattable formattableValue:
                        UpdateCharacteristic((IFormattable)oldValue, formattableValue);
                        break;
                }
            }
        }

        protected virtual void UpdateCharacteristic(IFormattable oldValue, IFormattable newValue)
        {
            UpdateCharacteristic(oldValue.ToString(_textFormat, null), newValue.ToString(_textFormat, null));
        }
        protected virtual void UpdateCharacteristic(string oldValue, string newValue)
        {
        }
    }
}