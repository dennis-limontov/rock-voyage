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

        protected virtual void Start()
        {
            _anyUIElement = GetComponent<UIBase>();
            _anyUIElement.Init();
            _anyUIElement.Enter();
        }
    }
}