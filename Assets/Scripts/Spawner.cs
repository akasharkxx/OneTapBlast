using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> asteroids;
    [SerializeField] private float timeBetweenSpawn, speedOfAsteriod, timeToDie, rotateAngle;
    [SerializeField] [Range(0f, 1f)] private float spread;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject marker;
    
    private float elapsedTime;
    private bool canSpawn;

    private void Start()
    {
        elapsedTime = 0;
        canSpawn = false;
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

        transform.Rotate(new Vector3(0f, 0f, transform.position.z + rotateAngle));
    }

    private void SpawnAsteroids(int i)
    {
        //RaycastHit2D hit = Physics2D.Raycast(spawnPoints[i].position, player.position - spawnPoints[i].position);

        //Instantiate(marker, new Vector3(hit.point.x, hit.point.y, 0f), Quaternion.identity);

        GameObject asteroid = Instantiate(asteroids[0], spawnPoints[i].position, Quaternion.identity);

        Vector3 newPlayerPosition = new Vector3(player.position.x + Random.Range(-spread, spread), player.position.y + Random.Range(-spread, spread), player.position.z);

        Vector2 directionWithSpread = newPlayerPosition - spawnPoints[i].position;
        Debug.Log(directionWithSpread);
        asteroid.GetComponent<Rigidbody2D>().AddRelativeForce(directionWithSpread * speedOfAsteriod, ForceMode2D.Impulse);

        Destroy(asteroid, timeToDie);
    }
}
