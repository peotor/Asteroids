using System;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{

    public PrefabCreator creator;

    private void Start()
    {
        InvokeRepeating("SpawnAsteroids", 1, 2);
    }

    void SpawnAsteroids()
    {
        creator.CreateItems();
    }
}