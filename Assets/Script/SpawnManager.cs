using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerUpPrefabs;

    private float spawnPos = 9;

    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(waveNumber);
       Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemies>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
         for(int i = 0; i < enemiesToSpawn; i++) 
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation); 
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        float spawnPosZ = Random.Range(-spawnPos, spawnPos);

        Vector3 randomSpawn = new Vector3(spawnPosX, 0 ,spawnPosZ);

        return randomSpawn;

    }
}
