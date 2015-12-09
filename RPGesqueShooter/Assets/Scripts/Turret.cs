using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    // set a trajectory
    public static Quaternion trajectory;
    
    // variable for target object
    public Transform target;

    // variable for sprite renderer
    SpriteRenderer spriteRenderer;

    // variables for the sprites to be used at certain health
    public Sprite fullHealth;
    public Sprite reducedHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;

    public BossScript parent;

    private BossState parentState;

    public void Awake()
    {
       // get the sprite renderer of this object
		spriteRenderer = GetComponent<SpriteRenderer>();
        parentState = parent.currentState;

        target = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        // apply the correct sprite based on the current health
        if (parentState == BossState.FullHealth)
        {
			spriteRenderer.sprite = fullHealth;
        }
        else if (parentState == BossState.ReducedHealth)
        {
			spriteRenderer.sprite = reducedHealth;
            //isSmoking = true;
        }
        else if (parentState == BossState.HalfHealth)
        {
			spriteRenderer.sprite = halfHealth;
            //isOnFire = true;
        }
        else if (parentState == BossState.LowHealth)
        {
			spriteRenderer.sprite = lowHealth;
        }

        // Calls the parent method
        //base.Update();

        // direction of target
        var dir = target.position - transform.position;

        // get the angle
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // makes sure its facing the right direction
        angle = angle + 90;

        // set the rotation to the angle found
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        trajectory = transform.rotation;

        //get the parents state
        parentState = parent.currentState;
    }
}