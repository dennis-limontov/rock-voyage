using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class PlayerContact : MonoBehaviour
    {
        private GameObject _house;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collision.gameObject.layer)
            {
                _house = collision.gameObject;
                collision.gameObject.GetComponent<House>().ShowBorder();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (LayerMask.NameToLayer(Constants.HOUSE_LAYER)
                == collision.gameObject.layer)
            {
                _house = null;
                collision.gameObject.GetComponent<House>().HideBorder();
            }
        }

        private void Update()
        {
            if ((_house != null) && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Constants.SCENE_SCENE);
            }
        }
    }
}
