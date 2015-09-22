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
        public static Weapon PrimaryWeapon;
        public static Weapon SecondaryWeapon;
        public static ShieldModule Shield;

        public Weapon DefaultPrimaryWeapon;
        public Weapon DefaultSecondaryWeapon;

        public GameObject TestShip;

        MenuMode mode = MenuMode.PrimaryWeapon;

        Toggle isSingleFire;
        Toggle isBurstFire;
        Toggle isAutoFire;
        Slider projectileCount;
        Slider spread;
        Slider burstFireCount;
        Slider cooldown;
        Slider refireRate;

        public void Awake()
        {
            if (PlayerData.PrimaryWeapon == null)
                PlayerData.PrimaryWeapon = PrimaryWeapon = Instantiate(DefaultPrimaryWeapon) as Weapon;
            else
                PrimaryWeapon = PlayerData.PrimaryWeapon;

            if (PlayerData.SecondaryWeapon == null)
                PlayerData.SecondaryWeapon = SecondaryWeapon = Instantiate(DefaultSecondaryWeapon) as Weapon;
            else
                SecondaryWeapon = PlayerData.SecondaryWeapon;

            var ship = TestShip.GetComponent<TestShip>();
            ship.PrimaryWeapon = PrimaryWeapon;
            ship.SecondaryWeapon = SecondaryWeapon;
        }

        public void Start()
        {
            var wepPanel = transform.parent.transform.FindChild("WeaponEditPanel");

            var panel = wepPanel.transform.FindChild("FireModePanel");
            isSingleFire = panel.transform.FindChild("Single").GetComponent<Toggle>();
            isBurstFire = panel.transform.FindChild("Burst").GetComponent<Toggle>();
            isAutoFire = panel.transform.FindChild("Auto").GetComponent<Toggle>();

            panel = wepPanel.transform.FindChild("ProjectileCountPanel");
            projectileCount = panel.transform.FindChild("Slider").GetComponent<Slider>();

            panel = wepPanel.transform.FindChild("SpreadPanel");
            spread = panel.transform.FindChild("Slider").GetComponent<Slider>();

            panel = wepPanel.transform.FindChild("BurstFireCountPanel");
            burstFireCount = panel.transform.FindChild("Slider").GetComponent<Slider>();

            panel = wepPanel.transform.FindChild("CooldownSpeedPanel");
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>();

            panel = wepPanel.transform.FindChild("RefireRatePanel");
            refireRate = panel.transform.FindChild("Slider").GetComponent<Slider>();
        }

        public void ClickPrimaryWeapon()
        {
            switch (mode)
            {
                case MenuMode.PrimaryWeapon:
                    break;
                case MenuMode.SecondaryWeapon:
                    UpdateWeapon(SecondaryWeapon);
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().isPrimary = true;
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().LoadWeapon(PrimaryWeapon);
                    TestShip.GetComponent<TestShip>().shouldFireSecondary = false;
                    mode = MenuMode.PrimaryWeapon;
                    break;
                case MenuMode.Shield:
                    break;
            }
        }

        public void ClickSecondaryWeapon()
        {
            switch (mode)
            {
                case MenuMode.PrimaryWeapon:
                    UpdateWeapon(PrimaryWeapon);
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().isPrimary = false;
                    transform.parent.transform.FindChild("WeaponEditPanel").GetComponent<WeaponDesignPanel>().LoadWeapon(SecondaryWeapon);
                    TestShip.GetComponent<TestShip>().shouldFireSecondary = true;
                    mode = MenuMode.SecondaryWeapon;
                    break;
                case MenuMode.SecondaryWeapon:
                    break;
                case MenuMode.Shield:
                    break;
            }
        }

        public void ClickShield()
        {
        }

        public void ClickContinue()
        {
            switch (mode)
            {
                case MenuMode.PrimaryWeapon:
                    UpdateWeapon(PrimaryWeapon);
                    break;
                case MenuMode.SecondaryWeapon:
                    UpdateWeapon(SecondaryWeapon);
                    break;
                case MenuMode.Shield:
                    break;
            }

            PlayerData.PrimaryWeapon = PrimaryWeapon;
            PlayerData.SecondaryWeapon = SecondaryWeapon;

            DontDestroyOnLoad(PlayerData.PrimaryWeapon);
            DontDestroyOnLoad(PlayerData.SecondaryWeapon);

            Application.LoadLevel("Level1");
        }

        protected void UpdateWeapon(Weapon weapon)
        {
            if (isSingleFire.isOn)
                weapon.FireMode = WeaponFireMode.Single;
            else if (isBurstFire.isOn)
                weapon.FireMode = WeaponFireMode.Burst;
            else if (isAutoFire.isOn)
                weapon.FireMode = WeaponFireMode.Auto;

            weapon.ProjectileCount = (int)projectileCount.value;
            weapon.ProjectileSpread = spread.value;
            weapon.BurstFireCount = (int)burstFireCount.value;
            weapon.CooldownTime = cooldown.value;
            weapon.FireRate = refireRate.value;
        }

        protected void SaveShield()
        {

        }
    }

    public enum MenuMode
    {
        PrimaryWeapon,
        SecondaryWeapon,
        Shield
    }
}
