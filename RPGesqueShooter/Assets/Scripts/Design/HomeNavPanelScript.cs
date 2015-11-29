using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class HomeNavPanelScript : MonoBehaviour
    {
        // variables for the weapons for the ship
        public static Weapon PrimaryWeapon;
        public static Weapon SecondaryWeapon;
        public Weapon DefaultPrimaryWeapon;
        public Weapon DefaultSecondaryWeapon;

        // variable for the shield for the ship
        public static ShieldModule Shield;

        // GameObject test ship
        // shows the user what their ship will be like
        public GameObject TestShip;

        // variable for the MenuMode
        MenuMode mode = MenuMode.PrimaryWeapon;

        // standard toggle with on/off state
        // isSingleFire, isBurstFire, isAutoFire
        Toggle isSingleFire;
        Toggle isBurstFire;
        Toggle isAutoFire;

        // sliders which can be moved from minimum to maximum value
        // projectileCount, spread, burstFireCount, cooldown, refireRate
        Slider projectileCount;
        Slider spread;
        Slider burstFireCount;
        Slider cooldown;
        Slider refireRate;

        // Used to initialize any variables or
        // game state before the game starts
        public void Awake()
        {
            // if the PrimaryWeapon is null
            // set the DefaultPrimaryWeapon as the PrimaryWeapon
            if (PlayerData.PrimaryWeapon == null)
                PlayerData.PrimaryWeapon = PrimaryWeapon = Instantiate(DefaultPrimaryWeapon) as Weapon;

            // if the PrimaryWeapon is not null
            // set the PrimaryWeapon to the PrimaryWeapon
            else
                PrimaryWeapon = PlayerData.PrimaryWeapon;

            // if the SecondaryWeapon is null
            // set the DefaultSecondaryWeapon as the SecondaryWeapon
            if (PlayerData.SecondaryWeapon == null)
                PlayerData.SecondaryWeapon = SecondaryWeapon = Instantiate(DefaultSecondaryWeapon) as Weapon;

            // if the SecondaryWeapon is not null
            // set the SecondaryWeapon to the SecondaryWeapon
            else
                SecondaryWeapon = PlayerData.SecondaryWeapon;

            // get the TestShip components
            var ship = TestShip.GetComponent<TestShip>();

            // set the test ships primary and secondary weapons
            ship.PrimaryWeapon = PrimaryWeapon;
            ship.SecondaryWeapon = SecondaryWeapon;
        }

        // Use this for initialization
        public void Start()
        {
            // gets the WeaponEditPanel and FireModePanel
            var wepPanel = transform.parent.transform.FindChild("WeaponEditPanel");
            var panel = wepPanel.transform.FindChild("FireModePanel");

            // gets the Toggle components of the fire modes
            isSingleFire = panel.transform.FindChild("Single").GetComponent<Toggle>();
            isBurstFire = panel.transform.FindChild("Burst").GetComponent<Toggle>();
            isAutoFire = panel.transform.FindChild("Auto").GetComponent<Toggle>();

            // get the ProjectileCountPanel
            // set projectileCount to the Slider components of the ProjectileCountPanel
            panel = wepPanel.transform.FindChild("ProjectileCountPanel");
            projectileCount = panel.transform.FindChild("Slider").GetComponent<Slider>();

            // get the SpreadPanel
            // set spread to the Slider components of the SpreadPanel
            panel = wepPanel.transform.FindChild("SpreadPanel");
            spread = panel.transform.FindChild("Slider").GetComponent<Slider>();

            // get the BurstFireCountPanel
            // set burstFireCount to the Slider components of the BurstFireCountPanel
            panel = wepPanel.transform.FindChild("BurstFireCountPanel");
            burstFireCount = panel.transform.FindChild("Slider").GetComponent<Slider>();

            // get the CooldownSpeedPanel
            // set cooldown to the Slider components of the CooldownSpeedPanel
            panel = wepPanel.transform.FindChild("CooldownSpeedPanel");
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>();

            // get the RefireRatePanel
            // set refireRate to the Slider Components of the RefireRatePanel
            panel = wepPanel.transform.FindChild("RefireRatePanel");
            refireRate = panel.transform.FindChild("Slider").GetComponent<Slider>();

            Credits.instance.oldValue = Credits.CalculateWeaponCost(PrimaryWeapon);
            Credits.instance.oldValue += Credits.CalculateWeaponCost(SecondaryWeapon);
        }

        // Opens primary weapon menu
        public void ClickPrimaryWeapon()
        {
            // play menu sound
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // set the text to say "Primary Weapon"
            Text temp = GameObject.FindGameObjectWithTag("WeaponEditLabel").GetComponent<Text>();
            temp.text = "Primary Weapon";            

            // check the different menus
            switch (mode)
            {
                // if in the PrimaryWeapon menu
                case MenuMode.PrimaryWeapon:
                    break;

                // if in the SecondaryWeapon menu
                case MenuMode.SecondaryWeapon:

                    // update secondary weapon
                    UpdateWeapon(SecondaryWeapon);

                    // get the WeaponEditPanel components
                    // set the primary weapon to true
                    // load the primary weapon
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().isPrimary = true;
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().LoadWeapon(PrimaryWeapon);

                    // get the test ships components
                    // set shouldFireSecondary to false
                    TestShip.GetComponent<TestShip>().shouldFireSecondary = false;

                    // set mode to PrimaryWeapon
                    mode = MenuMode.PrimaryWeapon;
                    break;

                // if in the Shield menu
                case MenuMode.Shield:
                    break;

                // if in the Armor menu 
                case MenuMode.Armor:
                    break;

                // if in the Engine menu 
                case MenuMode.Engine:
                    break;
            }
        }

        // Opens secondary weapon menu
        public void ClickSecondaryWeapon()
        {
            // Play menu sound
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // set the text to say "Secondary Weapon"
            Text temp = GameObject.FindGameObjectWithTag("WeaponEditLabel").GetComponent<Text>();
            temp.text = "Secondary Weapon";

            // check the different menus
            switch (mode)
            {
                // if in the PrimaryWeapon menu
                case MenuMode.PrimaryWeapon:

                    // update primary wepaon
                    UpdateWeapon(PrimaryWeapon);

                    // get the WeaponEditPanel componenets 
                    // set the primary weapon to false
                    // load the secondary weapon
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().isPrimary = false;
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().LoadWeapon(SecondaryWeapon);

                    // get the TestShip components
                    // set shouldFireSecondary to true
                    TestShip.GetComponent<TestShip>().shouldFireSecondary = true;

                    // set the mode to SecondaryWeapon
                    mode = MenuMode.SecondaryWeapon;
                    break;

                // if in the SecondaryWeapon menu
                case MenuMode.SecondaryWeapon:
                    break;

                // if in the Shield menu
                case MenuMode.Shield:
                    break;

                // if in the Armor menu
                case MenuMode.Armor:
                    break;

                // if in the Engine menu
                case MenuMode.Engine:
                    break;
            }
        }

        // Opens the shield menu
        public void ClickShield()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // set the text to say "Shield"
            Text temp = GameObject.FindGameObjectWithTag("WeaponEditLabel").GetComponent<Text>();
            temp.text = "Shield";

            // check the different menus
            switch (mode)
            {
                    // if in the PrimaryWeapon menu
                case MenuMode.PrimaryWeapon:
                    break;

                    // if in the SecondaryWeapon menu
                case MenuMode.SecondaryWeapon:
                    break;

                    // if in the Shield menu
                case MenuMode.Shield:

                    break;

                    // if in the Armor menu
                case MenuMode.Armor:
                    break;

                    // if in the Engine menu
                case MenuMode.Engine:
                    break;
            }
        }

        // Opens the armor menu 
        public void ClickArmor()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // set the text to say "Armor"
            Text temp = GameObject.FindGameObjectWithTag("WeaponEditLabel").GetComponent<Text>();
            temp.text = "Armor";


            // check the different menus
            switch (mode)
            {
                // if in the PrimaryWeapon menu
                case MenuMode.PrimaryWeapon:
                    break;

                // if in the SecondaryWeapon menu
                case MenuMode.SecondaryWeapon:
                    break;

                // if in the Shield menu
                case MenuMode.Shield:
                    break;

                // if in the Armor menu
                case MenuMode.Armor:

                    break;

                // if in the Engine menu
                case MenuMode.Engine:
                    break;
            }
        }

        // Opens the engine menu 
        public void ClickEngine()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // set the text to say "Engine"
            Text temp = GameObject.FindGameObjectWithTag("WeaponEditLabel").GetComponent<Text>();
            temp.text = "Engine";

            // check the different menus
            switch (mode)
            {
                // if in the PrimaryWeapon menu
                case MenuMode.PrimaryWeapon:
                    break;

                // if in the SecondaryWeapon menu
                case MenuMode.SecondaryWeapon:
                    break;

                // if in the Shield menu
                case MenuMode.Shield:
                    break;

                // if in the Armor menu
                case MenuMode.Armor:
                    break;

                // if in the Engine menu
                case MenuMode.Engine:

                    break;
            }
        }

        // Go to the first level
        public void ClickContinue()
        {
            SoundManager.instance.PlaySound(SoundEffect.menuSelect, GameData.menuSelectVolume);

            // check the different menus
            switch (mode)
            {
                // if in the PrimaryWeapon menu
                // update primary wepaon
                case MenuMode.PrimaryWeapon:
                    UpdateWeapon(PrimaryWeapon);
                    break;

                // if in the SecodaryWeapon menu
                // update the secondary weapon
                case MenuMode.SecondaryWeapon:
                    UpdateWeapon(SecondaryWeapon);
                    break;

                // if in the Shield menu
                case MenuMode.Shield:
                    break;
            }
            // sets the primary and secondary weapons
            PlayerData.PrimaryWeapon = PrimaryWeapon;
            PlayerData.SecondaryWeapon = SecondaryWeapon;

            // does not allow the primary and secondary weapons
            // to be doestroyed when the next level loads
            DontDestroyOnLoad(PlayerData.PrimaryWeapon);
            DontDestroyOnLoad(PlayerData.SecondaryWeapon);

            // load the level 1 scene
            Application.LoadLevel("Level1");
        }

        // Updates the weapons in the game
        protected void UpdateWeapon(Weapon weapon)
        {
            // if weapon is on single fire
            // set the FireMode to Single
            if (isSingleFire.isOn)
                weapon.FireMode = WeaponFireMode.Single;

            // if the weapon is on burst fire
            // set the FireMode to burst
            else if (isBurstFire.isOn)
                weapon.FireMode = WeaponFireMode.Burst;

            // if the weapon is on auto fire
            // set the FireMode to auto
            else if (isAutoFire.isOn)
                weapon.FireMode = WeaponFireMode.Auto;

            // sets the weapons ProjectileCount to be
            // the input from the slider projectileCount
            weapon.ProjectileCount = (int)projectileCount.value;

            // sets the weapons ProjectileSpread to be
            // the input from the slider spread
            weapon.ProjectileSpread = spread.value;

            // sets the weapons BurstFireCount to be
            // the input from the slider burstFireCount
            weapon.BurstFireCount = (int)burstFireCount.value;

            // sets the weapons CooldownTime to be
            // the input from the slider cooldown 
            weapon.CooldownTime = cooldown.value;

            // sets the weapons FireRate to be
            // the input from the slider refireRate
            weapon.FireRate = refireRate.value;
        }

        //
        protected void SaveShield()
        {

        }
    }

    // The different menu modes:
    // PrimaryWeapon, SecondaryWeapon, Shield
    public enum MenuMode
    {
        PrimaryWeapon,
        SecondaryWeapon,
        Shield,
        Armor,
        Engine
    }
}