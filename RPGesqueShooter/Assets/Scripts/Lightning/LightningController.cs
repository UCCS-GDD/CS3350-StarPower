using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningController : MonoBehaviour {

    public static List<int> targets;

    public float restrikeDelay;
    public int hitsRemaining;
    public float baseDamage;
    public float damageFalloffPercent;
    public float rangeFalloffPercent;
    public float maxRange;
    public float trackingTime;

	public GameObject sourceObject;

    public GameObject spherePrefab;
    
    public void Awake()
    {
        StartCoroutine(ScaleUp(trackingTime));

		if (targets == null)
        	targets = new List<int>();

		Debug.Log ("Spawn");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Ship"))
        {
            return;
        } 

        if (!targets.Contains(collider.gameObject.GetInstanceID()))
        {
            //mark the enemy as hit
			targets.Add(collider.gameObject.GetInstanceID());

			sourceObject = collider.gameObject;

            //call lightning code here

			collider.gameObject.GetComponent<Ship>().CurrentHP -= baseDamage;

            //instantiate another instance of this, which will start chaining
            var bubble = Instantiate(spherePrefab, collider.transform.position, Quaternion.identity) as GameObject;
			bubble.gameObject.transform.localScale = new Vector3(.2f, .2f, 1);
            //Destroy(gameObject);
        }
    }

	public void Update()
	{
		if (sourceObject != null) 
		{
			gameObject.transform.position = sourceObject.transform.position;
		}
	}

    public IEnumerator ScaleUp(float time)
    {
        // set the target scale
        Vector3 targetScale = this.gameObject.transform.localScale + new Vector3(maxRange, maxRange);

        // set the currentTime to 0
        float currentTime = 0.0f;        

        // execute code while currentTime is
        // less than or equal to the time
        do
        {
            // linearly interpolates between the two vectors
            gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, targetScale, currentTime / time);

            // increase time each frame
            currentTime += Time.deltaTime;

            // return null
			yield return null;
        } while (currentTime <= time);

        this.gameObject.transform.localScale = targetScale;

		Destroy (gameObject);
    }
	
}
