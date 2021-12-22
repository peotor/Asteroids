using System;

public class HitBody
{
    public event Action OnProjectileHit;

    public void Hit(bool correctTarget)
    {
        if (correctTarget) 
            OnProjectileHit?.Invoke();  
    }
        
}