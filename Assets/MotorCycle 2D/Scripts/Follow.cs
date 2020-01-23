using UnityEngine;

namespace MotorCycle2D
{
    public class Follow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        
        void Start()
        {
            offset = transform.position - target.position;
        }
        
        void Update()
        {
            transform.position = target.position + offset;
        }
    }
}
