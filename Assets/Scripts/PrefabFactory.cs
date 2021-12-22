using System;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Random = UnityEngine.Random;

public class PrefabFactory: MonoBehaviour
{
    public FactorySettings factorySettings;
    
    public void CreateItems()
    {
        for (int i = 0; i < factorySettings.CreateCount; i++)
        {
            //select instance
            var newPrefab = RollPrefabVariant();
            
            //where to spawn
            Vector3 newPosition = RollPosition();
            
            //set rotation.
            var newRotation = SetRotation(newPosition);
            
            LeanPool.Spawn(newPrefab, newPosition, newRotation);
        } 
    }

    GameObject RollPrefabVariant()
    {
        return  factorySettings.Prefabs[Random.Range(0, factorySettings.Prefabs.Length)];
    }
    
    // I chose to use switch statement here - it's kinda ok I guess
    Quaternion SetRotation(Vector3 relativePos)
    {
        // our projectiles always fly forward, that's why it is crucial to control their rotation.
        //it probably would be better to use rigidbody and velocity for easier understanding.
        switch (factorySettings.RotationOption)
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
        if (factorySettings.AtOrigin)
            return transform.position;
        
        //on circle around center of coords.
        return (
            new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f))).normalized *
               factorySettings.RandomizationPositionOffset;
    }

        
}