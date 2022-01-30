using System;
using UnityEngine;

namespace Balls.Runtime.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Collider _collider;
        private Transform _transform;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _speed;
        [SerializeField] private bool _isFlying;


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

        public void StartFlying(Vector3 dir)
        {
            _direction = dir;
            _isFlying = true;
        }

        private void Update()
        {
            if (_isFlying)
            {
                _transform.position += _direction * (_speed * Time.deltaTime);
            }
        }
    }
}

