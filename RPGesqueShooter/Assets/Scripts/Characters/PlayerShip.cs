using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Inherits from Ship
    public class PlayerShip : Ship
    {
        // Variable for secondaryWeapon
        public Weapon SecondaryWeapon;

        // Variables for x,y axis
        float inputAxisX;
        float inputAxisY;

        // booleans for firing weapon
        bool firePrimaryPressed = false;
        bool fireSecondaryPressed = false;

        // AudioClip sound
        public AudioClip fireSound;

        // List of secondaryWeapons
        protected List<Weapon> secondaryWeapons = new List<Weapon>();

        // Used to inititalize any variables or game state before the game starts
        protected void Awake()
        {
            // set the PrimaryWeapon to the players PrimaryWeapon
            PrimaryWeapon = PlayerData.PrimaryWeapon;

            // set the SecondaryWeapon to the players SecondaryWeapon
            SecondaryWeapon = PlayerData.SecondaryWeapon;            
        }

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

            // set the ship type
            type = ShipType.Player;
        }

        // Called every fixed framerate frame
        protected override void FixedUpdate()
        {
            // set health bar fill to CurrentHP
            HealthBar.healthFill = CurrentHP;

            // checks if weapon was fired and that 
            // weapons are not null
            if (firePrimaryPressed == false && Input.GetAxis("Primary Fire") > 0 && primaryWeapons != null)
            {
                // set the presed primary fire to true
                firePrimaryPressed = true;

                // for each weapon in primaryWeapons
                // allow weapon to fire
                foreach (var weapon in primaryWeapons)
                    weapon.FireBegin();

                // play shooting sound
                //SoundManager.instance.PlaySingle(fireSound);
            }
            // checks if primary fire was pressed
            if (firePrimaryPressed && Input.GetAxis("Primary Fire") == 0)
            {
                // set pressed primary fire to false
                firePrimaryPressed = false;

                // for each weapon in primaryWeapons
                // do not allow weapon to fire
                foreach (var weapon in primaryWeapons)
                    weapon.FireEnd();
            }
            // checks if secondary fire was pressed and that 
            // secondaryWeapons are not null
            if (fireSecondaryPressed == false && Input.GetAxis("Secondary Fire") > 0 && secondaryWeapons != null)
            {
                // set pressed secondary fire to true
                fireSecondaryPressed = true;

                // for each weapon in secondaryWeapons
                // allow weapon to fire
                foreach (var weapon in secondaryWeapons)
                    weapon.FireBegin();
            }
            // checks if secondary fire was pressed
            if (fireSecondaryPressed && Input.GetAxis("Secondary Fire") == 0)
            {
                // set pressed secondary fire to false
                fireSecondaryPressed = false;

                // for each weapon in secondaryWeapons
                // dont allow weapon to fire
                foreach (var weapon in secondaryWeapons)
                    weapon.FireEnd();
            }
            // Gets the axis input 
            inputAxisX = Input.GetAxis("Move Horizontal");
            inputAxisY = Input.GetAxis("Move Vertical");

            // linearly interpolates between the two vectors
            // the position of the object depending the the input
            if (inputAxisX != 0 || inputAxisY != 0)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(inputAxisX, inputAxisY), speed);
            }
            // clamps the player within the window
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), Mathf.Clamp(transform.position.y, -4.5f, 0));
        }
    }
}