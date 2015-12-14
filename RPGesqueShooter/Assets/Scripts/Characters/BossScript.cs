using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum BossState
{
    FullHealth,
    ReducedHealth,
    HalfHealth,
    LowHealth
}

public class BossScript : Ship
{
    // variable for if the object is active or not
    bool isActive = false;

    // variable for current state of the boss
    public BossState currentState = BossState.FullHealth;

    // variable for sprite renderer
    SpriteRenderer spriteRenderer;
	SpriteRenderer spriteRendererTurret0;
	SpriteRenderer spriteRendererTurret1;

    // variables for the sprites to be used at certain health
    public Sprite fullHealth;
    public Sprite reducedHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;

	// prefab for warp particle system
	public GameObject warpParticle;

	// objects for the turrets
	public GameObject turret0;
	public GameObject turret1;

    // health bar prefab
    public CanvasGroup healthBarSystem;
    Image healthBar;

    // int variable for the phase of the game
    int phase = 0;

    // int variable for timer of game
    int timer = 0;

	// this objects collider
	Collider2D collider;

    // Used to inititalize any variables or game state before the game starts
    public void Awake()
    {
        // set max health 
        this.MaxHP = GameData.defaultBossHealth;

        // set current health of the boss
        this.CurrentHP = this.MaxHP;

		// get turret children
		turret0 = transform.GetChild (0).gameObject;
		turret1 = transform.GetChild (1).gameObject;

        // get the sprite renderer of this object
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRendererTurret0 = turret0.GetComponent<SpriteRenderer>();
		spriteRendererTurret1 = turret1.GetComponent<SpriteRenderer>();

        // set the ship type of the boss
        type = ShipType.Enemy;

        // if the ship is smoking
        isSmoking = false;

        speed = GameData.defaultBossMoveSpeed;

		// set color
		spriteRenderer.color = new Color (.5f, 0, 0, 0);

		// set the weapons cold
		foreach (Weapon wep in primaryWeapons) 
		{
			wep.ShotDelay = 4f;
			Debug.Log(wep);
		}

		// create portal particle system
		var warp = Instantiate (warpParticle);
		warp.transform.position = new Vector3 (0, 1.2f, 0);

        // setup healthbar system
        healthBarSystem = GameObject.FindGameObjectWithTag("BossHealthContainer").GetComponent<CanvasGroup>();
        healthBar = GameObject.FindGameObjectWithTag("BossHealthFill").GetComponent<Image>();

		collider = GetComponent<Collider2D> ();
		collider.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
		StartCoroutine (FadeIn (4f));

        if (healthBar != null)
        {
            healthBar.fillAmount = CurrentHP / MaxHP;
        }

        // apply the correct sprite based on the current health
        if (CurrentHP > (MaxHP * .75f))
        {
			spriteRenderer.sprite = fullHealth;
            currentState = BossState.FullHealth;
        }
        else if (CurrentHP <= (MaxHP * .75f) && CurrentHP > (MaxHP * .5f))
        {
			spriteRenderer.sprite = reducedHealth;
            currentState = BossState.ReducedHealth;
            //isSmoking = true;
        }
        else if (CurrentHP <= (MaxHP * .5f) && CurrentHP > (MaxHP * .25f))
        {
			spriteRenderer.sprite = halfHealth;
            currentState = BossState.HalfHealth;
            //isOnFire = true;
        }
        else if (CurrentHP <= (MaxHP * .25))
        {
			spriteRenderer.sprite = lowHealth;
            currentState = BossState.LowHealth;
        }
        else if (CurrentHP <= 0)
        {
            Application.LoadLevel("GameOver");
        }
        // Calls the parent method
        base.Update();

        // if active
        // Check each weapon in the list of primary weapons
        if (isActive)
            foreach (var weapon in primaryWeapons)
            {
                // if the weapon can fire
                // fire weapon
                if (weapon.ReadyToFire)
                    weapon.FireBegin();
                // if the weapon cannot fire
                // stop firing weapon
                else
                    weapon.FireEnd();
            }

        //  if object is within certain distance of player
        // check the phases of the game
        switch (phase)
        {
            // linearly interpolates between the two vectors
            // the position of the object
            case 0:
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -.0125f), speed);
                break;
            // linearly interpolates between the two vectors
            // the position of the object
            case 1:
                transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                break;
            // linearly interpolates between the two vectors
            // the position of the object
            case 2:
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-.05f, 0), speed);
                break;
            // linearly interpolates between the two vectors
            // the position of the object
            case 3:
                transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                break;
            case 4:
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(.1f, 0), speed);
                break;
            // default case
            case 5:
                transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                break;
            case 6:
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-.1f, 0), speed); break;
            case 7:
                transform.position = Vector3.Lerp(transform.position, transform.position, speed);
                break;
            default:
                break;
        }

        // if the timer is greater than 50
        if (timer > 100)
        {
            // if it is in the third phase
            // set phase to 0
            if (phase == 7)
            {
                phase = 4;
            }
            // if it is in a different phase
            // increase the phase
            else
            {
                phase++;
            }
            // set timer to 0
            timer = 0;
        }
        // if the timer is less than 50
        // increase the timer
        else
        {
            timer++;
        }
    }

    // Called every fixed framerate frame
    public void FixedUpdate()
    {
        // clamps the boss within the window
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.0f), Mathf.Clamp(transform.position.y, 1.0f, 4.0f));
    }

    // Called when the renderer became visible by any camera
    public void OnBecameVisible()
    {
        isActive = true;
    }

	IEnumerator FadeIn(float colortimer)
	{
		float current = 0f;

		do {
			spriteRendererTurret0.color = Color.Lerp (new Color (.5f, 0, 0, 0), new Color (1, 1, 1, 1), current / colortimer);
			spriteRendererTurret1.color = Color.Lerp (new Color (.5f, 0, 0, 0), new Color (1, 1, 1, 1), current / colortimer);
			spriteRenderer.color = Color.Lerp (new Color (.5f, 0, 0, 0), new Color (1, 1, 1, 1), current / colortimer);
            healthBarSystem.alpha = Mathf.Lerp(0, 1, current / colortimer);
			current += Time.deltaTime;

			yield return null;
		} while (current <= colortimer);

		collider.enabled = true;
	}
}