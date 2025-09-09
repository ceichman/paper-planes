using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float maxSpawnDelay;
    [SerializeField] private float horizontalSpawnRadius;


    void Start()
    {
        StartCoroutine(this.PowerupLoop());
    }

    private IEnumerator PowerupLoop()
    {
        while (true)
        {
            float timeToWait = Random.value * maxSpawnDelay;
            yield return new WaitForSeconds(timeToWait);
            CreatePowerup();
        }
    }

    void CreatePowerup()
    {
        int randomIndex = Mathf.FloorToInt(Random.value * powerUps.Length);
        GameObject currentPowerup = powerUps[randomIndex];

        float spawnX = this.transform.position.x + (Random.value * 2 - 1) * horizontalSpawnRadius;
        Vector3 spawnPosition = this.transform.position;
        spawnPosition.x = spawnX;
        Instantiate(currentPowerup, spawnPosition, this.transform.rotation);
    }
}