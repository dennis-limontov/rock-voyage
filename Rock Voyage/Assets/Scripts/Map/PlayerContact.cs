using UnityEngine;
using UnityEngine.InputSystem;

namespace RockVoyage
{
    public class PlayerContact : MonoBehaviour
    {
        private House _house;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.TryGetComponent(out _house))
            {
                _house.ShowBorder();
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.GetComponent<House>() == _house)
            {
                _house?.HideBorder();
                _house = null;
            }
        }

        public void OnInteracted(InputAction.CallbackContext inputContext)
        {
            if (inputContext.phase == InputActionPhase.Performed)
            {
                _house?.EnterHouse();
            }
        }
    }
}