using Newtonsoft.Json;
using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/CocktailList")]
    public class CocktailList : BarQuestInfo
    {
        [SerializeField]
        private TextAsset _ingredientsAsset;

        [SerializeField]
        private TextAsset[] _cocktailsAssets;

        public CocktailInfo[] Cocktails { get; private set; }

        public IngredientInfo[] Ingredients { get; private set; }

        public override void FillInfo()
        {
            if (Ingredients != null && Ingredients.Length != 0)
            {
                return;
            }
            base.FillInfo();

            Ingredients = JsonConvert.DeserializeObject<IngredientInfo[]>(_ingredientsAsset.text);
            Cocktails = new CocktailInfo[_cocktailsAssets.Length];
            for (int i = 0; i < _cocktailsAssets.Length; i++)
            {
                Cocktails[i] = JsonConvert.DeserializeObject<CocktailInfo>(_cocktailsAssets[i].text);
            }
        }
    }
}
