using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    private List<EntitySpawnPoint> _entitySpawnPoint;
    
    private void Start()
    {
        GetSpawnPoints();
        SpawnEntities();
    }

    private void SpawnEntities()
    {
        foreach (EntitySpawnPoint spawnPoints in _entitySpawnPoint)
            spawnPoints.SpawnEntity();
    }

    private void GetSpawnPoints() => _entitySpawnPoint = FindObjectsOfType<EntitySpawnPoint>().ToList();
}
