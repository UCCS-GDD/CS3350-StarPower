using UnityEngine;
using System.Collections;

public class TurretMovement : MonoBehaviour
{
    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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