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

        private KeyValuePair<int, int>[] _goalsAndSteps;
        public KeyValuePair<int, int>[] GoalsAndSteps => _goalsAndSteps;

        public void FillBeerInfo()
        {
            if ((_goalsAndSteps != null) && (_goalsAndSteps.Length != 0))
            {
                return;
            }

            string[] _beerInfoValues = _beerInfoAsset.text.Split(Environment.NewLine);
            _goalsAndSteps = new KeyValuePair<int, int>[_beerInfoValues.Length];
            for (int i = 0; i < _goalsAndSteps.Length; i++)
            {
                string[] goalAndStep = _beerInfoValues[i].Split(' ');
                _goalsAndSteps[i] = new KeyValuePair<int, int>(int.Parse(goalAndStep[0]), int.Parse(goalAndStep[1]));
            }
        }
    }
}