using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class PlayerContact : MonoBehaviour
    {
        private House _house;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collision.gameObject.layer)
            {
                _house = collision.gameObject.GetComponent<House>();
                _house.ShowBorder();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collision.gameObject.layer)
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