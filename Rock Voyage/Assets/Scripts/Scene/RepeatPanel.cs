using UnityEngine;

namespace RockVoyage
{
    public class RepeatPanel : MonoBehaviour
    {
        [SerializeField]
        private ChooseSongs _chooseSongs;

        public void OnClickedNo()
        {
            transform.parent.gameObject.SetActive(false);
            _chooseSongs.transform.parent.gameObject.SetActive(true);
        }

        public void OnClickedYes()
        {
            transform.parent.gameObject.SetActive(false);
            _chooseSongs.OnStartClicked();
        }
    }
}