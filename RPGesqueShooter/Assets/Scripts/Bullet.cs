using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Bullet : Projectile
    {
        public override void ApplyDamageTo(UnityEngine.GameObject target)
        {
            if (target == source)
                return;

            switch (target.tag)
            {
                case "Ship":
                    var ship = target.GetComponent<Ship>();
                    var shield = ship.Shield;

                    if (shield != null && shield.CurrentShields >= 0)
                    {
                        Debug.Log("Hit Shield");
                        shield.CurrentShields -= damage;
                    }
                    else
                    {
                        Debug.Log("Hit Ship");
                        ship.CurrentHP -= damage;
                    }
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
