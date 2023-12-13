using UnityEngine;

namespace RockVoyage
{
    public abstract class UIBaseParent : UIBase
    {
        [SerializeField]
        protected UIBase[] children;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            foreach (var child in children)
            {
                child.Init(this, houseInfo);
            }
        }

        public override void Dispose()
        {
            foreach (var child in children)
            {
                child.Dispose();
            }
            base.Dispose();
        }
    }
}