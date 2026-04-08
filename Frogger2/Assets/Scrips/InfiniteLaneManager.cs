using System.Collections.Generic;
using UnityEngine;

public class InfiniteLaneManager : MonoBehaviour
{
    public Transform player;

    public GameObject[] lanePrefabs; // 🔥 verschillende lane types
    public int initialLanes = 10;
    public float laneLength = 10f;

    public int lanesAhead = 10;
    public int lanesBehind = 5;

    public float currentZ = 327f;
    public float laneXPosition = -18f;

    private List<GameObject> activeLanes = new List<GameObject>();

    void Start()
    {
        currentZ = player.position.z;

        for (int i = 0; i < initialLanes; i++)
        {
            SpawnLane();
        }
    }

    void Update()
    {
        float playerZ = player.position.z;

        // Spawn nieuwe lanes
        while (currentZ < playerZ + (lanesAhead * laneLength))
        {
            SpawnLane();
        }

        // Verwijder oude lanes
        for (int i = activeLanes.Count - 1; i >= 0; i--)
        {
            if (activeLanes[i].transform.position.z < playerZ - (lanesBehind * laneLength))
            {
                Destroy(activeLanes[i]);
                activeLanes.RemoveAt(i);
            }
        }
    }

    void SpawnLane()
    {
        GameObject lanePrefab = lanePrefabs[Random.Range(0, lanePrefabs.Length)];

        Vector3 spawnPos = new Vector3(laneXPosition, 0, currentZ);

        GameObject lane = Instantiate(lanePrefab, spawnPos, Quaternion.identity);

        activeLanes.Add(lane);

        currentZ += laneLength;
        Debug.Log("Spawning lane at Z: " + currentZ);
    }
}