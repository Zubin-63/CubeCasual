using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject breakPlatformPrefab;
    public GameObject[] movingPlatformPrefab;
    public float platformSpawnTimer = 1.8f;
    private float currentPlatformSpawnTimer;
    private int countPlatform;

    private float minX = -2f, maxX = 2f;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();   
    }
    void SpawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            countPlatform++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;
            if (countPlatform < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (countPlatform == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatformPrefab[Random.Range(0, movingPlatformPrefab.Length)], temp, Quaternion.identity);
                }
            }
            else if (countPlatform == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (countPlatform == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakPlatformPrefab, temp, Quaternion.identity);
                }
                countPlatform = 0;
            }
            if(newPlatform)
            newPlatform.transform.parent = transform; //hierarchy me platform spawer ke child bne 
            currentPlatformSpawnTimer = 0f;

        }
    }
}
