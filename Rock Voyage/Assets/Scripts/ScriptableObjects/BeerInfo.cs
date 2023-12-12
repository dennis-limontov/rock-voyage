using System;
using System.Collections.Generic;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BeerInfo")]
    public class BeerInfo : ScriptableObject
    {
        [SerializeField]
        private TextAsset _beerInfoAsset;
        public KeyValuePair<int, int>[] GoalsAndSteps { get; private set; }

        public void FillBeerInfo()
        {
            if ((GoalsAndSteps != null) && (GoalsAndSteps.Length != 0))
            {
                return;
            }

            string[] beerInfoValues = _beerInfoAsset.text.Split(Environment.NewLine);
            GoalsAndSteps = new KeyValuePair<int, int>[beerInfoValues.Length];
            for (int i = 0; i < GoalsAndSteps.Length; i++)
            {
                int[] goalAndStep = Array.ConvertAll(beerInfoValues[i].Split(' '), int.Parse);
                GoalsAndSteps[i] = new KeyValuePair<int, int>(goalAndStep[0], goalAndStep[1]);
            }
        }
    }
}