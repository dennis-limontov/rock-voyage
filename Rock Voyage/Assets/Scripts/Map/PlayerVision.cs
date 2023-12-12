using UnityEngine;

namespace RockVoyage
{
    public class PlayerVision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            collider2D.gameObject.GetComponent<House>()?.ShowView();
        }
    }
}