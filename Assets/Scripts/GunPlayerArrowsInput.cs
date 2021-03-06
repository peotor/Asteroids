using System;
using UnityEngine;

public class GunPlayerArrowsInput : IGunInput
{
    public void ReadInput()
    {
        IsFiring = Math.Abs(Input.GetAxis("Fire2") - 1) < 0.01f;
        ResetFire = Math.Abs(Input.GetAxis("Fire2")) < 0.01f;
    }

    public bool IsFiring { get; private set; }
    public bool ResetFire { get; private set; }

}