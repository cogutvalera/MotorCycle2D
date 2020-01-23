using UnityEngine;

namespace MotorCycle2D
{
    public class Tire : MonoBehaviour
    {
        public bool isFront;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnGround(collision.collider, true);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            OnGround(collision.collider, false);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            OnGround(collider, true);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            OnGround(collider, false);
        }

        private void OnGround(Collider2D collider, bool flag)
        {
            if (collider.GetComponent<EdgeCollider2D>())
            {
                if (isFront)
                {
                    MotorCycle.Instance.isFrontTireOnGround = flag;
                }
                else
                {
                    MotorCycle.Instance.isBackTireOnGround = flag;
                }
            }
        }
    }
}
