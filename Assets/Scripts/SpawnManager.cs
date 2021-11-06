using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("SpawnEnemies",0.5f,1f);
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void SpawnEnemies()
    {
        if(player != null){
          int index = Random.Range(0,spawnPoints.Length );
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
        }
    }
}
