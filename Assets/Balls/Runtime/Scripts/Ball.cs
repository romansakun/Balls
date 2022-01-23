using UnityEngine;

namespace Balls.Runtime.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Collider _collider;
        private Transform _transform;
        
        // Start is called before the first frame update
        void Awake()
        {
            _transform = GetComponent<Transform>();
            _collider = GetComponent<Collider>();
        }

        public void SetDirection(Vector3 dir)
        {
            //TODO tests and realization
        }

        public void SetPosition(Vector3 pos)
        {
            //TODO tests and realization
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
        
        
    }
}

