using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabCreator: MonoBehaviour
{
    public PrefabCreatorSettings prefabCreatorSettings;
    
    //creates the prefab
    private PrefabFactory prefabFactory;
    private void Awake()
    {
        prefabFactory = new PrefabFactory(prefabCreatorSettings.Prefabs);
    }

    public void CreateItems()
    {
        for (int i = 0; i < prefabCreatorSettings.CreateCount; i++)
        {
            //create prefab
            var newPrefab = prefabFactory.GetRandomFromCollection();
            
            //where to place it
            newPrefab.transform.position = RollPosition();
            
            //set it's rotation
            newPrefab.transform.rotation = SetRotation(newPrefab.transform.position);
        } 
    }

    // I chose to use switch statement here - it's kinda ok I guess
    Quaternion SetRotation(Vector3 relativePos)
    {
        // our projectiles always fly forward, that's why it is crucial to control their rotation.
        //it probably would be better to use rigidbody and velocity for easier understanding.
        switch (prefabCreatorSettings.RotationOption)
        {
            case RotationOptions.Random:
                return GetRandomRotation();

            case RotationOptions.TowardsCenter:
                return GetRotationTowardsCenter(relativePos);

            case RotationOptions.Relative:
                return transform.rotation;

            default:
                return Quaternion.identity;
        }
    }

    //asteroids should face center-ish to make threat to our ship. THats why we need each asteroid to face
    //center.
    private static Quaternion GetRotationTowardsCenter(Vector3 relativePos)
    {
        //2d rotation maths.
        var targetTransform = new Vector3(Random.Range(-4.5f,4.5f),Random.Range(-4.5f,4.5f));
        Vector3 vectorToTarget = targetTransform - relativePos;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private static Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f)));
    }
    
    Vector3 RollPosition()
    {
        //at factory holder position
        if (prefabCreatorSettings.AtOrigin)
            return transform.position;
        
        //on circle around center of coords.
        return (
            new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f))).normalized *
               prefabCreatorSettings.RandomizationPositionOffset;
    }

}