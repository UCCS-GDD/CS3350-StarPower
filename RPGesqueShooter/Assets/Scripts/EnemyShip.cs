using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Inherits from the Ship class
    class EnemyShip : Ship
    {
        // bool variable for isActive
        bool isActive = false;

        public void Awake()
        {
            this.MaxHP = GameData.defaultBaseHealth;
            this.CurrentHP = this.MaxHP;
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
}
