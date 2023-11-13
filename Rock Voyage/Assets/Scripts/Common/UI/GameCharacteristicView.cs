using System;
using System.Globalization;
using UnityEngine;

namespace RockVoyage
{
    public class GameCharacteristicView : UIBase
    {
        [SerializeField]
        protected GameAttributes attribute;

        protected string _textFormat;

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            EventHub.OnValueChanged += UpdateCharacteristic;
            _textFormat = attribute switch
            {
                GameAttributes.Energy => "f2 \\%",
                GameAttributes.CrowdHappiness or GameAttributes.Fame
                    or GameAttributes.PerfomanceQuality => "p2",
                GameAttributes.Money or GameAttributes.MoneyProfit => "d \\$",
                GameAttributes.Time => Constants.DATE_STRING_FORMAT,
                _ => string.Empty
            };
        }

        protected virtual void UpdateCharacteristic(GameAttributes attribute,
            object oldValue, object newValue)
        {
            if (this.attribute == attribute)
            {
                if (newValue is DateTime dateTimeValue)
                {
                    UpdateCharacteristic((DateTime)oldValue, dateTimeValue);
                }
                else if (newValue is float floatValue)
                {
                    UpdateCharacteristic((float)oldValue, floatValue);
                }
                else if (newValue is int intValue)
                {
                    UpdateCharacteristic((int)oldValue, intValue);
                }
                else if (newValue is string stringValue)
                {
                    UpdateCharacteristic(oldValue.ToString(), stringValue);
                }
            }
        }

        protected virtual void UpdateCharacteristic(DateTime oldValue, DateTime newValue)
        {
            UpdateCharacteristic(oldValue.ToString(_textFormat, CultureInfo.InvariantCulture),
                newValue.ToString(_textFormat, CultureInfo.InvariantCulture));
        }

        protected virtual void UpdateCharacteristic(float oldValue, float newValue)
        {
            UpdateCharacteristic(oldValue.ToString(_textFormat), newValue.ToString(_textFormat));
        }

        protected virtual void UpdateCharacteristic(int oldValue, int newValue)
        {
            UpdateCharacteristic(oldValue.ToString(), newValue.ToString());
        }

        protected virtual void UpdateCharacteristic(string oldValue, string newValue)
        {
        }

        protected virtual void OnDestroy()
        {
            EventHub.OnValueChanged -= UpdateCharacteristic;
        }
    }
}