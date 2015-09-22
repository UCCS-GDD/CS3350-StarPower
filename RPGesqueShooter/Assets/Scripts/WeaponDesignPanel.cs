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
        Toggle FireModeSingle;
        Toggle FireModeBurst;
        Toggle FireModeAuto;
        GameObject ProjectileCountPanel;
        GameObject SpreadPanel;
        GameObject BurstFireCountPanel;
        GameObject CooldownSpeedPanel;
        GameObject RefireRatePanel;

        public bool isPrimary = true;

        public GameObject TestShip;

        public void Start()
        {
            var FireModePanel = transform.FindChild("FireModePanel").gameObject;
            FireModeSingle = FireModePanel.transform.FindChild("Single").gameObject.GetComponent<Toggle>();
            FireModeBurst = FireModePanel.transform.FindChild("Burst").gameObject.GetComponent<Toggle>();
            FireModeAuto = FireModePanel.transform.FindChild("Auto").gameObject.GetComponent<Toggle>();
            ProjectileCountPanel = transform.FindChild("ProjectileCountPanel").gameObject;
            SpreadPanel = transform.FindChild("SpreadPanel").gameObject;
            BurstFireCountPanel = transform.FindChild("BurstFireCountPanel").gameObject;
            CooldownSpeedPanel = transform.FindChild("CooldownSpeedPanel").gameObject;
            RefireRatePanel = transform.FindChild("RefireRatePanel").gameObject;

            ProjectileCountPanel.GetComponent<SliderInputPanel>().OnValueChanged += ProjectileCountChanged;
            SpreadPanel.GetComponent<SliderInputPanel>().OnValueChanged += SpreadChanged;
            BurstFireCountPanel.GetComponent<SliderInputPanel>().OnValueChanged += BurstFireCountChanged;
            CooldownSpeedPanel.GetComponent<SliderInputPanel>().OnValueChanged += CooldownSpeedChanged;
            RefireRatePanel.GetComponent<SliderInputPanel>().OnValueChanged += RefireRateChanged;

            LoadWeapon(PlayerData.PrimaryWeapon);
        }

        public void LoadWeapon(Weapon weapon)
        {
            SliderInputPanel panel;

            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.ProjectileCount;

            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.BurstFireCount;

            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.FireRate;

            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.CooldownTime;

            switch (weapon.FireMode)
            {
                case WeaponFireMode.Single:
                    FireModeSingle.isOn = true;
                    FireModeBurst.isOn = false;
                    FireModeAuto.isOn = false;
                    break;
                case WeaponFireMode.Burst:
                    FireModeSingle.isOn = false;
                    FireModeBurst.isOn = true;
                    FireModeAuto.isOn = false;
                    break;
                case WeaponFireMode.Auto:
                    FireModeSingle.isOn = false;
                    FireModeBurst.isOn = false;
                    FireModeAuto.isOn = true;
                    break;
            }

            panel = SpreadPanel.GetComponent<SliderInputPanel>();
            panel.transform.FindChild("Slider").GetComponent<Slider>().value = weapon.ProjectileSpread;
        }
  
        public void OnFireModeChanged()
        {
            if (FireModeSingle.isOn)
            {
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;
            }
            else if (FireModeBurst.isOn)
            {
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;

                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;
            }
            else if (FireModeAuto.isOn)
            {
                BurstFireCountPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                BurstFireCountPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                CooldownSpeedPanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = false;
                CooldownSpeedPanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = false;

                RefireRatePanel.transform.FindChild("Slider").gameObject.GetComponent<Slider>().interactable = true;
                RefireRatePanel.transform.FindChild("InputField").gameObject.GetComponent<InputField>().interactable = true;
            }

            UpdateSpread();
        }

        public void ProjectileCountChanged(float newValue)
        {
            UpdateSpread();
        }

        public void SpreadChanged(float newValue)
        {
            SliderInputPanel panel;

            float projCount;
            float burstCount;
            float cooldown;
            float refire;
            WeaponFireMode mode = WeaponFireMode.Single;

            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            projCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            burstCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            refire = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            if (FireModeSingle.isOn)
            {
                mode = WeaponFireMode.Single;
            }
            else if (FireModeBurst.isOn)
            {
                mode = WeaponFireMode.Burst;
            }
            else if (FireModeAuto.isOn)
            {
                mode = WeaponFireMode.Auto;
            }

            UpdateTestShip(isPrimary, projCount, Mathf.Round(newValue), mode, cooldown, refire, burstCount);
        }

        public void BurstFireCountChanged(float newValue)
        {
            UpdateSpread();
        }

        public void CooldownSpeedChanged(float newValue)
        {
            UpdateSpread();
        }

        public void RefireRateChanged(float newValue)
        {
            UpdateSpread();
        }

        public void UpdateSpread()
        {
            SliderInputPanel panel;

            float projCount;
            float burstCount;
            float cooldown;
            float refire;
            WeaponFireMode mode = WeaponFireMode.Single;

            float newValue = 0;

            panel = ProjectileCountPanel.GetComponent<SliderInputPanel>();
            projCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = BurstFireCountPanel.GetComponent<SliderInputPanel>();
            burstCount = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = RefireRatePanel.GetComponent<SliderInputPanel>();
            refire = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            panel = CooldownSpeedPanel.GetComponent<SliderInputPanel>();
            cooldown = panel.transform.FindChild("Slider").GetComponent<Slider>().value;

            if (FireModeSingle.isOn)
            {
                newValue = projCount + (.25f * projCount * (1 / cooldown));
                mode = WeaponFireMode.Single;
            }
            else if (FireModeBurst.isOn)
            {
                float avgRefire = ((burstCount - 1) * refire + cooldown) / burstCount;
                newValue = projCount + (.50f * projCount * (1 / avgRefire));
                mode = WeaponFireMode.Burst;
            }
            else if (FireModeAuto.isOn)
            {
                newValue = projCount + (.75f * projCount * (1 / refire));
                mode = WeaponFireMode.Auto;
            }

            panel = SpreadPanel.GetComponent<SliderInputPanel>();
            panel.UpdateRange(Mathf.Round(newValue), panel.Max);

            UpdateTestShip(isPrimary, projCount, Mathf.Round(panel.transform.FindChild("Slider").GetComponent<Slider>().value), mode, cooldown, refire, burstCount);
        }

        public void UpdateTestShip(bool updatePrimary, float projCount, float spread, WeaponFireMode mode, float cooldown, float refire, float burstCount)
        {
            TestShip.GetComponent<TestShip>().UpdateWeapons(updatePrimary, projCount, spread, mode, cooldown, refire, burstCount);
        }
    }
}
