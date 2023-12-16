using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/CocktailInfo")]
    public class CocktailInfo : BarQuestInfo
    {
        [SerializeField]
        private TextAsset _questInfoAsset;

        public string Name { get; private set; }
        public KeyValuePair<string, float>[] Ingredients { get; private set; }

        public override void FillInfo()
        {
            if ((Ingredients != null) && (Ingredients.Length != 0))
            {
                return;
            }
            base.FillInfo();

            string[] cocktailInfoValues = _questInfoAsset.text.Split(Environment.NewLine);
            Ingredients = new KeyValuePair<string, float>[cocktailInfoValues.Length - 1];
            Name = cocktailInfoValues[0];
            for (int i = 1; i < cocktailInfoValues.Length; i++)
            {
                string[] ingredientInfo = cocktailInfoValues[i].Split(' ');
                Ingredients[i - 1] = new KeyValuePair<string, float>(ingredientInfo[0],
                    float.Parse(ingredientInfo[1], CultureInfo.InvariantCulture));
            }
        }
    }
}
