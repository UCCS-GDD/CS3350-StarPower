using UnityEngine;
using System.Collections;

public enum BossState
{
    FullHealth,
    ReducedHealth,
    HalfHealth,
    LowHealth
}

public class BossScript : Ship
{
    // variable for if the object is active or not
    bool isActive = false;

    // variable for current state of the boss
    private BossState currentState = BossState.FullHealth;

    // variable for sprite renderer
    SpriteRenderer renderer;

    // variables for the sprites to be used at certain health
    public Sprite fullHealth;
    public Sprite reducedHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;

    // Used to inititalize any variables or game state before the game starts
    public void Awake()
    {
        // set max health of the boss 
        this.MaxHP = GameData.defaultBossHealth;

        // set current health of the boss 
        this.CurrentHP = this.MaxHP;

        // get the sprite renderer of this object
        renderer = GetComponent<SpriteRenderer>();

        // set the ship type to Enemy
        type = ShipType.Enemy;

        // whether or not the ship is smoking 
        isSmoking = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // apply the correct sprite based on the current health
        if (CurrentHP > (MaxHP * .75f))
        {
            renderer.sprite = fullHealth;
        }
        else if (CurrentHP <= (MaxHP * .75f) && CurrentHP > (MaxHP * .5f))
        {
            renderer.sprite = reducedHealth;
            //isSmoking = true;
        }
        else if (CurrentHP <= (MaxHP * .5f) && CurrentHP > (MaxHP * .25f))
        {
            renderer.sprite = halfHealth;
            //isOnFire = true;
        }
        else if (CurrentHP <= (MaxHP * .25))
        {
            renderer.sprite = lowHealth;
        }

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
    protected override void FixedUpdate()
    {
        // switchess through the different states of the boss
        switch (currentState)
        {
                // if boss has full health
            case BossState.FullHealth:
                break;

                // if boss has reduced health
            case BossState.ReducedHealth:
                break;

                // if boss has half health
            case BossState.HalfHealth:
                break;

                // if boss has low health
            case BossState.LowHealth:
                break;

                // default case
            default:
                break;
        }
        // clamps the boss within the window
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.0f), Mathf.Clamp(transform.position.y, 1.0f, 4.0f));
    }

    // Called when the renderer became visible by any camera
    public void OnBecameVisible()
    {
        isActive = true;
    }
}