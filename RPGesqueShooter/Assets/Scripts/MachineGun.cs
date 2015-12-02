using UnityEngine;
using System.Collections;

public class MachineGun : Weapon {

    protected override void SpawnProjectiles()
    {
        //
        for (int i = 0; i < ProjectileCount; i++)
        {
            // set proj to instanstiate bullet as Projectile
            Projectile proj = GameObject.Instantiate(Projectile, GetComponent<Transform>().position, Quaternion.identity) as Projectile;

            // set weaponAngle to a random range based on ProjectileSpread
            float weaponAngle = (float)(Turret.trajectory.z - .5 * Mathf.PI);

            // gets the RigidBody2D components to a new vector
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(weaponAngle) * proj.velocity, Mathf.Sin(weaponAngle) * proj.velocity);
            
            // set the source of the proj to the parent gameObject
            proj.source = transform.parent.transform.parent.gameObject;
            proj.type = transform.parent.transform.parent.gameObject.GetComponent<Ship>().type;
            
            // play laser sound effect 
            SoundManager.instance.PlaySound(SoundEffect.laser, GameData.laserVolume);
        }
    }
}
