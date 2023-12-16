using TMPro;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ChooseSongs : UIBase
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        [SerializeField]
        private SongsList _songsList;

        public override void Enter()
        {
            base.Enter();
            _dropdown.options.Clear();
            foreach (var song in RVGC.AvailableSongs)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(song));
            }
            _dropdown.value = -1;
        }

        public void OnStartClicked()
        {
            SongInfo chosenSong = _songsList[RVGC.AvailableSongs[_dropdown.value]];
            chosenSong.FillInfo();
            SceneEvents.OnSongChosen?.Invoke(chosenSong);
        }
    }
}