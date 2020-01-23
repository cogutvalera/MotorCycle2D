using UnityEngine;
using TMPro;

namespace MotorCycle2D
{
    public class MotorCycle : MonoBehaviour
    {
        private static MotorCycle _instance;

        public static MotorCycle Instance
        {
            get
            {
                return _instance;
            }
        }

        public TextMeshProUGUI textDistance;
        public TextMeshProUGUI textWheelie;

        public float distance = 0f;

        public float fuel = 100;
        public float fuelConsumption = 0.1f;

        public Rigidbody2D motorCycleRigidbody;
        public Rigidbody2D backTire;
        public Rigidbody2D frontTire;

        public bool isFrontTireOnGround, isBackTireOnGround;

        public float speed = 20;
        public float motorCycleTorque = 10;

        private float _rotation;

        private float movement;
        public float Movement
        {
            get
            {
                return movement;
            }

            set
            {
                movement = value;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            distance = motorCycleRigidbody.transform.localPosition.x;
            textDistance.text = "Distance: <color=green>" + distance.ToString("0.00") + "</color> meters";

            _rotation = motorCycleRigidbody.transform.localEulerAngles.z;

            if (isBackTireOnGround && !isFrontTireOnGround && _rotation >= 20 && _rotation <= 120)
                textWheelie.text = "Wheelie!";
            else
                textWheelie.text = "";

            movement = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            if (fuel < 0)
                return;
            
            if (isBackTireOnGround)
                backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);

            if (isFrontTireOnGround)
                frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);

            motorCycleRigidbody.AddTorque(-movement * motorCycleTorque * Time.fixedDeltaTime);

            fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
        }
    }
}
