using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour 
{
    public float velocity;
    public float damage;

    public GameObject source;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (transform.position.y < -5 || transform.position.y > 5)
        {
            Destroy(gameObject);
        }
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public abstract void ApplyDamageTo(GameObject target);
}