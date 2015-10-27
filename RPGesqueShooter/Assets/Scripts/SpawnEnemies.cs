using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SpawnEnemies : MonoBehaviour
    {
        // Variables for spawning Gameobject
        public GameObject SpawnLow;
        public GameObject SpawnMid;
        public GameObject SpawnHigh;

        // Variable for timer
        int timer = 0;

        // Called every fixed framerate frame
        public void FixedUpdate()
        {
            // if timer is greater than 5
            if (timer > 5)
            {
                // set roll to a random number between 0 and 1
                var roll = UnityEngine.Random.Range(0, 1.0f);
                
                // set x to random number between -6 and 6
                // set y to random number between 4.5 and 22.5
                float x = UnityEngine.Random.Range(-6.0f, 6.0f);
                float y = UnityEngine.Random.Range(4.5f, 22.5f);

                // if roll is greater than .6
                if (roll > .60f)
                {
                    // set spawn to instantiate enemies higher
                    var Spawn = Instantiate(SpawnHigh);

                    // set the position to a new vector using the x,y
                    Spawn.transform.position = new Vector3(x, y);
                }
                // if roll is less than or equal to .6 or roll is greater than .3
                if (roll <= .6f && roll > .3f)
                {
                    // set spawn to instaniate an enemy in the middle
                    var Spawn = Instantiate(SpawnMid);

                    // set the position to a new vector using the x,y
                    Spawn.transform.position = new Vector3(x, y);
                }
                // if roll is les than or equal to .3
                if (roll <= .3f)
                {
                    // set spawn to instantiate enemies lower
                    var Spawn = Instantiate(SpawnLow);

                    // set the position to a new vector using the x,y
                    Spawn.transform.position = new Vector3(x, y);
                }
                // set timer to 0
                timer = 0;
            }
            // if timer is not greater than 5
            // add 1 to timer
            else
            {
                timer++;
            }
            // if the y position is less than -5
            if (transform.position.y < -5)
            {
                // destroy the object
                Destroy(gameObject);
            }
        }
    }
}
