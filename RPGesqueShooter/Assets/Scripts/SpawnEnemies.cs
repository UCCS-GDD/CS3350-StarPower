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

        public void FixedUpdate()
        {
            var roll = UnityEngine.Random.Range(0, 1.0f);

            if (roll > .99f)
            {
                float x = UnityEngine.Random.Range(-6.0f, 6.0f);
                float y = UnityEngine.Random.Range(4.5f, 22.5f);
                var Spawn = Instantiate(SpawnHigh);
                Spawn.transform.position = new Vector3(x, y);
            }
        }
    }
}
