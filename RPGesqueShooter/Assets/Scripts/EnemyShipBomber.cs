using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class EnemyShipBomber : Ship
    {
        bool isActive = false;

        int phase = 0;

        int timer = 0;

        protected override void Update()
        {
            base.Update();

            if (isActive)
                foreach (var weapon in primaryWeapons)
                {
                    if (weapon.ReadyToFire)
                        weapon.FireBegin();
                    else
                        weapon.FireEnd();
                }
        }

        public void FixedUpdate()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (Vector3.Distance(transform.position, player.transform.position) > 5f)
            {
                switch (phase)
                {
                    case 0:
                        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.02f), speed);
                        break;
                    case 1:
                        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(.05f, 0), speed);
                        break;
                    case 2:
                        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.02f), speed);
                        break;
                    case 3:
                        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-.05f, 0), speed);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                StartCoroutine(MoveToPlayer(player, 5f));
            }

            if (timer > 50)
            {
                if (phase == 3)
                {
                    phase = 0;
                }
                else
                {
                    phase++;
                }

                timer = 0;
            }
            else
            {
                timer++;
            }
        }

        public void OnBecameVisible()
        {
            isActive = true;
        }

        public IEnumerator MoveToPlayer(GameObject player, float time)
        {
            // zero the time
            float currentTime = 0.0f;

            do
            {
                // scale up and increase time each frame
                transform.position = Vector3.Lerp(transform.position, player.transform.position, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);
        }
    }
}
