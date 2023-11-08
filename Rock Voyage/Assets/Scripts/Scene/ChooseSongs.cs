using TMPro;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ChooseSongs : UIBase
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        public override void Init(UIBaseParent parent)
        {
            base.Init(parent);
            foreach (var song in RVGC.AvailableSongs)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(song.SongName));
            }
            _dropdown.value = -1;
        }

        public void OnStartClicked()
        {
            RVGC.AvailableSongs[_dropdown.value].FillResultKeys();
            SceneEvents.OnSongChosen?.Invoke(RVGC.AvailableSongs[_dropdown.value]);
        }
    }
}