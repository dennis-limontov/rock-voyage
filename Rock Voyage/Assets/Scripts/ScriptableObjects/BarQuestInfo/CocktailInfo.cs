using System;
using System.Collections.Generic;

namespace RockVoyage
{
    [Serializable]
    public class CocktailInfo
    {
        public string Name { get; set; }
        public KeyValuePair<string, float>[] Ingredients { get; set; }
    }
}
