using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    public float obstacleSpawnTimeMulti = 20000f;
    public float obstacleSpeedMulti = 10f;

    private float timeUntilObsSpawn;
    //private void Update(){
    //    if (GameManager.Instance.isPlaying){
    //        SpawnLoop();   
    //    }
    //}

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
    }

    private void SpawnLoop(){
        timeUntilObsSpawn += Time.deltaTime;
        obstacleSpawnTime -= GameManager.Instance.currentScore/obstacleSpawnTimeMulti;
        if(timeUntilObsSpawn >= obstacleSpawnTime){
            Spawn();
            timeUntilObsSpawn = 0f;
        }
    }

    private void Spawn(){
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obsRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obsRB.velocity = Vector2.left * (obstacleSpeed + (GameManager.Instance.currentScore/obstacleSpeedMulti));
    }
}
