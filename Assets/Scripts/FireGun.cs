using System;

public class FireGun
{

    private readonly IGunInput _gunInput;

    private bool _readyToFire = true;
    
    public event Action OnFire;

    public FireGun(IGunInput gunInput )
    {
        _gunInput = gunInput;
    }

    public void CheckFire()
    {
        if (_readyToFire && _gunInput.IsFiring)
        {
            OnFire?.Invoke();
            _readyToFire = false;
        }

        if (!_readyToFire && _gunInput.ResetFire)
        {
            _readyToFire = true;
        }
    }
    
}