using UnityEngine;

namespace RockVoyage
{
    public class Cocktail : BarQuestController
    {
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

        public override void Enter()
        {
            base.Enter();
            CocktailList cocktailList = (CocktailList)questInfo;
            int randIndex = Random.Range(0, cocktailList.Cocktails.Length);
            //CocktailInfo cocktailInfo = cocktailList.Cocktails[randIndex];
            //CocktailName = cocktailInfo.Name;
        }
    }
}
