using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Inherits from Ship
    class TestShip : Ship
    {
        // Weapon variable for SecondaryWeapon
        public Weapon SecondaryWeapon;

        // bool for firing secondary weapon
        public bool shouldFireSecondary = false;

        // list of secondary weapons
        protected List<Weapon> secondaryWeapons = new List<Weapon>();

        // Use this for initialization
        protected override void Start()
        {
            // Calls the parent method
            base.Start();

            // set the secondaryNode to the Weapons_Secondary
            var secondaryNode = transform.FindChild("Weapons_Secondary");

            // Checks the child count of secondaryNode
            for (int i = secondaryNode.transform.childCount - 1; i >= 0; i--)
            {
                // set weapon to instanstiate a GameObject as a Weapon
                var weapon = GameObject.Instantiate(SecondaryWeapon, secondaryNode.GetChild(i).transform.position, secondaryNode.transform.rotation) as Weapon;

                // set weapons parents to the secondaryNode
                weapon.transform.parent = secondaryNode;

                // add the weapon to the list of secondaryWeapons
                secondaryWeapons.Add(weapon);
            }
        }

        // Update is called once per frame
        protected override void Update()
        {
            // Calls the parent method
            base.Update();

            // for each weapon in the secondaryWeapons
            foreach (var weapon in secondaryWeapons)
            {
                // if weapon can fire and is allowed to
                // begin firing
                if (weapon.ReadyToFire && shouldFireSecondary)
                    weapon.FireBegin();
                // if weapon cannot fire
                // stop firing
                else
                    weapon.FireEnd();
            }
            // for each weapon in primaryWeapons
            foreach (var weapon in primaryWeapons)
            {
                // if weapon can fire and is not allowed to fire secodary
                // being firing
                if (weapon.ReadyToFire && !shouldFireSecondary)
                    weapon.FireBegin();
                // if weapon cannot fire
                // stop firing
                else
                    weapon.FireEnd();
            }
        }

        // Updates the Primary and Secondary Wepaons
        public void UpdateWeapons(bool updatePrimary, float projCount, float spread, WeaponFireMode mode, float cooldown, float refire, float burstCount)
        {
            // list of new weapons
            List<Weapon> updateList;

            // if primary weapons
            // add primaryWeapons to new list of weapons
            if (updatePrimary)
                updateList = primaryWeapons;
            // if secondary weapons
            // add secondaryWeapons to the new list of weapons
            else
                updateList = secondaryWeapons;

            // for each weapon in the new list of weapons
            foreach (var weapon in updateList)
            {
                // set the weapon ProjectileCount
                weapon.ProjectileCount = (int)projCount;

                // set the weapon ProjectileSpread
                weapon.ProjectileSpread = spread;

                // set the weapon FireMode
                weapon.FireMode = mode;

                // set the weapon CooldownTime
                weapon.CooldownTime = cooldown;

                // set the weapon FireRate
                weapon.FireRate = refire;

                // set the weapon BurstFireCount
                weapon.BurstFireCount = (int)burstCount;
            }
        }
    }
}
