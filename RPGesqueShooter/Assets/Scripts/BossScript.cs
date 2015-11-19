using UnityEngine;
using System.Collections;

public class BossScript : Ship
{
    bool isActive = false;
    SpriteRenderer renderer;

    // Used to inititalize any variables or game state before the game starts
    public void Awake()
    {
        // set max health 
        this.MaxHP = GameData.defaultBossHealth;

        // set current health
        this.CurrentHP = this.MaxHP;

        // get the sprite renderer of this object
        renderer = GetComponent<SpriteRenderer>();

        // set the ship type
        type = ShipType.Enemy;

        // if the ship is smoking
        isSmoking = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Calls the parent method
        base.Update();

        // if active
        // Check each weapon in the list of primary weapons
        if (isActive)
            foreach (var weapon in primaryWeapons)
            {
                // if the weapon can fire
                // fire weapon
                if (weapon.ReadyToFire)
                    weapon.FireBegin();
                // if the weapon cannot fire
                // stop firing weapon
                else
                    weapon.FireEnd();
            }
    }

    // Called every fixed framerate frame
    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.05f), speed);
    }

    // Called when the renderer became visible by any camera
    public void OnBecameVisible()
    {
        isActive = true;
    }
}