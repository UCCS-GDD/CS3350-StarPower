using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	public static Credits instance = null;

	public int currentCredits;
	public int maxCredits;

    //text box for current upgrade cost
    public Text currentCost;

    /// <summary>
    /// The value of the ship upon entering the menu: the amount of credits already paid for it
    /// </summary>
    public int oldValue;

    /// <summary>
    /// The value of the current ship with all edits applied
    /// </summary>
    public int currentValue;

    void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update ()
    {
		GetComponent<Text> ().text = "Credits: " + this.currentCredits.ToString ();

        int cost = currentValue - oldValue;
        currentCost.text = "Upgrade Cost: " + cost;

        if (cost > Credits.instance.currentCredits)
            currentCost.color = Color.red;
        else
            currentCost.color = Color.black;
    }

    /// <summary>
    /// Calculates the value of a given weapon
    /// </summary>
    /// <param name="weapon">The weapon to calculate the value of</param>
    /// <returns></returns>
    public static int CalculateWeaponCost(Weapon weapon)
    {
        float cost = 0;

        cost += (int)(GameData.projectileCountDiv / weapon.ProjectileCount);
        cost += (int)((weapon.ProjectileSpread + GameData.spreadOffset) * GameData.spreadMult);
        cost += (int)(weapon.BurstFireCount * GameData.burstFireCountMult);
        cost += (int)((1 - weapon.CooldownTime) * GameData.cooldownRateMult);
        cost += (int)((1 - weapon.FireRate) * GameData.refireRateMult);

        return (int)cost;
    }

    //Down here should go other functions to calculate the value of other ship components such as shield, armor, engine etc.
}
