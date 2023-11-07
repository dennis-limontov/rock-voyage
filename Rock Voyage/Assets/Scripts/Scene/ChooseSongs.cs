using TMPro;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ChooseSongs : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        private void Start()
        {
            foreach (var song in RVGC.AvailableSongs)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(song.SongName));
            }
            _dropdown.value = -1;
        }

        public void OnStartClicked()
        {
            transform.parent.gameObject.SetActive(false);
            RVGC.AvailableSongs[_dropdown.value].FillResultKeys();
            SceneEvents.OnSongChosen?.Invoke(RVGC.AvailableSongs[_dropdown.value]);
        }
    }
}