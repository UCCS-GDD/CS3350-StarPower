using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    /// <summary>
    /// What projectile this weapon spawns
    /// </summary>
    public Projectile Projectile;

    /// <summary>
    /// How many projectiles this weapon spawns per fire
    /// </summary>
    public int ProjectileCount;

    /// <summary>
    /// How many degrees the cone of fire is
    /// </summary>
    public float ProjectileSpread;

    /// <summary>
    /// How the weapon handles attack commands
    /// </summary>
    public WeaponFireMode FireMode;

    /// <summary>
    /// How many times the weapon is fired by a single attack command, only used by Burst fire weapons
    /// </summary>
    public int BurstFireCount;

    /// <summary>
    /// The delay between fires when using Burst or Auto, unused by Single fire weapons
    /// </summary>
    public float FireRate;

    /// <summary>
    /// How long you have to wait in between attack commands, unused by Auto fire weapons
    /// </summary>
    public float CooldownTime;

    /// <summary>
    /// A multiplier that modifies the speed of the ship
    /// </summary>
    public float WeightPenalty;

    /// <summary>
    /// Indicates if a weapon is cooled down yet
    /// </summary>
    public bool ReadyToFire
    {
        get
        {
            return cooldownTimer <= 0;
        }
    }

    private bool isFiring = false;
    private int shotsFired = 0;
    private float shotTimer = 0.0f;
    private float cooldownTimer = 0.0f;

    public virtual void FireBegin()
    {
        if (cooldownTimer <= 0 && !isFiring)
            isFiring = true;
    }

    protected virtual void Update()
    {
        if (cooldownTimer >= 0)
            cooldownTimer -= Time.deltaTime;

        if (shotTimer >= 0)
            shotTimer -= Time.deltaTime;
    }

    protected virtual void FixedUpdate()
    {
        if (isFiring)
            switch (FireMode)
            {
                case WeaponFireMode.Single:
                    SpawnProjectiles();
                    isFiring = false;
                    cooldownTimer = CooldownTime;
                    break;
                case WeaponFireMode.Burst:
                    if (shotsFired >= BurstFireCount)
                    {
                        isFiring = false;
                        shotsFired = 0;
                        cooldownTimer = CooldownTime;
                        return;
                    }
                    if (shotTimer <= 0)
                    {
                        SpawnProjectiles();
                        shotsFired++;
                        shotTimer = FireRate;
                    }
                    break;
                case WeaponFireMode.Auto:
                    if (shotTimer <= 0)
                    {
                        SpawnProjectiles();
                        shotsFired++;
                        shotTimer = FireRate;
                    }
                    break;
            }
    }

    public virtual void FireEnd()
    {
        if (FireMode != WeaponFireMode.Burst)
            isFiring = false;
    }

    protected virtual void SpawnProjectiles()
    {
        for (int i = 0; i < ProjectileCount; i++)
        {
            Projectile proj = GameObject.Instantiate(Projectile, GetComponent<Transform>().position, Quaternion.identity) as Projectile;
            float weaponAngle = transform.rotation.eulerAngles.z + Random.Range(-ProjectileSpread / 2, ProjectileSpread / 2);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(weaponAngle * Mathf.Deg2Rad) * proj.velocity, Mathf.Sin(weaponAngle * Mathf.Deg2Rad) * proj.velocity);
            proj.source = transform.parent.transform.parent.gameObject;
        }
    }
}

public enum WeaponFireMode
{
    Single,
    Burst,
    Auto
}
