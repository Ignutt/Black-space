using System;
using Common;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMovement = 7f;

        private Rigidbody2D _rigidbody;
        private Vector3 _velocity;

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
                    _velocity = new Vector2(speedMovement * -1, _rigidbody.velocity.y);
                    return;
                }
                
                _velocity = new Vector2(speedMovement, _rigidbody.velocity.y);
            };

            InputManager.Instance.OnTouchEnd += side =>
            {
                if (side == SideType.Left)
                {
                    _velocity = new Vector2(
                        _velocity.x < 0 ? 0 : _velocity.x,
                        _rigidbody.velocity.y);
                    
                    return;
                }
                
                _velocity = new Vector2(
                    _velocity.x > 0 ? 0 : _velocity.x,
                    _rigidbody.velocity.y);
            };
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_velocity.x, _rigidbody.velocity.y);
        }

        private void OnValidate()
        {
            if (speedMovement < 0)
            {
                speedMovement *= -1;
            }
        }
    }
}
