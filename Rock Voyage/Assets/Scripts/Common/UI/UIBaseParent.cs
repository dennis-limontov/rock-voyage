using UnityEngine;

namespace RockVoyage
{
    public abstract class UIBaseParent : UIBase
    {
        [SerializeField]
        protected UIBase[] children;

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