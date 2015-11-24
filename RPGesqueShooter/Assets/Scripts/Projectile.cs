using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour 
{
    // Variables for projectile
    public float velocity;
    public float damage;

    // GameObject variable for source object
    public GameObject source;
   
    // get the shiptype in an enum
    public ShipType type;

	// Use this for initialization
	void Start () 
    {
	    SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (type == ShipType.Enemy)
        {
            renderer.color = new Color(1, 0, 0, 1);
        }
        else
        {
            renderer.color = new Color(0, 0, 1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        // if object is off of the screen
	    if (transform.position.y < -5 || transform.position.y > 5)
        {
            // destroy object
            Destroy(gameObject);
        }
	}

    // Called when the renderer is no longer visible by any camera
    void OnBecameInvisible()
    {
        // destroy object
        Destroy(gameObject);
    }

    // Applies damage to specified GameObject
    public abstract void ApplyDamageTo(GameObject target);
}