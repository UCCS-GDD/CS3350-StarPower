using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    // What projectile this weapon spawns
    public Projectile Projectile;

    // How many projectiles this weapon spawns per fire
    public int ProjectileCount;

    // How many degrees the cone of fire is
    public float ProjectileSpread;

    // How the weapon handles attack commands
    public WeaponFireMode FireMode;

    // How many times the weapon is fired by a single attack command, only used by Burst fire weapons
    public int BurstFireCount;

    // The delay between fires when using Burst or Auto, unused by Single fire weapons
    public float FireRate;

    // How long you have to wait in between attack commands, unused by Auto fire weapons
    public float CooldownTime;

    // A multiplier that modifies the speed of the ship
    public float WeightPenalty;

    // Indicates if a weapon is cooled down yet
    public bool ReadyToFire
    {
        // get the cooldownTimer
        // return
        get
        {
            return cooldownTimer <= 0;
        }
    }

	public float ShotDelay
	{
		set { shotTimer = value; }
	}

    // Whether or not weapon is firing
    private bool isFiring = false;

    // How many shots are fired from weapon
    private int shotsFired = 0;

    // How many shots have been shot
    private float shotTimer = 0.0f;

    // How long the cool down time is
    private float cooldownTimer = 0.0f;

    // Weapon is firing
    public virtual void FireBegin()
    {
        // if cooldownTimer is less tha or equal to 0
        // and not firing
        if (cooldownTimer <= 0 && !isFiring)
            // set isFiring to true
            isFiring = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // if cooldownTimer is greater or equal to zero
        // set cooldownTimer to negative deltaTime
        if (cooldownTimer >= 0)
            cooldownTimer -= Time.deltaTime;

        // if shotTimer is greater or equal to 0
        // set shotTimer to negative deltaTime
        if (shotTimer >= 0)
            shotTimer -= Time.deltaTime;
    }

    // Called every fixed framerate frame
    protected virtual void FixedUpdate()
    {
        // if weapon is firing
        if (isFiring)
            // check each fire mode
            switch (FireMode)
            {
                    // if FireMode is single,
                    // spawn prjectiles, set isFiring, set cooldownTimer
                case WeaponFireMode.Single:
                    SpawnProjectiles();
                    isFiring = false;
                    cooldownTimer = CooldownTime;
                    break;
                    // if FireMode is burst,
                case WeaponFireMode.Burst:
                    // if shotsFired is greater or equal to BurstFireCount
                    // set isFiring, set shotsFired, set cooldownTimer
                    if (shotsFired >= BurstFireCount)
                    {
                        isFiring = false;
                        shotsFired = 0;
                        cooldownTimer = CooldownTime;
                        return;
                    }
                    // if shotTimer is less than or equal to 0
                    // spawn projectiles, add +1 to shotsFired, set shotTimer
                    if (shotTimer <= 0)
                    {
                        SpawnProjectiles();
                        shotsFired++;
                        shotTimer = FireRate;
                    }
                    break;
                    // if FireMode is auto
                case WeaponFireMode.Auto:
                    // if shotTimer is less than or equal to zero
                    // spawn projectiles, add +1 to the shotsFired, set shotTimer
                    if (shotTimer <= 0)
                    {
                        SpawnProjectiles();
                        shotsFired++;
                        shotTimer = FireRate;
                    }
                    break;
            }
    }

    // Weapon is not firing
    public virtual void FireEnd()
    {
        // if FireMode is not burst fire mode
        // set isFiring to false
        if (FireMode != WeaponFireMode.Burst)
            isFiring = false;
    }

    // Spawns the bullets 
    protected virtual void SpawnProjectiles()
    {
        //
        for (int i = 0; i < ProjectileCount; i++)
        {
            // set proj to instanstiate bullet as Projectile
            Projectile proj = GameObject.Instantiate(Projectile, GetComponent<Transform>().position, Quaternion.identity) as Projectile;

            // set weaponAngle to a random range based on ProjectileSpread
            float weaponAngle = transform.rotation.eulerAngles.z + ((-ProjectileSpread / 2) + (ProjectileSpread / (ProjectileCount - 1)) * i);

            // 
            if (ProjectileCount == 1) 
            {
                weaponAngle = transform.rotation.eulerAngles.z;
            }

            // gets the RigidBody2D components to a new vector
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(weaponAngle * Mathf.Deg2Rad) * proj.velocity, Mathf.Sin(weaponAngle * Mathf.Deg2Rad) * proj.velocity);
            
            // set the source of the proj to the parent gameObject
            proj.source = transform.parent.transform.parent.gameObject;
            proj.type = transform.parent.transform.parent.gameObject.GetComponent<Ship>().type;
            
            // play laser sound effect 
            SoundManager.instance.PlaySound(SoundEffect.laser, GameData.laserVolume);
        }
    }
}

// Enumeration for the different fire modes of Weapon
public enum WeaponFireMode
{
    Single,
    Burst,
    Auto
}