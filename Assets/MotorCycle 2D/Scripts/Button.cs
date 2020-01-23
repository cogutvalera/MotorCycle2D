using UnityEngine;
using UnityEngine.EventSystems;

namespace MotorCycle2D
{
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public float movement = 1.0f;
        public float movementConsumption = 0.2f;

        private float currentMovement;
        private bool ispressed = false;

        private void FixedUpdate()
        {
            if (!ispressed)
                return;

            if (movement < 0)
                currentMovement -= movementConsumption * Time.fixedDeltaTime;
            else
                currentMovement += movementConsumption * Time.fixedDeltaTime;

            if (currentMovement < movement || currentMovement > movement)
                currentMovement = movement;

            MotorCycle.Instance.Movement = currentMovement;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ispressed = true;

            currentMovement = 0;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ispressed = false;

            MotorCycle.Instance.Movement = 0;
        }
    }
}