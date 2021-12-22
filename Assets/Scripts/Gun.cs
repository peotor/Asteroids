using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{

    [SerializeField] 
    private GunSettings _gunSettings;
    
    private IGunInput _gunInput;
    private FireGun _fireGun;

    public UnityEvent onGunFire;
    
    private void Awake()
    {
        _gunInput = _gunSettings.FireWithRightCtrl ? 
            new GunPlayerWasdInput() as IGunInput : 
            new GunPlayerArrowsInput() as IGunInput;
        
        _fireGun = new FireGun(_gunInput);
        _fireGun.OnFire += onGunFire.Invoke;
    }

    void Update()
    {
        _gunInput.ReadInput();
        _fireGun.CheckFire();        
    }

    private void OnDestroy()
    {
        _fireGun.OnFire -= onGunFire.Invoke;
    }
}