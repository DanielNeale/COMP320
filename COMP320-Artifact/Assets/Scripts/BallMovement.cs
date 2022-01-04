using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public shooting gun;

    public Vector3 upperBounds;
    public Vector3 lowerBounds;

    public float minSpeed;
    public float maxSpeed;

    public Vector3 target;
    public float speed;

    private void Start()
    {
        target = new Vector3(Random.Range(upperBounds.x, lowerBounds.x),
                             Random.Range(upperBounds.y, lowerBounds.y),
                             Random.Range(upperBounds.z, lowerBounds.z));
    }

    void FixedUpdate()
    {
        speed = minSpeed + ((maxSpeed - minSpeed) * (gun.GetAccuracy() / 100));


        Vector3 direction = Vector3.Normalize(target - transform.position);

        transform.position += (direction * speed);

        if (Vector3.Distance(transform.position, target) < 0.2)
        {
            target = new Vector3(Random.Range(upperBounds.x, lowerBounds.x),
                             Random.Range(upperBounds.y, lowerBounds.y),
                             Random.Range(upperBounds.z, lowerBounds.z));
        }
    }
}
