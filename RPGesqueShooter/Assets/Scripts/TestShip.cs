using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class TestShip : Ship
    {
        public Weapon SecondaryWeapon;

        public bool shouldFireSecondary = false;

        protected List<Weapon> secondaryWeapons = new List<Weapon>();

        protected override void Start()
        {
            base.Start();

            var secondaryNode = transform.FindChild("Weapons_Secondary");
            for (int i = secondaryNode.transform.childCount - 1; i >= 0; i--)
            {
                var weapon = GameObject.Instantiate(SecondaryWeapon, secondaryNode.GetChild(i).transform.position, secondaryNode.transform.rotation) as Weapon;
                weapon.transform.parent = secondaryNode;
                secondaryWeapons.Add(weapon);
            }
        }

        protected override void Update()
        {
            base.Update();

                foreach (var weapon in secondaryWeapons)
                {
                    if (weapon.ReadyToFire && shouldFireSecondary)
                        weapon.FireBegin();
                    else
                        weapon.FireEnd();
                }
                foreach (var weapon in primaryWeapons)
                {
                    if (weapon.ReadyToFire && !shouldFireSecondary)
                        weapon.FireBegin();
                    else
                        weapon.FireEnd();
                }
        }

        public void UpdateWeapons(bool updatePrimary, float projCount, float spread, WeaponFireMode mode, float cooldown, float refire, float burstCount)
        {
            List<Weapon> updateList;

            if (updatePrimary)
                updateList = primaryWeapons;
            else
                updateList = secondaryWeapons;

            foreach (var weapon in updateList)
            {
                weapon.ProjectileCount = (int)projCount;
                weapon.ProjectileSpread = spread;
                weapon.FireMode = mode;
                weapon.CooldownTime = cooldown;
                weapon.FireRate = refire;
                weapon.BurstFireCount = (int)burstCount;
            }
        }
    }
}
