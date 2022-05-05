using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoSpace
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance;

        [SerializeField] public GameObject prefab;
        [SerializeField] public GameObject spawnPoint;

        [SerializeField] public List<GameObject> dinosInstanciated;

        private void Awake()
        {
            Instance = this;
        }

        public void SpawnDino()
        {
            if (GameManager.Instance.container.isFull()) return;
            var x = Random.Range(-.1f, .1f);
            var y = Random.Range(-.1f, .1f);
            var z = Random.Range(-.1f, .1f);

            GameObject instance = Instantiate(prefab, spawnPoint.transform.position + new Vector3(x, y, z), spawnPoint.transform.rotation);
            dinosInstanciated.Add(instance);
            GameManager.Instance.GotoDestination(instance);
        }
    }
}
