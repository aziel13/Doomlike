using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    
    public GameObject[] spawnPoints;
    
    public bool gameover;
    
    public int enemyCount;

    private int EnemyMax = 1;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {

        spawnPoints =  GameObject.FindGameObjectsWithTag("Spawnpoint");

    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjects();
    }
    
    // Spawn obstacles
    void SpawnObjects ()
    {
      
        // If game is still active, spawn new object
        if (!gameover)
        {
            enemyCount = FindObjectsOfType<EnemyController>().Length;
            if (enemyCount == 0 || enemyCount <= EnemyMax)
            {
            
                // waveNumber++;
            
                SpawnEnemyWave(waveNumber);
            }
        }
    }

    private void rename(string name)
    {
        
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 spawnLocation = spawnPoints[0].transform.position;
        int index = Random.Range(0, objectPrefabs.Length);

        
        
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(objectPrefabs[0], spawnLocation , objectPrefabs[0].transform.rotation);
        }
    }
}
