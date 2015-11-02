using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Enumeration for different types of Ships
public enum ShipType
{
    Player,
    Enemy
}

public class Ship : MonoBehaviour 
{
    // Variable for PrimaryWeapon
    public Weapon PrimaryWeapon;

    // Shield variable
    public ShieldModule Shield;

    // Variable for Engine
    public Engine Engine;

    // Variable for Bomb
    public Bomb Bomb;

    // Animation GameObject
    public GameObject DeathAnim;
    
    // Variable for Loot
    public Loot Loot;

    // Variable for Bomb
    public int BombCount;

    // Variable for MaxHP
    public int MaxHP;

    // Variable for Bounty
    public int Bounty;

    // Variable for CurrentHP
    public float CurrentHP;

    // Variable for speed
    protected float speed;
    
    // bool varibale for Shielf
    public bool shieldUp;
    
    // list of primaryWeapons
    protected List<Weapon> primaryWeapons = new List<Weapon>();

    // Variable for shieldCollider
    protected Collider2D shieldCollider;

	// Use this for initialization
    protected virtual void Start() 
    {
        // set the primaryNode to the Weapons_Primary
        var primaryNode = transform.FindChild("Weapons_Primary");

        // Checks the child count of primaryNode
        for (int i = primaryNode.transform.childCount - 1; i >= 0; i--)
        {
            // set weapon to instanstiate a GameObject as a Weapon
            var weapon = GameObject.Instantiate(PrimaryWeapon, primaryNode.GetChild(i).transform.position, primaryNode.transform.rotation) as Weapon;

            // set weapons parents to the primaryNode
            weapon.transform.parent = primaryNode;

            // add the weapon to the list of primaryWeapons
            primaryWeapons.Add(weapon);
        }
        // set speed to calculate the speed
        speed = CalculateSpeed();

        // if shield is not null
        if (Shield != null)
            // get the collider2D component
            shieldCollider = Shield.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
    protected virtual void Update() 
    {
        // if shield is not null
        // and CurrentShield is greater than 0
        if (Shield != null && Shield.CurrentShields > 0)
        {
            // set shieldCollider to true
            shieldCollider.enabled = true;
        }
        // if shield is not null
        // but CurrentShield is not greater than 0
        else if (Shield != null)
        {
            // set shieldCollider to false
            shieldCollider.enabled = false;

            // get the Sprite componenet
            // change the color of the shield
            Shield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        // if current health is less than or equal to 0
        if (CurrentHP <= 0)
        {
            // destory object
            Destroy(gameObject);

            // instantiate a death animcation in the
            // position of the ship
            Instantiate(DeathAnim, transform.position, transform.rotation);
        }
        //if (Shield.CurrentShields <= 0 && shieldUp)
        //{
        //    shieldUp = false;
        //    SoundManager.instance.PlaySound(SoundEffect.shieldDown, 1f);
        //}
	}

    // FixedUpdate is called 50 times per second
    protected virtual void FixedUpdate()
    {

    }

    // When another object enters a trigger collider attached to this object
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // if collision with with projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //  // get the projectile component
                // apply damage to the specified gameObject
                collision.gameObject.GetComponent<Projectile>().ApplyDamageTo(this.gameObject);
            //}
        }
        // if collision is with Ship
        if (collision.gameObject.CompareTag("Ship"))
        {
            // get the ship component
            // set the Current health to -10
            collision.gameObject.GetComponent<Ship>().CurrentHP -= 10;

            // set current health to -10
            CurrentHP -= 10;
        }
    }

    // Called when the renderer is no longer visible by any camera
    void OnBecameInvisible()
    {
        // destroys gameObject
        Destroy(gameObject);

        // play explosion sound
        SoundManager.instance.PlaySound(SoundEffect.explosion, GameData.explosionVolume);        
        
        // set playerScore to +1
        Score.playerScore++;
    }

    /// Should return 1f for an average maneuverability, lower values create less responsive handling
    float CalculateSpeed()
    {
        return GameData.playerMoveSpeed;
    }
}
