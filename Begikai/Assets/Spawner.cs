using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;
    private float timeUntilObsSpawn;
    private void Update(){
        SpawnLoop();
    }

    private void SpawnLoop(){
        timeUntilObsSpawn += Time.deltaTime;

        if(timeUntilObsSpawn >= obstacleSpawnTime){
            Spawn();
            timeUntilObsSpawn = 0f;
        }
    }

    private void Spawn(){
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obsRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obsRB.velocity = Vector2.left * obstacleSpeed;
    }
}