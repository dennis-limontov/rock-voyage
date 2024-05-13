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
        private CocktailInfo[] _cocktails;
        public CocktailInfo[] Cocktails => _cocktails;

        public Ingredient[] Ingredients { get; private set; }

        public override void FillInfo()
        {
            base.FillInfo();
            foreach (var cocktail in _cocktails)
            {
                cocktail.FillInfo();
            }
            
            Ingredients = JsonConvert.DeserializeObject<Ingredient[]>(_ingredientsAsset.text);
        }

        [Serializable]
        public class Ingredient
        {
            public string Name {  get; set; }
            public float[] Doses { get; set; }
            public string Measure { get; set; }
        }
    }
}
