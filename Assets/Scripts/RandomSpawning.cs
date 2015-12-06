using UnityEngine;
using System.Collections;

public class RandomSpawning : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float spawnTime = 1f;
    public GameObject spawnObject;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObjects()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(spawnObject, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }
}
