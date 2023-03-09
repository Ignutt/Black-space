using System;
using Common;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float accelerationX = 7f;
        [SerializeField] private float maxSpeed = 10f;
 
        private Rigidbody2D _rigidbody;
        private Vector2 _currentAcceleration;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            InputManager.Instance.OnTouchStart += side =>
            {
                if (side == SideType.Left)
                {
                    _currentAcceleration = Vector2.left * accelerationX;
                    return;
                }
                
                _currentAcceleration = Vector2.right * accelerationX;
            };

            InputManager.Instance.OnTouchEnd += side =>
            {
                if (side == SideType.Left)
                {
                    _currentAcceleration = _currentAcceleration.magnitude > 0 ? _currentAcceleration : Vector2.zero;
                    return;
                }
                
                _currentAcceleration = _currentAcceleration.magnitude < 0 ? _currentAcceleration : Vector2.zero;
            };
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_currentAcceleration);

            if (Mathf.Abs(_rigidbody.velocity.x) > maxSpeed)
            {
                _rigidbody.velocity = new Vector2(maxSpeed * (_rigidbody.velocity.x > 0 ? 1 : -1), _rigidbody.velocity.y);
            }
        }

        private void OnValidate()
        {
            if (accelerationX < 0)
            {
                accelerationX *= -1;
            }
        }
    }
}
