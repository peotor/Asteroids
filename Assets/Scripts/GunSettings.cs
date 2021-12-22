using UnityEngine;

[CreateAssetMenu(fileName = "GunSettings", menuName = "Create Gun", order = 0)]
public class GunSettings : ScriptableObject
{
    [SerializeField] private bool fireWithRightCtrl;
    public bool FireWithRightCtrl => fireWithRightCtrl;
}