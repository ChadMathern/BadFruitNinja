using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitSpawn : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame


    IEnumerator SpawnFruits ()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnpoint = spawnPoints[spawnIndex];

            Instantiate(fruit, spawnpoint.position, spawnpoint.rotation);
        }
    }
}
