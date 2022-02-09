using System;
using UnityEngine;

namespace Balls.Runtime.Scripts
{
    public class Ball : MonoBehaviour
    {
        private static readonly float g = -9.8f;
        
        private Collider _collider;
        private Transform _transform;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private Vector3 _velocity;
        [SerializeField] private Vector3 _position;
        [SerializeField] private float _speed;
        [SerializeField] private float _deltaTime;
        [SerializeField] private bool _isFlying;


        public void Awake()
        {
            _transform = GetComponent<Transform>();
            _collider = GetComponent<Collider>();
            _position = _transform.position;
        }
        
        public void Initialize()
        {
            _transform = GetComponent<Transform>();
            _collider = GetComponent<Collider>();
        }
        
        public void SetPosition(Vector3 pos)
        {
            _transform.position = pos;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        
        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }

        public void StartFlying(Vector3 dir)
        {
            _direction = dir;
            _isFlying = true;
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _velocity.y += g * _deltaTime;
            _position.Set(
                _position.x + _velocity.x * _deltaTime,
                _position.y + _velocity.y * _deltaTime,
                0);
            _transform.position = _position;
            
            if (_isFlying)
            {
                _transform.position += _direction * (_speed * Time.deltaTime);
            }
        }
    }
}

