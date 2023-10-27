using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RockVoyage
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 3f;

        private Vector2 _movementVector;

        private void Update()
        {
            transform.Translate(_movementVector.x * _speed * Time.deltaTime,
               _movementVector.y * _speed * Time.deltaTime, 0f);
        }

        public void OnMoved(CallbackContext inputContext)
        {
            _movementVector = inputContext.ReadValue<Vector2>();
        }
    }
}