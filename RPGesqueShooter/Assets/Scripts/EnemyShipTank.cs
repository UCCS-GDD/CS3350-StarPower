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
        // bool variable for isActive
        bool isActive = false;

        // int variable for the phase of the game
        int phase = 0;

        // int variable for timer of game
        int timer = 0;

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
