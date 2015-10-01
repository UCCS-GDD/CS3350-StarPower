using System;
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

            if (Vector3.Distance(transform.position, player.transform.position) > 1)
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
                transform.position = Vector3.Lerp(transform.position, player.transform.position, 3f);
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
    }
}
