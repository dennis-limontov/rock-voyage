using UnityEngine;

namespace RockVoyage
{
    public class PlayerVision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collider2D.gameObject.layer)
            {
                collider2D.gameObject.GetComponent<House>().ShowView();
            }
        }
    }
}