using System;
using UnityEngine;

namespace RockVoyage
{
    public class UIBase : MonoBehaviour, IDisposable
    {
        protected UIBaseParent parent;
        protected HouseInfo houseInfo;

        public virtual void Dispose()
        {
        }

        public virtual void Enter()
        {
            gameObject.SetActive(true);
        }

        public virtual void Exit()
        {
            gameObject.SetActive(false);
        }

        public virtual void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            this.parent = parent;
            this.houseInfo = houseInfo;
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