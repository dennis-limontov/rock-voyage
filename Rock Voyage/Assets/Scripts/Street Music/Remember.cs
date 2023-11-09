using System.Linq;
using UnityEngine;

namespace RockVoyage
{
    public class Remember : UIActiveOneChild
    {
        [SerializeField]
        private SongsList _songsList;

        [SerializeField]
        private UIBase _failRememberText;

        [SerializeField]
        private UIBase _successRememberText;

        [SerializeField]
        private UIBase _fulfilledKnowledgeText;

        public override void Enter()
        {
            base.Enter();
            if (GameCharacteristics.AvailableSongs.Count < _songsList.Length)
            {
                var rememberChance = Random.Range(0f, 1f);
                if (rememberChance <= Constants.REMEMBER_CHANCE)
                {
                    SongInfo[] unknownSongs = _songsList
                        .Except(GameCharacteristics.AvailableSongs).ToArray();
                    int randomIndex = Random.Range(0, unknownSongs.Length);
                    GameCharacteristics.AvailableSongs.Add(unknownSongs[randomIndex]);
                    GoTo(_successRememberText);
                }
                else
                {
                    GoTo(_failRememberText);
                }
            }
            else
            {
                GoTo(_fulfilledKnowledgeText);
            }
        }
    }
}