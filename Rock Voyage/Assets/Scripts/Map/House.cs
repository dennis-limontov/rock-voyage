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

        [SerializeField]
        private HouseInfo _houseInfo;

        private void OnDestroy()
        {
            MapEvents.OnMapBought -= ShowView;
            MapEvents.OnNewspaperBought -= ShowView;
        }

        private void Start()
        {
            if (_houseInfo is StreetMusicInfo)
            {
                MapEvents.OnNewspaperBought += ShowView;
            }
            else
            {
                MapEvents.OnMapBought += ShowView;
            }
        }

        public void EnterHouse()
        {
            _houseInfo.MapInfo.MapObjects.SetActive(false);
            SceneManager.LoadScene(_houseInfo.SceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_houseInfo.SceneName));
            SceneManager.sceneLoaded -= SceneLoadedHandler;
        }

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