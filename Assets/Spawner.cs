using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> asteroids;
    [SerializeField] private float timeBetweenSpawn, speedOfAsteriod, timeToDie;

    private Transform player;
    private float elapsedTime;
    private bool canSpawn;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > timeBetweenSpawn)
        {
            canSpawn = true;
            elapsedTime = 0;
        }
        else
        {
            canSpawn = false;
        }
    }

    private void FixedUpdate()
    {
        if (canSpawn)
        {
            SpawnAsteroids(Random.Range(0, spawnPoints.Count - 1));
        }
    }

    private void SpawnAsteroids(int i)
    {
        GameObject asteroid = Instantiate(asteroids[0], spawnPoints[i].position, Quaternion.identity);

        Vector2 direction = player.position - spawnPoints[i].position;

        asteroid.GetComponent<Rigidbody2D>().AddForce(direction * speedOfAsteriod, ForceMode2D.Impulse);

        Destroy(asteroid, timeToDie);
    }
}
