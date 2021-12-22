using UnityEngine;



[CreateAssetMenu(fileName = "Factory Settings", menuName = "Create new Factory Settings", order = 0)]
public class PrefabCreatorSettings : ScriptableObject
{
    [SerializeField] private GameObject[] prefabs;

    [Header("How many to create")] [SerializeField]
    private int createCount = 2;

    [Header("Randomization options")] [SerializeField]
    private RotationOptions rotationOption;

    [SerializeField] private float randomizationPositionOffset = 8;


    [SerializeField] private bool atOrigin;

    public RotationOptions RotationOption => rotationOption;
    public int CreateCount => createCount;

    public float RandomizationPositionOffset => randomizationPositionOffset;

    public GameObject[] Prefabs => prefabs;

    public bool AtOrigin => atOrigin;
}



public enum RotationOptions
{
    Random,
    TowardsCenter,
    Relative
}
