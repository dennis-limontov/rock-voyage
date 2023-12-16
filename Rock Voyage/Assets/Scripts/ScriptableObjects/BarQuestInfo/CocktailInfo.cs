using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/CocktailInfo")]
    public class CocktailInfo : ScriptableObject
    {
        [SerializeField]
        private TextAsset _cocktailInfoAsset;

        public string Name { get; private set; }
        public KeyValuePair<string, float>[] Ingredients { get; private set; }

        public void FillInfo()
        {
            if ((Ingredients != null) && (Ingredients.Length != 0))
            {
                return;
            }

            string[] cocktailInfoValues = _cocktailInfoAsset.text.Split(Environment.NewLine);
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
