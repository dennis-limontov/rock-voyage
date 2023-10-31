using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RockVoyage
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2f;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementVector;

        private void FixedUpdate()
        {
            /*transform.Translate(_movementVector.x * _speed * Time.deltaTime,
               _movementVector.y * _speed * Time.deltaTime, 0f);*/
            _rigidbody2D.MovePosition(transform.position + new Vector3(_movementVector.x
                * _speed, _movementVector.y * _speed, 0f));
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            
        }

        public void OnMoved(CallbackContext inputContext)
        {
            _movementVector = inputContext.ReadValue<Vector2>();
        }
    }
}