using System;

namespace RockVoyage
{
    [Serializable]
    public class IngredientInfo
    {
        public string Name { get; set; }
        public float[] Doses { get; set; }
        public string Measure { get; set; }
    }
}
