using UnityEngine;

namespace RockVoyage
{
    public class HostelController : UIActiveOneChild
    {
        [SerializeField]
        private HostelInfo _hostelInfo;
        public HostelInfo HostelInfo => _hostelInfo;
    }
}