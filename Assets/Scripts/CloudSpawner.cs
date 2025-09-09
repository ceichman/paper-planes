using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float spawnHeight = 3f;
    public float spawnRate = 0.5f;
    public GameObject[] cloudPrefabs;
    public float cloudSpeed = 2f;

    float lastSpawnTime;

    void Update()
    {
        if (Time.time > lastSpawnTime + 1f / spawnRate)
        {
            lastSpawnTime = Time.time;
            Vector3 pos = transform.position + new Vector3(0, Random.Range(-spawnHeight, spawnHeight), 0);
            GameObject prefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];
            GameObject cloud = Instantiate(prefab, pos, Quaternion.identity);
            var rb = cloud.GetComponent<Rigidbody2D>();
            if (rb) rb.linearVelocity = Vector2.left * cloudSpeed;
            else cloud.AddComponent<CloudMover>().speed = cloudSpeed;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position + new Vector3(0, -spawnHeight, 0), transform.position + new Vector3(0, spawnHeight, 0));
    }
}

public class CloudMover : MonoBehaviour
{
    public float speed = 2f;
    void Update() => transform.position += Vector3.left * speed * Time.deltaTime;
}
