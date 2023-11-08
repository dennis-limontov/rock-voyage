using UnityEngine;

namespace RockVoyage
{
    public class UIBase : MonoBehaviour
    {
        protected UIBaseParent parent;

        public virtual void Enter()
        {
            gameObject.SetActive(true);
        }

        public virtual void Exit()
        {
            gameObject.SetActive(false);
        }

        public virtual void Init(UIBaseParent parent = null)
        {
            this.parent = parent;
        }

        protected UIBaseParent GetController()
        {
            UIBaseParent controller = parent, currentParent = parent;
            while (currentParent)
            {
                controller = currentParent;
                currentParent = currentParent.parent;
            }
            return controller;
        }
    }
}