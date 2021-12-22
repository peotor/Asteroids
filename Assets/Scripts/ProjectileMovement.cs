using UnityEngine;

public class ProjectileMovement : IProjectileMovement
{
    private readonly ProjectileSettings _projectileSettings;
    private readonly Transform _transformToMove;

    private readonly float _constantSpeed;
    
    public ProjectileMovement(Transform transformToMove, ProjectileSettings projectileSettings)
    {
        _transformToMove = transformToMove;
        _projectileSettings = projectileSettings;

        //we have to get speed once, bc we dont know, is this projectile is randomized speed-wise or not
        _constantSpeed = projectileSettings.ProjecileSpeed;
    }

    public void TickMovement()
    {
        //move object
        _transformToMove.position += _transformToMove.up * (_constantSpeed * Time.deltaTime);
    }
}


public interface IProjectileMovement
{
    public void TickMovement();
}