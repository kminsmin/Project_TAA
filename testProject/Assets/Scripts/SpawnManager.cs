using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    private Vector3 spawnPos;
    public float spawnRate = 3.0f;
    private PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = new Vector3(15,Random.Range(0.0f,7.0f),0);
    }
    void SpawnObstacle()
    {
        if (playerController.isGameActive == true)
        {
            int index = Random.Range(0,enemies.Length);
            Instantiate(enemies[index], spawnPos, enemies[index].transform.rotation);
        }
        
        }
    public void StartSpawn(int difficulty)
    {
        spawnPos = new Vector3(15,Random.Range(0.0f,7.0f),0);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle",2,spawnRate/difficulty);
    }
    
}
