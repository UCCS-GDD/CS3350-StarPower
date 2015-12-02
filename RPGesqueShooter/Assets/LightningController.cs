using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningController : MonoBehaviour {

    public static List<GameObject> targets;

    public float restrikeDelay;
    public int hitsRemaining;
    public float baseDamage;
    public float damageFalloffPercent;
    public float rangeFalloffPercent;
    public float maxRange;
    public float trackingTime;

    public GameObject spherePrefab;
    
    public void Awake()
    {
        StartCoroutine(ScaleUp(trackingTime));

        targets = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Ship"))
        {
            return;
        }

        if (!targets.Contains(collider.gameObject))
        {
            //mark the enemy as hit
            targets.Add(collider.gameObject);

             //call lightning code here

             //instantiate another instance of this, which will start chaining
            Instantiate(spherePrefab, collider.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);


        }
    }

    public IEnumerator ScaleUp(float time)
    {
        // set the target scale
        Vector3 targetScale = gameObject.transform.localScale + new Vector3(maxRange, maxRange);

        // set the currentTime to 0
        float currentTime = 0.0f;        

        // execute code while currentTime is
        // less than or equal to the time
        do
        {
            // linearly interpolates between the two vectors
            // the position of the object
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, targetScale, currentTime / time);

            // increase time each frame
            currentTime += Time.deltaTime;

            // return null
            yield return null;
        } while (currentTime <= time);

        gameObject.transform.localScale = targetScale;

        //Destroy(gameObject);
    }
	
}
