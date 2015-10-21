using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts
{
    public class HandGunDesignPanel : MonoBehaviour
    {
        // Variables for fire mode for weapon
        Toggle FireModeSingle;
        Toggle FireModeBurst;
        Toggle FireModeAuto;

        // GameObjects for gun
        GameObject RefireRate;
        GameObject ReloadSpeed;
        GameObject ClipSize;
        GameObject AmmoType;

        // TestWeapon to show player what their weapon will look like
        public GameObject TestWeapon;

        // Use this for initialization
        void Start()
        {
            // find the FireModePanel
            var FireModePanel = transform.FindChild("FireModePanel").gameObject;

            // Gets the components for fire mode
            FireModeAuto = FireModePanel.transform.FindChild("Single").gameObject.GetComponent<Toggle>();
            FireModeBurst = FireModePanel.transform.FindChild("Burst").gameObject.GetComponent<Toggle>();
            FireModeAuto = FireModePanel.transform.FindChild("Auto").gameObject.GetComponent<Toggle>();

            // Gets the components for RefireRate, ReloadSpeed, and ClipSize
            RefireRate = FireModePanel.transform.FindChild("FireRate").gameObject;
            ReloadSpeed = FireModePanel.transform.FindChild("ReloadSpeed").gameObject;
            ClipSize = FireModePanel.transform.FindChild("ClipSize").gameObject;

            // Sets the RefireRate based on how the user changes it
            //RefireRate.GetComponent<SliderInputPanel>().OnValueChanged +=;
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Changes the burst fire count
        public void BurstFireCountChanged(float newValue)
        {
            UpdateGun();
        }

        // Changes the refire rate
        public void RefireRateChanged(float newValue)
        {
            UpdateGun();
        }

        // Changes the reload speed
        public void ReloadSpeedChanged(float newValue)
        {
            UpdateGun();
        }

        // Changes the clip size
        public void ClipSizeChanged(float newValue)
        {
            UpdateGun();
        }

        // Updates the gun 
        public void UpdateGun()
        {
            // Variables for slider input
            SliderInputPanel panel;

            // Variables for gun
            float refireRate;
            float reloadSpeed;
            float clipSize;

            // Fire mode for weapon 
            WeaponFireMode mode = WeaponFireMode.Single;

            // Variable for change
            float newValue = 0;

            // gets the RefireRate panel
            //
            panel = RefireRate.GetComponent<SliderInputPanel>();
            refireRate = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // gets the ReloadSpeed
            // 
            panel = ReloadSpeed.GetComponent<SliderInputPanel>();
            reloadSpeed = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            // gets the ClipSize
            //
            panel = ClipSize.GetComponent<SliderInputPanel>();
            clipSize = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            //
            panel.UpdateRange(Mathf.Round(newValue), panel.Max);

            //
            UpdateTestWeapon(refireRate, reloadSpeed, mode, clipSize);
        }

        // 
        public void UpdateTestWeapon(float refireRate, float reloadSpeed, WeaponFireMode mode, float clipSize)
        {
            //TestWeapon.GetComponent<TestWeapon>().UpdateGun(refireRate, reloadSpeed, mode, clipSize);
        }
    }
}