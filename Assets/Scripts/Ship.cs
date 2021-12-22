using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;


public class Ship : MonoBehaviour
{
    //I am not using Zenject here, so i use scriptable object like as injector (sort of) 
    [SerializeField] private ShipSettings shipSettings;
    [SerializeField] private HitBodySettings hitBodySettings;
    
    private IShipInput _shipInput;
    private ShipMovement _shipMovement;
    private HitBody _hitBody;


    public UnityEvent onAsteroidHit;
    //shipFire

    //injecting and binding movement and shipinput; We dont have constructors in monobehaviours, so I use awake method.
    private void Awake()
    {
        //injecting input from scriptable object
        _shipInput = shipSettings.useArrows ? 
            new KeyboardArrowsInput() as IShipInput: 
            new KeyboardWasdInput() as IShipInput;
            
        //injecting shipMovement from scriptableObject
        _shipMovement = new ShipMovement(_shipInput,transform,shipSettings);
        
        _hitBody = new HitBody();
        _hitBody.OnProjectileHit += onAsteroidHit.Invoke;

    }

    private void Update()
    {
         _shipInput.ReadInput();
         _shipMovement.Tick();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //sepatate unity logics
        var hitCorrectTarget = 
            ((hitBodySettings.WhatToHitMask.value & (1 << other.transform.gameObject.layer)) > 0);

        //business logics
        _hitBody.Hit(hitCorrectTarget);
    }
    
    private void OnDestroy()
    {
        _hitBody.OnProjectileHit -= onAsteroidHit.Invoke;
    }
    
   
}
