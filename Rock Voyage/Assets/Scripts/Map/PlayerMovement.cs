using System.Runtime.Serialization;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RockVoyage
{
    using static Constants.PlayerAnimationStates;

    [DataContract]
    public class PlayerMovement : MonoBehaviour, ILoadSaveRoot
    {
        [SerializeField]
        private float _speed = 2f;

        private Rigidbody2D _rigidbody2D;

        private Animator _animator;

        private Vector2 _movementVector;

        public string Name => name;

        [DataMember]
        private (float X, float Y) PlayerPosition
        {
            get => (transform.position.x, transform.position.y);
            set
            {
                Vector3 newPosition = transform.position;
                (newPosition.x, newPosition.y) = value;
                transform.position = newPosition;
            }
        }

        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            ((ILoadSaveRoot)this).AddLoadSaveable();
        }

        private void OnDestroy()
        {
            ((ILoadSaveRoot)this).RemoveLoadSaveable();
        }

        private void FixedUpdate()
        {
            /*transform.Translate(_movementVector.x * _speed * Time.deltaTime,
               _movementVector.y * _speed * Time.deltaTime, 0f);*/
            /*_rigidbody2D.MovePosition(transform.position + new Vector3(_movementVector.x
                * _speed, _movementVector.y * _speed, 0f));*/
            _rigidbody2D.velocity = _speed * _movementVector;
        }

        public void OnMoved(CallbackContext inputContext)
        {
            _movementVector = inputContext.ReadValue<Vector2>();
            foreach (string boolName in MOVING_BOOL_NAMES)
            {
                _animator.SetBool(boolName, false);
            }
            if (_movementVector.y > 0)
            {
                _animator.SetBool(BOOL_WALK_UP, true);
            }
            else if (_movementVector.y < 0)
            {
                _animator.SetBool(BOOL_WALK_FRONT, true);
            }
            else if (_movementVector.x > 0)
            {
                _animator.SetBool(BOOL_WALK_RIGHT, true);
                Quaternion playerRotation = transform.rotation;
                playerRotation.y = 0f;
                transform.rotation = playerRotation;
            }
            else if (_movementVector.x < 0)
            {
                _animator.SetBool(BOOL_WALK_LEFT, true);
                Quaternion playerRotation = transform.rotation;
                playerRotation.y = 180f;
                transform.rotation = playerRotation;
            }
            else
            {
                _animator.SetBool(BOOL_IDLE, true);
            }
        }
    }
}