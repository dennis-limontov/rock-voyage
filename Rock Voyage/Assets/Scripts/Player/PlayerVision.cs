using UnityEngine;

namespace RockVoyage
{
    public class PlayerVision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collision.gameObject.layer)
            {
                collision.gameObject.GetComponent<House>().ShowView();
            }
        }
    }
}
