using UnityEngine;
using System.Collections.Generic;

namespace MotorCycle2D
{
    public class Terrain2D : MonoBehaviour
    {
        public int startIndex = 10;
        public int totalParts = 100;
        public List<GameObject> terrainParts;
        public float distance = 40;

        private GameObject _gameObj;

        private void Start()
        {
            for (int i=startIndex; i <= totalParts; i++)
            {
                _gameObj = GameObject.Instantiate<GameObject>(terrainParts[
                    Random.Range(0, terrainParts.Count - 1)
                ]);

                _gameObj.SetActive(true);

                _gameObj.transform.parent = transform;
                _gameObj.transform.localPosition = new Vector3(i * distance, 0, 0);
            }
        }
    }
}
