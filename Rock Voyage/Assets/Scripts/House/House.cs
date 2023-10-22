using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class House : MonoBehaviour
    {
        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private GameObject _circleBorder;

        public void ShowView()
        {
            _view.SetActive(true);
        }

        public void HideBorder()
        {
            _circleBorder.SetActive(false);
        }

        public void ShowBorder()
        {
            _circleBorder.SetActive(true);
        }
    }
}