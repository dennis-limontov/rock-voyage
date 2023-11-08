using UnityEngine;

namespace RockVoyage
{
    public class UIBaseParent : UIBase
    {
        [SerializeField]
        protected UIBase[] children;
    }
}