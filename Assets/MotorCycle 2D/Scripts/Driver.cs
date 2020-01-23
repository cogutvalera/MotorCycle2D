using UnityEngine;
using UnityEngine.SceneManagement;

namespace MotorCycle2D
{
    public class Driver : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<EdgeCollider2D>())
                Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}
