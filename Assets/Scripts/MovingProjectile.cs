using System;
using System.Collections;
using DefaultNamespace;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;

public class MovingProjectile : MonoBehaviour
{
    [SerializeField] private ProjectileSettings projectileSettings;
    [SerializeField] private HitBodySettings hitBodySettings;
    private IProjectileMovement _projectileMovement;
    private HitBody _hitBody;

    //to make it possible to link from unity;
    public UnityEvent onProjectileHit;

    //not necessary bc we are not going to control it in this example, but might be useful later
    public Coroutine selfDistruction;

    //inject all the settings into projectile behaviour
    private void Awake()
    {
        _projectileMovement = new ProjectileMovement(transform,projectileSettings);
        _hitBody = new HitBody();
        _hitBody.OnProjectileHit += onProjectileHit.Invoke;
    }
    
    private void Start()
    {
        //I put destroying here because it depends on gameengine time, not on inner business logic;
         selfDistruction = StartCoroutine(DestroyProjectileInSeconds());
    }

    private void Update()
    {
        _projectileMovement.TickMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //sepatate unity logics
        var hitCorrectTarget = 
            ((hitBodySettings.WhatToHitMask.value & (1 << other.transform.gameObject.layer)) > 0);

        //business logics
        _hitBody.Hit(hitCorrectTarget);
            
    }
    
    public void DisposeProjectileInstance()
    {
        //not necessary, but possible
        StopCoroutine(selfDistruction);
        
        //use pooling instead of destroy
        LeanPool.Despawn(gameObject);
    }
    
    IEnumerator DestroyProjectileInSeconds()
    {
        yield return new WaitForSeconds(projectileSettings.ProjectileLifetimeInSeconds);
        DisposeProjectileInstance();
    }

    private void OnDestroy()
    {
        _hitBody.OnProjectileHit -= onProjectileHit.Invoke;
    }
}

