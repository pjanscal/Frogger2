using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject[] planePrefabs;
    public float speed = 5f;
    public float spawnInterval = 2f;
    public bool moveRight = true;
    public float zOffset = 5f;  
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPlane();
            timer = 0f;
        }
    }

    void SpawnPlane()
    {
        GameObject randomPlane = planePrefabs[Random.Range(0, planePrefabs.Length)];

        float spawnX = moveRight ? -30f : 30f;

        Vector3 spawnPos = new Vector3(spawnX, transform.position.y, transform.position.z + zOffset);

        GameObject plane = Instantiate(randomPlane, spawnPos, Quaternion.identity);

        Plane planeScript = plane.GetComponent<Plane>();
        planeScript.speed = moveRight ? speed : -speed;
    }
}