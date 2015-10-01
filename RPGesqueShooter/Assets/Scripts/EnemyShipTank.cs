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
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.05f), speed);
        }

        public void OnBecameVisible()
        {
            isActive = true;
        }
    }
}
