using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[]  spawnPoints;
    public float        firstSpawnTime = 4.0f;
    public float        nextSpawnTime = 2.0f;
    public float        variance = 0.0f;
    public int          maxElems = 0;
    public string[]     tags;
    public GameObject[] prefabs;

    float   timer;

    void Start()
    {
        timer = firstSpawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {            
            Spawn();
        }
    }

    void Spawn()
    {
        if (maxElems > 0)
        {
            int count = 0;

            foreach (var t in tags)
            {
                count += GameObject.FindGameObjectsWithTag(t).Length;
            }

            if (count >= maxElems) return;
        }

        int spawnPoint = Random.Range(0, spawnPoints.Length);
        int enemy = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[enemy], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);

        timer = nextSpawnTime + Random.Range(-variance, variance);
    }
}
