using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Ship : MonoBehaviour 
{
    public Weapon PrimaryWeapon;
    public ShieldModule Shield;
    public Engine Engine;
    public Bomb Bomb;
    public GameObject DeathAnim;
    public int BombCount;
    public Loot Loot;
    public int MaxHP;
    public float CurrentHP;
    public int Bounty;

    protected float speed;
    protected List<Weapon> primaryWeapons = new List<Weapon>();
    protected Collider2D shieldCollider;

	// Use this for initialization
    protected virtual void Start() 
    {
        var primaryNode = transform.FindChild("Weapons_Primary");
        for (int i = primaryNode.transform.childCount - 1; i >= 0; i--)
        {
            var weapon = GameObject.Instantiate(PrimaryWeapon, primaryNode.GetChild(i).transform.position, primaryNode.transform.rotation) as Weapon;
            weapon.transform.parent = primaryNode;
            primaryWeapons.Add(weapon);
        }

        speed = CalculateSpeed();
        if (Shield != null)
            shieldCollider = Shield.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
    protected virtual void Update() 
    {
        if (Shield != null && Shield.CurrentShields > 0)
        {
            shieldCollider.enabled = true;
        }
        else if (Shield != null)
        {
            shieldCollider.enabled = false;
            Shield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(DeathAnim, transform.position, transform.rotation);
        }
	}

    // FixedUpdate is called 50 times per second
    protected virtual void FixedUpdate()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Projectile"))
        {
            collision.gameObject.GetComponent<Projectile>().ApplyDamageTo(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        
        Score.playerScore++;
    }

    /// <summary>
    /// Should return 1f for an average maneuverability, lower values create less responsive handling
    /// </summary>
    /// <returns></returns>
    float CalculateSpeed()
    {
        return 1f;
    }
}
