using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class EnemyShipTank : Ship
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
            switch (phase)
            {
                case 0:
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(.05f, -.05f), speed);
                    break;
                case 1:
                    transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                    break;
                case 2:
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-.05f, -.05f), speed);
                    break;
                case 3:
                    transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                    break;
                default:
                    break;
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
