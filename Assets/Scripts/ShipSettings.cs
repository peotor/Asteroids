using UnityEngine;

[CreateAssetMenu(fileName = "Ship Settings", menuName = "Create ship settings", order = 0)]
public class ShipSettings : ScriptableObject
{
    [SerializeField] private float turnSpeed = 25;
    [SerializeField] private float moveSpeed = 50;

    public bool useArrows = true;
    
    public float TurnSpeed => turnSpeed;
    public float FlySpeed => moveSpeed;
}
