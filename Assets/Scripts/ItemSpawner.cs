using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item[] _item;
    
    private List<SpawnPoint> _spawnPoint = new List<SpawnPoint>();

    private void Awake()
    {
        GetSpawnPoints();

        foreach(SpawnPoint points in _spawnPoint)
            SpawnItem(_item[Random.Range(0, _item.Length)], points);
    }

    private void GetSpawnPoints()
    {
        _spawnPoint.Clear();
        
        SpawnPoint[] spawnPointsInChildren = GetComponentsInChildren<SpawnPoint>();
        
        foreach (var spawnPoint in spawnPointsInChildren)
            _spawnPoint.Add(spawnPoint);
    }

    private void SpawnItem(Item item, SpawnPoint parent)
    {
        item = Instantiate(item, parent.transform);
    }
}
