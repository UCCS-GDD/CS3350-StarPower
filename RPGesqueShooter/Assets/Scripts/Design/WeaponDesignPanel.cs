using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class WeaponDesignPanel : MonoBehaviour
    {
        // Toggle for the different FireModes
        Toggle FireModeSingle;
        Toggle FireModeBurst;
        Toggle FireModeAuto;

        // GameObjects in which will be available for edit in the panel
        GameObject ProjectileCountPanel;
        GameObject SpreadPanel;
        GameObject BurstFireCountPanel;
        GameObject CooldownSpeedPanel;
        GameObject RefireRatePanel;

        // bool for priamry weapon
        public bool isPrimary = true;

        // TestShip to show the player what their ship will be like
        public GameObject TestShip;

        // Use this for initialization
        public void Start()
        {
            // gets the FireModePanel
            var FireModePanel = transform.FindChild("FireModePanel").gameObject;

            // Gets the Toggle components of the fire modes
            FireModeSingle = FireModePanel.transform.FindChild("Single").gameObject.GetComponent<Toggle>();
            FireModeBurst = FireModePanel.transform.FindChild("Burst").gameObject.GetComponent<Toggle>();
            FireModeAuto = FireModePanel.transform.FindChild("Auto").gameObject.GetComponent<Toggle>();

            // Gets the components for ProjectileCountPanel, SpreadPanel, BurstFireCountPanel, CooldownSpeedPanel, RefireRatePanel
            ProjectileCountPanel = transform.FindChild("ProjectileCountPanel").gameObject;
            SpreadPanel = transform.FindChild("SpreadPanel").gameObject;
            BurstFireCountPanel = transform.FindChild("BurstFireCountPanel").gameObject;
            CooldownSpeedPanel = transform.FindChild("CooldownSpeedPanel").gameObject;
            RefireRatePanel = transform.FindChild("RefireRatePanel").gameObject;

            // gets the components of the panel and changes the values
            ProjectileCountPanel.GetComponent<SliderInputPanel>().OnValueChanged += ProjectileCountChanged;
            SpreadPanel.GetComponent<SliderInputPanel>().OnValueChanged += SpreadChanged;
            BurstFireCountPanel.GetComponent<SliderInputPanel>().OnValueChanged += BurstFireCountChanged;
            CooldownSpeedPanel.GetComponent<SliderInputPanel>().OnValueChanged += CooldownSpeedChanged;
            RefireRatePanel.GetComponent<SliderInputPanel>().OnValueChanged += RefireRateChanged;

            // Loads the primary weapon
            LoadWeapon(PlayerData.PrimaryWeapon);
        }

        // Load the specified weapon
        public void LoadWeapon(Weapon weapon)
        {
            // Variable for slider input
            SliderInputPanel panel;

            // get the ProjectileCount panel
            // set the slider value to the weapons ProjectileCount
            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.ProjectileCount;

            // get the BurstFireCount panel
            // set the slider value to th weapons BurstFireCount
            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.BurstFireCount;

            // get the RefireRate panel
            // set the slider value to the weapon FireRate
            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.FireRate;

            // get the CooldownSpeed panel 
            // set the slider value to the weapon cooldownTime
            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.CooldownTime;

            // check between the different fire modes
            switch (weapon.FireMode)
            {
                // if fire mode is single
                case WeaponFireMode.Single:
                    // set weapon fire mode single to true
                    // everything else is set to false
                    FireModeSingle.isOn = true;
                    FireModeBurst.isOn = false;
                    FireModeAuto.isOn = false;
                    break;
                // if fire mode is burst
                case WeaponFireMode.Burst:
                    // set weapon fire mode burst to true
                    // everything else is set to false
                    FireModeSingle.isOn = false;
                    FireModeBurst.isOn = true;
                    FireModeAuto.isOn = false;
                    break;
                // if fire mode is auto
                case WeaponFireMode.Auto:
                    // set fire mode auto to true
                    // everything else is set to false
                    FireModeSingle.isOn = false;
                    FireModeBurst.isOn = false;
                    FireModeAuto.isOn = true;
                    break;
            }
            // get the SliderInput panel components
            panel = SpreadPanel.GetComponent<SliderInputPanel>();

            // set the value of the slider to the weapon ProjectileSpread
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.ProjectileSpread;
        }

        // When the fire mode of the weapon is changed
        public void OnFireModeChanged()
        {
            // if fire mode is single
            if (FireModeSingle.isOn)
            {
                // set BurstFireCount slider interactable to false
                // set BurstFireCount InputField interactable to false
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                // set CooldownSpeed slder interactable to true
                // set CooldownSpeed InputField interactable to true
                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                // set the RefireRate slider interactable to false
                // set the RefireRate InputField interactable to false
                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;
            }
            // if fire mode is burst
            else if (FireModeBurst.isOn)
            {
                // set BurstFireCount slider interactable to true
                // set BurstFireCount InputField interactable to true
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                // set CooldownSpeed slder interactable to true
                // set CooldownSpeed InputField interactable to true
                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                // set the RefireRate slider interactable to true
                // set the RefireRate InputField interactable to true
                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;
            }
            // if fire mode is auto
            else if (FireModeAuto.isOn)
            {
                // set BurstFireCount slider interactable to false
                // set BurstFireCount InputField interactable to false
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                // set CooldownSpeed slder interactable to false
                // set CooldownSpeed InputField interactable to flase
                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                // set the RefireRate slider interactable to true
                // set the RefireRate InputField interactable to true
                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;
            }
            // update the spread of the weapon
            UpdateSpread();
        }

        // When the Projectile Count has changed
        public void ProjectileCountChanged(float newValue)
        {
            // update the spread of the weapon
            UpdateSpread();
        }

        // When the spread of the weapon has changed
        public void SpreadChanged(float newValue)
        {
            // Variable for slider input
            SliderInputPanel panel;

            // Variables for weapon
            float projCount;
            float burstCount;
            float cooldown;
            float refire;

            // weapon FireMode set to single
            WeaponFireMode mode = WeaponFireMode.Single;

            // get the ProjectileCount panel input
            // set the Slider panel value to projCount
            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            projCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the BurstFireCount panel input
            // set the Slider panel value to burstCount
            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            burstCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the RefireRate panel input
            // set the Slider panel value to refire
            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            refire = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the CooldownSpeed panel input
            // set the Slider panel value to cooldown
            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // if fire mode is single
            // set fire mode
            if (FireModeSingle.isOn)
            {
                mode = WeaponFireMode.Single;
            }
            // if fire mode is burst
                // set fire mode
            else if (FireModeBurst.isOn)
            {
                mode = WeaponFireMode.Burst;
            }
            // if fire mdoe is auto
                // set fire mode
            else if (FireModeAuto.isOn)
            {
                mode = WeaponFireMode.Auto;
            }
            // Updates the test ship with the given paramaters
            UpdateTestShip(isPrimary, projCount, Mathf.Round(newValue), mode, cooldown, refire, burstCount);
        }

        // Burst fire count changes according to new value
        public void BurstFireCountChanged(float newValue)
        {
            UpdateSpread();
        }

        // Cooldown Speed changes according to new value
        public void CooldownSpeedChanged(float newValue)
        {
            UpdateSpread();
        }

        // Refire Rate changes according to new value
        public void RefireRateChanged(float newValue)
        {
            UpdateSpread();
        }

        // Update the spread of the weapon
        public void UpdateSpread()
        {
            // Variable for slider input
            SliderInputPanel panel;

            // Variables for weapon
            float projCount;
            float burstCount;
            float cooldown;
            float refire;

            // weapon FireMode set to single
            WeaponFireMode mode = WeaponFireMode.Single;

            // Variable for change
            float newValue = 0;

            // get the ProjectileCount panel input
            // set the Slider panel value to projCount
            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            projCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the BurstFireCount panel input
            // set the Slider panel value to burstCount
            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            burstCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the RefireRate panel input
            // set the Slider panel value to refire
            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            refire = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // get the CooldownSpeed panel input
            // set the Slider panel value to cooldown
            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // if fire mode is single
            if (FireModeSingle.isOn)
            {
                // set new value
                newValue = projCount + (.25f * projCount * (1 / cooldown));

                // set weapon fire mode
                mode = WeaponFireMode.Single;
            }
            // if fire mode is burst
            else if (FireModeBurst.isOn)
            {
                // variable for RefireRate
                float avgRefire = ((burstCount - 1) * refire + cooldown) / burstCount;

                // set new value
                newValue = projCount + (.50f * projCount * (1 / avgRefire));

                // set weapon fire mode
                mode = WeaponFireMode.Burst;
            }
            // if fire mode is auto
            else if (FireModeAuto.isOn)
            {
                // set new value
                newValue = projCount + (.75f * projCount * (1 / refire));

                // set weapon fire mode
                mode = WeaponFireMode.Auto;
            }
            // get the SliderInputPanel components
            panel = SpreadPanel.GetComponent<SliderInputPanel>();

            // Updates range for panel
            panel.UpdateRange(Mathf.Round(newValue), panel.Max);

            // Updates the test ship with the given paramaters
            UpdateTestShip(isPrimary, projCount, Mathf.Round(panel.transform.FindChild("Slider").GetComponent<Slider>().value), mode, cooldown, refire, burstCount);
        }

        // Update Test Ship
        // This allows the player to see what their ship will do in combat
        public void UpdateTestShip(bool updatePrimary, float projCount, float spread, WeaponFireMode mode, float cooldown, float refire, float burstCount)
        {
            TestShip.GetComponent<TestShip>().UpdateWeapons(updatePrimary, projCount, spread, mode, cooldown, refire, burstCount);

            var button = transform.parent.FindChild("NavPanel").FindChild("PlayGame_Button").GetComponent<Button>();
            button.interactable = Credits.instance.currentValue - Credits.instance.oldValue <= Credits.instance.currentCredits;
        }
    }
}