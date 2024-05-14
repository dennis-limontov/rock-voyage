using System.Collections.Generic;
using UnityEngine;

namespace RockVoyage
{
    public class Cocktail : BarQuestController
    {
        private CocktailList _cocktailList;

        private string _cocktailName;
        public string CocktailName
        {
            get => _cocktailName;
            set
            {
                _cocktailName = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.CocktailName, string.Empty, value);
            }
        }

        private KeyValuePair<string, float>[] _ingredients;

        private int _currentIngredientIndex;
        public int CurrentIngredientIndex
        {
            get => _currentIngredientIndex;
            set
            {
                _currentIngredientIndex = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.CocktailIngredient,
                    string.Empty, $"( {_ingredients[value].Key} )");
                EventHub.OnValueChanged?.Invoke(GameAttributes.CocktailSteps,
                    string.Empty, $"{_currentIngredientIndex + 1}/{_ingredients.Length}");
            }
        }

        public override void Enter()
        {
            base.Enter();
            _cocktailList = (CocktailList)questInfo;
            int randIndex = Random.Range(0, _cocktailList.Cocktails.Length);
            CocktailInfo cocktailInfo = _cocktailList.Cocktails[randIndex];
            CocktailName = cocktailInfo.Name;
            _ingredients = cocktailInfo.Ingredients;
            CurrentIngredientIndex = 0;
        }
    }
}