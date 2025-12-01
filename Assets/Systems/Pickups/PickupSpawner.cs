using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour
{

    public GameObject pickupPrefab;
    public GameObject spawnAreaCube;

    public int maxPickups = 10;
    public float minspawnInterval = 5f;
    public float maxspawnInterval = 10f;

    private Bounds spawnBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider col = spawnAreaCube.GetComponent<Collider>();
        spawnBounds = col.bounds;




        for (int i = 0; i < maxPickups; i++)
        {
            SpawnPickup();
        }


    }


    public void SpawnPickup()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            spawnBounds.min.y,
            Random.Range(spawnBounds.min.z, spawnBounds.max.z)
        );

        GameObject pickup = Instantiate(pickupPrefab, randomPos, Quaternion.identity);



    }

    public void ScheduleNextSpawn()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    private IEnumerator SpawnAfterDelay()
    {
               float delay = Random.Range(minspawnInterval, maxspawnInterval);
        yield return new WaitForSeconds(delay);
        SpawnPickup();
    }
}
