using UnityEngine;

namespace RockVoyage
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 3f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            transform.Translate(h * _speed * Time.deltaTime,
                v * _speed * Time.deltaTime, 0f);
        }
    }
}