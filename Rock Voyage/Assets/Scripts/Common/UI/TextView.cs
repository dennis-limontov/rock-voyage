﻿using TMPro;

namespace RockVoyage
{
    public class TextView : GameCharacteristicView
    {
        private TextMeshProUGUI _text;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _text = GetComponent<TextMeshProUGUI>();
        }

        protected override void UpdateCharacteristic(string oldValue, string newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            _text.text = newValue;
        }
    }
}