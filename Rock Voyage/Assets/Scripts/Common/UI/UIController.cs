using System;
using System.Linq;
using UnityEngine;

namespace RockVoyage
{
    public class UIController : MonoBehaviour
    {
        protected UIBase _anyUIElement;

        [SerializeReference, SubclassSelector]
        protected HouseInfo _defaultHouseInfo;

        protected virtual void Awake()
        {
            _anyUIElement = GetComponent<UIBase>();
            MapEvents.OnSceneLoaded += SceneLoadedHandler;
            MapEvents.OnScenePreUnloaded += ScenePreUnloadedHandler;
        }

        protected virtual void Start()
        {
            if ((_defaultHouseInfo != null) && MapEvents.OnSceneLoaded?.GetInvocationList()
                .Contains((Action<HouseInfo>)SceneLoadedHandler) == true)
            {
                MapEvents.OnSceneLoaded.Invoke(_defaultHouseInfo);
            }
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