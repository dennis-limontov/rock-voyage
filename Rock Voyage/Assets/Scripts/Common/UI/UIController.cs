using UnityEngine;

namespace RockVoyage
{
    public class UIController : MonoBehaviour
    {
        private UIBase _anyUIElement;

        protected virtual void Awake()
        {
            _anyUIElement = GetComponent<UIBase>();
            MapEvents.OnSceneLoaded += SceneLoadedHandler;
            MapEvents.OnScenePreUnloaded += ScenePreUnloadedHandler;
        }

        private void SceneLoadedHandler(HouseInfo houseInfo)
        {
            MapEvents.OnSceneLoaded -= SceneLoadedHandler;
            _anyUIElement.Init(null, houseInfo);
            _anyUIElement.Enter();
        }

        protected virtual void ScenePreUnloadedHandler(HouseInfo houseInfo)
        {
            if (houseInfo.Equals(_anyUIElement.houseInfo))
            {
                MapEvents.OnScenePreUnloaded -= ScenePreUnloadedHandler;
                _anyUIElement.Exit();
                _anyUIElement.Dispose();
            }
        }
    }
}