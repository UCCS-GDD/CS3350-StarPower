using UnityEngine;
using System.Collections;

public class BossScript : Ship
{
    // Use this for initialization
    void Start()
    {

    }

    // Used to inititalize any variables or game state before the game starts
    public void Awake()
    {
        // set max health 
        this.MaxHP = GameData.defaultBossHealth;

        // set current health
        this.CurrentHP = this.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called every fixed framerate frame
    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.05f), speed);
    }
}