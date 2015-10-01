using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SpawnEnemies : MonoBehaviour
    {
        public GameObject SpawnLow;
        public GameObject SpawnMid;
        public GameObject SpawnHigh;

        int timer = 0;

        public void FixedUpdate()
        {
            if (timer > 5)
            {
                var roll = UnityEngine.Random.Range(0, 1.0f);

                float x = UnityEngine.Random.Range(-6.0f, 6.0f);
                float y = UnityEngine.Random.Range(4.5f, 22.5f);

                if (roll > .60f)
                {
                    var Spawn = Instantiate(SpawnHigh);
                    Spawn.transform.position = new Vector3(x, y);
                }
                if (roll <= .6f && roll > .3f)
                {
                    var Spawn = Instantiate(SpawnMid);
                    Spawn.transform.position = new Vector3(x, y);
                }
                if (roll <= .3f)
                {
                    var Spawn = Instantiate(SpawnLow);
                    Spawn.transform.position = new Vector3(x, y);
                }

                timer = 0;
            }
            else
            {
                timer++;
            }

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}
