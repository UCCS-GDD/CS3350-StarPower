using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Inherits from the Projectile class
    class Bullet : Projectile
    {
        // Applies damage to specified GameObject
        public override void ApplyDamageTo(UnityEngine.GameObject target)
        {
            // if the target object is equal to
            // the source object, return 
            if (target == source)
                return;

            // Check the targets tag
            switch (target.tag)
            {
                // if it is the ship
                case "Ship":
                    // Get the ship and the shield components
                    var ship = target.GetComponent<Ship>();
                    var shield = ship.Shield;

                    // if the shield exists
                    // Set damage to the CurrentShields
                    if (shield != null && shield.CurrentShields >= 0)
                    {
                        shield.CurrentShields -= damage;
                    }
                    // if the shield does not exist
                    // Set damage to the ship
                    else
                    {
                        ship.CurrentHP -= damage;
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
}
