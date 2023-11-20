using Newtonsoft.Json;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RockVoyage
{
    public class PlayerMovement : MonoBehaviour, ILoadSave
    {
        [SerializeField]
        private float _speed = 2f;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementVector;
        [JsonProperty]
        public (float X, float Y) PlayerPosition
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
            LoadSaveManager.loadSaveList.Add(this);
        }

        public void Load(string loadData)
        {
            PlayerPosition = JsonConvert.DeserializeObject<(float, float)>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(PlayerPosition);
        }

        private void FixedUpdate()
        {
            /*transform.Translate(_movementVector.x * _speed * Time.deltaTime,
               _movementVector.y * _speed * Time.deltaTime, 0f);*/
            _rigidbody2D.MovePosition(transform.position + new Vector3(_movementVector.x
                * _speed, _movementVector.y * _speed, 0f));
        }

        public void OnMoved(CallbackContext inputContext)
        {
            _movementVector = inputContext.ReadValue<Vector2>();
        }
    }
}