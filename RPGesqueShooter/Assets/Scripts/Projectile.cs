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
	
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public abstract void ApplyDamageTo(GameObject target);
}