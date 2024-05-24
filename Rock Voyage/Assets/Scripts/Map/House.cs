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

        [SerializeReference, SubclassSelector]
        private HouseInfo _houseInfo;

        private void Awake()
        {
            _houseInfo.Awake();
            if (_houseInfo is StreetMusicInfo)
            {
                MapEvents.OnNewspaperBought += ShowView;
            }
            else
            {
                MapEvents.OnMapBought += ShowView;
            }
        }

        private void OnDestroy()
        {
            MapEvents.OnMapBought -= ShowView;
            MapEvents.OnNewspaperBought -= ShowView;
            _houseInfo.OnDestroy();
        }

        public void EnterHouse()
        {
            SceneManager.sceneLoaded += SceneLoadedHandler;
            _houseInfo.MapInfo.MapObjects.SetActive(false);
            SceneManager.LoadScene(_houseInfo.SceneName, LoadSceneMode.Additive);
        }

        private void SceneLoadedHandler(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= SceneLoadedHandler;
            SceneManager.SetActiveScene(scene);
            MapEvents.OnSceneLoaded?.Invoke(_houseInfo);
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