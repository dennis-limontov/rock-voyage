using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/CocktailList")]
    public class CocktailList : BarQuestInfo
    {
        [SerializeField]
        private CocktailInfo[] _cocktails;
        public CocktailInfo[] Cocktails => _cocktails;

        public override void FillInfo()
        {
            base.FillInfo();
            foreach (var cocktail in _cocktails)
            {
                cocktail.FillInfo();
            }
        }
    }
}
