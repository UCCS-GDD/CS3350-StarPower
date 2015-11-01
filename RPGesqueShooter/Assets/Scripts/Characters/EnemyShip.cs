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

        SpriteRenderer renderer;

        public Sprite fullHealth;
        public Sprite reducedHealth;
        public Sprite halfHealth;
        public Sprite lowHealth;

        // bool variable for isActive
        bool isActive = false;

        // Used to inititalize any variables or game state before the game starts
        public void Awake()
        {
            // set the MaxHP to the defaultBaseHealth
            this.MaxHP = GameData.defaultBaseHealth;

            // set the currentHP to the MaxHP
            this.CurrentHP = this.MaxHP;

            // get the sprite renderer of this object
            renderer = GetComponent<SpriteRenderer>();
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
            }
            else if (CurrentHP <= (MaxHP * .5f) && CurrentHP > (MaxHP * .25f))
            {
                renderer.sprite = halfHealth;
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
