using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RockVoyage
{
    public class PlayerContact : MonoBehaviour
    {
        private House _house;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collider2D.gameObject.layer)
            {
                _house = collider2D.gameObject.GetComponent<House>();
                _house.ShowBorder();
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collider2D.gameObject.layer)
            {
                _house.HideBorder();
                _house = null;
            }
        }

        public void OnInteracted(CallbackContext inputContext)
        {
            if (_house != null)
            {
                _house.EnterHouse();
            }
        }
    }
}