using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/CocktailInfo")]
    public class CocktailInfo : BarQuestInfo
    {
        [SerializeField]
        private TextAsset _questInfoAsset;

        private Cocktail _cocktail;

        public string Name => _cocktail.Name;
        public KeyValuePair<string, float>[] Ingredients => _cocktail.Ingredients;

        public override void FillInfo()
        {
            if ((_cocktail != null) && (Ingredients != null) && (Ingredients.Length != 0))
            {
                return;
            }
            base.FillInfo();

            _cocktail = JsonConvert.DeserializeObject<Cocktail>(_questInfoAsset.text);
        }

        [Serializable]
        private class Cocktail
        {
            public string Name { get; set; }
            public KeyValuePair<string, float>[] Ingredients { get; set; }
        }
    }
}
