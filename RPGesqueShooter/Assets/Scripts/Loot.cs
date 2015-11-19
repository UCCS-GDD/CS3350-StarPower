using UnityEngine;
using System.Collections;

public class Loot : Projectile
{
    public float dropSpeed;

    // Use this for initialization
    void Start()
    {
        dropSpeed = 0.5f;
    }

    // Called once per frame if Monobehaviour is enabled
    void Update()
    {
        transform.position += new Vector3(0, -dropSpeed * Time.deltaTime, 0);
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
                    // add health to shield
                    if (shield != null && shield.CurrentShields >= 0)
                    {
                        Debug.Log("Hit Shield");
                        shield.CurrentShields += GameData.deafultShieldPowerUp;
                    }
                    // if shield does not exist
                    // add health to shield
                    if (shield.CurrentShields <= 0)
                    {
                        shield.CurrentShields += 20;
                        shield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
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