using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Shooting gun;

    [SerializeField]
    private Transform body;
    [SerializeField]
    private Transform coverPoint;
    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private Vector2 moveSpeeds;
    private float moveSpeed;

    [SerializeField]
    private Vector2 visableTime;
    [SerializeField]
    private float visableTimerVarience = 0.5f;
    private float visableTimer;
    
    private bool inCover = true;


    private void Update()
    {
        if (visableTimer < 0)
        {
            inCover = !inCover;

            
            visableTimer += Random.Range(-visableTimerVarience, visableTimerVarience);
        }
    }


    private void FixedUpdate()
    {
        if (inCover && Vector3.Distance(body.position, coverPoint.position) > 0.15f)
        {
            Move(coverPoint.position);
        }

        else if (!inCover && Vector3.Distance(body.position, shootPoint.position) > 0.15f)
        {
            Move(shootPoint.position);
        }

        visableTimer -= Time.fixedDeltaTime;
    }


    private void Move(Vector3 target)
    {
        Vector3 dir = Vector3.Normalize(target - body.position);

        body.position += dir * moveSpeed;
    }


    public void SetMoveSpeed(float point)
    {
        moveSpeed = moveSpeeds.x + ((moveSpeeds.y - moveSpeeds.x) * point);
        visableTimer = visableTime.x - ((visableTime.y - visableTime.x) * point);
    }
}
