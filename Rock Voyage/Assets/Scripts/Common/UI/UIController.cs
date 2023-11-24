using System;
using UnityEngine;

namespace RockVoyage
{
    public class UIController : MonoBehaviour
    {
        private UIBase _anyUIElement;

        protected virtual void OnDestroy()
        {
            _anyUIElement.Exit();
            _anyUIElement.Dispose();
        }

        protected virtual void Awake()
        {
            _anyUIElement = GetComponent<UIBase>();
            MapEvents.OnSceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler(HouseInfo houseInfo)
        {
            MapEvents.OnSceneLoaded -= SceneLoadedHandler;
            _anyUIElement.Init(null, houseInfo);
            _anyUIElement.Enter();
        }
    }
}