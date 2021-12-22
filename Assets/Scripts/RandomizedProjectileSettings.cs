using UnityEngine;


//this is class to setup projectiles with randomized speed.
[CreateAssetMenu(fileName = "Randomized projectile Settings", menuName = "Create randomized projectile settings", order = 0)]
public class RandomizedProjectileSettings : ProjectileSettings
{
    
    [Space]
    [SerializeField] private float plusRange;
    [SerializeField] private float minusRange;

    public override float ProjecileSpeed
    {
        get
        {
            //when read this field, we roll speed once. 
            var rolledSpeed = Random.Range(projecileSpeed + plusRange, projecileSpeed + minusRange); 
            return rolledSpeed;
        }
        set => base.ProjecileSpeed = value;
    }
}