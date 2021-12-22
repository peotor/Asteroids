using UnityEngine;

[CreateAssetMenu(fileName = "ProjectiletSettings", menuName = "Create projectile settings", order = 0)]
public class ProjectileSettings : ScriptableObject
{
    [SerializeField] internal float projecileSpeed = 30;
    
    [SerializeField] private float projectileLifetimeInSeconds;
        
    public virtual float ProjecileSpeed
    {
        get => projecileSpeed;
        set => projecileSpeed = value;
    }


    public float ProjectileLifetimeInSeconds
    {
        get => projectileLifetimeInSeconds;
        private set => projectileLifetimeInSeconds = value;
    }

    
        
}