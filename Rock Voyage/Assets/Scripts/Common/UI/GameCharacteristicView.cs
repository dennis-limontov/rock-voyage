using System;
using System.Globalization;
using UnityEngine;

namespace RockVoyage
{
    public class GameCharacteristicView : UIBase
    {
        [SerializeField]
        protected GameAttributes attribute;

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            EventHub.OnValueChanged += UpdateCharacteristic;
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
            UpdateCharacteristic(oldValue.ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture),
                newValue.ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture));
        }

        protected virtual void UpdateCharacteristic(float oldValue, float newValue)
        {
            UpdateCharacteristic(oldValue.ToString("f2"), newValue.ToString("f2"));
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