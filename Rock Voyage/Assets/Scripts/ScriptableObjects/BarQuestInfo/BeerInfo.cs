using System;
using System.Collections.Generic;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarQuestInfo/BeerInfo")]
    public class BeerInfo : BarQuestInfo
    {
        [SerializeField]
        private TextAsset _questInfoAsset;

        public KeyValuePair<int, int>[] GoalsAndSteps { get; private set; }

        public override void FillInfo()
        {
            if ((GoalsAndSteps != null) && (GoalsAndSteps.Length != 0))
            {
                return;
            }
            base.FillInfo();

            string[] beerInfoValues = _questInfoAsset.text.Split(Environment.NewLine);
            GoalsAndSteps = new KeyValuePair<int, int>[beerInfoValues.Length];
            for (int i = 0; i < GoalsAndSteps.Length; i++)
            {
                int[] goalAndStep = Array.ConvertAll(beerInfoValues[i].Split(' '), int.Parse);
                GoalsAndSteps[i] = new KeyValuePair<int, int>(goalAndStep[0], goalAndStep[1]);
            }
        }
    }
}