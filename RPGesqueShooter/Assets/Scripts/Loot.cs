using UnityEngine;
using System.Collections;

public class Loot : Projectile
{
    public static int shieldValue = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Called once per frame if Monobehaviour is enabled
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ship")
        {
            // if the target object is equal to
            // the source object, return 
            if (collider == source)
                return;

            // Check the targets tag
            switch (collider.tag)
            {
                // if it is the ship
                case "Ship":
                    // Get the ship and the shield components
                    var ship = collider.GetComponent<Ship>();
                    var shield = ship.Shield;

                    // if the shield exists
                    // Set damage to the CurrentShields
                    if (shield != null && shield.CurrentShields >= 0)
                    {
                        Debug.Log("Hit Shield");
                        shield.CurrentShields += 10;
                    }
                    break;
                // deafult case
                default:
                    break;
            }
            // Destroys object
            Destroy(gameObject);
        }
    }

    public override void ApplyDamageTo(UnityEngine.GameObject target)
    {

    }
}