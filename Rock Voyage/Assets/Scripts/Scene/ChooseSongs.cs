using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class ChooseSongs : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        [SerializeField]
        private SongsList _songsList;

        private void Start()
        {
            for (int i = 0; i < _songsList.Length; i++)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(_songsList[i].SongName));
            }
            _dropdown.value = -1;
        }

        public void OnStartClicked()
        {
            transform.parent.gameObject.SetActive(false);
            SceneEvents.OnSongChosen?.Invoke();
        }
    }
}