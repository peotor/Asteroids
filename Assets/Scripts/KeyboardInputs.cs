using UnityEngine;

//two implementations for inputs

//added 2 inputs just for demonstration purposes - its easy to swap input implementation;
// Check projects axis for axis names and settings. You can add 2nd sheep to the scene and make this game cooperative!
//one player plays on Arrows, another uses WASD keys.
public class KeyboardWasdInput: IShipInput
{
    public void ReadInput()
    {
        
        
        Rotation = Input.GetAxis("Horizontal wasd");
        Thrust = Input.GetAxis("Vertical wasd");
    }

    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    
}

public class KeyboardArrowsInput: IShipInput
{
    public void ReadInput()
    {
        //I added 2 axis to separate wasd and arrows inputs.
        
        Rotation = Input.GetAxis("Horizontal arrows");
        Thrust = Input.GetAxis("Vertical arrows");
    }

    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    
}