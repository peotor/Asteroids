using System;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{

    public PrefabFactory factory;

    private void Start()
    {
        InvokeRepeating("SpawnAsteroids", 1, 2);
    }

    void SpawnAsteroids()
    {
        factory.CreateItems();
    }
}