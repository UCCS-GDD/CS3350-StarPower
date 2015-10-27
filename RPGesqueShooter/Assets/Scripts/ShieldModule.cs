using UnityEngine;
using System.Collections;

public class ShieldModule : MonoBehaviour 
{
    // Variables for Shield
    public int ShieldMax;
    public float CurrentShields;
    
    // Variables for Recharge of Shield
    public float RechargePerSecond;
    public float RechargeDelay;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        // set the ShieldBar fill to CurrentShields
        ShieldBar.shieldFill = CurrentShields;
	}
}
