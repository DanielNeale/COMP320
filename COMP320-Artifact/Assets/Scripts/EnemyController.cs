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
    private float minMoveSpeed = 0.1f;
    [SerializeField]
    private float maxMoveSpeed = 0.4f;
    private float moveSpeed;

    [SerializeField]
    private float minVisableTime = 1;
    [SerializeField]
    private float maxVisableTime = 3;
    [SerializeField]
    private float visableTimerVarience = 0.5f;
    private float visableTimer;
    
    private bool inCover = true;


    private void Update()
    {
        moveSpeed = minMoveSpeed + ((maxMoveSpeed - minMoveSpeed) * (gun.GetAccuracy() / 100));

        if (visableTimer < 0)
        {
            inCover = !inCover;

            visableTimer = maxVisableTime - ((maxVisableTime - minVisableTime) * (gun.GetAccuracy() / 100));
            visableTimer += Random.Range(-visableTimerVarience, visableTimerVarience);
            print(visableTimer);
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
}
