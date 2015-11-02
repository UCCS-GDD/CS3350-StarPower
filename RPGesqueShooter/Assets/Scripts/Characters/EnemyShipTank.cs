using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Inherits from the Ship class
    class EnemyShipTank : Ship
    {
        SpriteRenderer renderer;

        public Sprite fullHealth;
        public Sprite reducedHealth;
        public Sprite halfHealth;
        public Sprite lowHealth;

        // bool variable for isActive
        bool isActive = false;

        // int variable for the phase of the game
        int phase = 0;

        // int variable for timer of game
        int timer = 0;

        // Used to inititalize any variables or game state before the game starts
        public void Awake()
        {
            //
            this.MaxHP = GameData.tankBaseHealth;
            
            //
            this.CurrentHP = this.MaxHP;

            // get the sprite renderer of this object
            renderer = GetComponent<SpriteRenderer>();

            // set the ship type
            type = ShipType.Enemy;
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
            //  if object is within certain distance of player
            // check the phases of the game
            switch (phase)
            {
                // linearly interpolates between the two vectors
                // the position of the object
                case 0:
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(.05f, -.05f), speed);
                    break;
                // linearly interpolates between the two vectors
                // the position of the object
                case 1:
                    transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                    break;
                // linearly interpolates between the two vectors
                // the position of the object
                case 2:
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-.05f, -.05f), speed);
                    break;
                // linearly interpolates between the two vectors
                // the position of the object
                case 3:
                    transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                    break;
                    // default case
                default:
                    break;
            }

            // if the timer is greater than 50
            if (timer > 50)
            {
                // if it is in the third phase
                // set phase to 0
                if (phase == 3)
                {
                    phase = 0;
                }
                // if it is in a different phase
                // increase the phase
                else
                {
                    phase++;
                }
                // set timer to 0
                timer = 0;
            }
            // if the timer is less than 50
            // increase the timer
            else
            {
                timer++;
            }
        }

        // Called when the renderer became visible by any camera
        public void OnBecameVisible()
        {
            isActive = true;
        }
    }
}
