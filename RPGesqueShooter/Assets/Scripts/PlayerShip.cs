using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerShip : Ship
    {
        public Weapon SecondaryWeapon;

        float inputAxisX;
        float inputAxisY;

        bool firePrimaryPressed = false;
        bool fireSecondaryPressed = false;

        public AudioClip fireSound;

        protected List<Weapon> secondaryWeapons = new List<Weapon>();

        protected void Awake()
        {
            PrimaryWeapon = PlayerData.PrimaryWeapon;
            SecondaryWeapon = PlayerData.SecondaryWeapon;
        }

        // Use this for initialization
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

        // FixedUpdate is called 50 times per second
        protected override void FixedUpdate()
        {


            HealthBar.healthFill = CurrentHP;

            if (firePrimaryPressed == false && Input.GetAxis("Primary Fire") > 0 && primaryWeapons != null)
            {
                firePrimaryPressed = true;
                foreach (var weapon in primaryWeapons)
                    weapon.FireBegin();
                //SoundManager.instance.PlaySingle(fireSound);
            }
            if (firePrimaryPressed && Input.GetAxis("Primary Fire") == 0)
            {
                firePrimaryPressed = false;
                foreach (var weapon in primaryWeapons)
                    weapon.FireEnd();
            }

            if (fireSecondaryPressed == false && Input.GetAxis("Secondary Fire") > 0 && secondaryWeapons != null)
            {
                fireSecondaryPressed = true;
                foreach (var weapon in secondaryWeapons)
                    weapon.FireBegin();
            }
            if (fireSecondaryPressed && Input.GetAxis("Secondary Fire") == 0)
            {
                fireSecondaryPressed = false;
                foreach (var weapon in secondaryWeapons)
                    weapon.FireEnd();
            }

            inputAxisX = Input.GetAxis("Move Horizontal");
            inputAxisY = Input.GetAxis("Move Vertical");

            if (inputAxisX != 0 || inputAxisY != 0)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(inputAxisX, inputAxisY), speed);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), Mathf.Clamp(transform.position.y, -4.5f, 0));
        }
    }
}