using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement
{

    private readonly IShipInput _shipinput;
    private readonly Transform _transformToMove;
    private readonly ShipSettings _shipSettings;

    //injecting ship settings, however, class still depends on Unity classes, but this is engine-deep dependency,
    //which is not going to 
    //change unless we going to use different engine and we are not, right?
    public ShipMovement(IShipInput shipInput, Transform transformToMove, ShipSettings shipSettings)
    {
        _shipinput = shipInput;
        _transformToMove = transformToMove;
        _shipSettings = shipSettings;
    }

    public void Tick()
    {
        //rotate according to turnspeed and recieved input
        _transformToMove.Rotate(Vector3.forward * (_shipinput.Rotation * _shipSettings.TurnSpeed * Time.deltaTime));
        //move according to turnspeed and recieved input
        _transformToMove.position += _transformToMove.up * (_shipinput.Thrust * _shipSettings.FlySpeed * Time.deltaTime);
    }


}