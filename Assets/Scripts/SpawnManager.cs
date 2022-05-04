using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] public List<GameObject> dinosSpawned;
    
    private void Awake()
    {
        Instance = this;
    }

    public void SpawnDino()
    {
        var x = Random.Range(-.1f,.1f);
        var y = Random.Range(-.1f,.1f);
        var z = Random.Range(-.1f,.1f);

        GameObject instance = Instantiate(prefab, spawnPoint.transform.position + new Vector3(x, y, z), spawnPoint.transform.rotation);
        dinosSpawned.Add(instance);

        GameManager.Instance.GotoDestination(instance);
    }
}
