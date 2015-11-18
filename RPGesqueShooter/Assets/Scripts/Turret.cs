using UnityEngine;
using System.Collections;

public class Turret : Ship
{
    // variable for target object
    public Transform target;

    // variable for sprite renderer
    SpriteRenderer renderer;

    // variables for the sprites to be used at certain health
    public Sprite fullHealth;
    public Sprite reducedHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;

    public void Awake()
    {
        // set max health
        this.MaxHP = GameData.defaultBossHealth;

        // set current health
        this.CurrentHP = this.MaxHP;

        // get the sprite renderer of this object
        renderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        // apply the correct sprite based on the current health
        if (CurrentHP > (MaxHP * .75f))
        {
            renderer.sprite = fullHealth;
        }
        else if (CurrentHP <= (MaxHP * .75f) && CurrentHP > (MaxHP * .5f))
        {
            renderer.sprite = reducedHealth;
            //isSmoking = true;
        }
        else if (CurrentHP <= (MaxHP * .5f) && CurrentHP > (MaxHP * .25f))
        {
            renderer.sprite = halfHealth;
            //isOnFire = true;
        }
        else if (CurrentHP <= (MaxHP * .25))
        {
            renderer.sprite = lowHealth;
        }

        // Calls the parent method
        base.Update();

        // direction of target
        var dir = target.position - transform.position;

        // get the angle
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // makes sure its facing the right direction
        angle = angle + 90;

        // set the rotation to the angle found
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}