using Lean.Pool;
using UnityEngine;

public class PrefabFactory
{
    private GameObject[] myCollection;
    
    public PrefabFactory(GameObject[] collection)
    {
        myCollection = collection;
    }

    public GameObject GetRandomFromCollection()
    {
        return  LeanPool.Spawn(myCollection[Random.Range(0, myCollection.Length)]);
    }
    
    //not used, but may be used.
    public GameObject GetElementByIndex(int i)
    {
        return  LeanPool.Spawn(myCollection[i]);
    }
}