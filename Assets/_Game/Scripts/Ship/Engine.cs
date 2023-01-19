using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] private ShipInfo _shipInfo;

        private Rigidbody2D _rigidbody;
        
        private float _xMin, _xMax;
        private float _yMin, _yMax;
        
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }

            var xValidPosition = Mathf.Clamp(transform.position.x, _xMin, _xMax);
            var yValidPosition = Mathf.Clamp(transform.position.y, _yMin, _yMax);

            transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            var _hullSize = GetComponentInChildren<SpriteRenderer>().bounds.size.x * 0.01f;

            var cam = Camera.main;
            var camHeigth = cam.orthographicSize;
            var camWidth = cam.orthographicSize * cam.aspect;

            _yMin = -camHeigth + _hullSize;
            _yMax = camHeigth - _hullSize;

            _xMin = -camWidth + _hullSize;
            _xMax = camWidth - _hullSize;

        }
    
        public void Throttle()
        {
            _rigidbody.AddForce(transform.up * _shipInfo.throttleSpeed, ForceMode2D.Force);
        }

        public void SteerLeft()
        {
            _rigidbody.AddTorque(_shipInfo.rotationSpeed, ForceMode2D.Force);
        }

        public void SteerRight()
        {
            _rigidbody.AddTorque(-_shipInfo.rotationSpeed, ForceMode2D.Force);
        }
    }
}
