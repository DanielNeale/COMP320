using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the enemy's movement
/// </summary>
public class EnemyController : MonoBehaviour
{
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
    private Vector2 visableTimes;
    [SerializeField]
    private float visableTimerVarience = 0.1f;
    private float visableTime;
    private float visableTimer;
    
    private bool inCover = true;


    /// <summary>
    /// Handles the timer for enemy visability
    /// </summary>
    private void Update()
    {
        if (visableTimer < 0)
        {
            inCover = !inCover;
            
            visableTimer = visableTime + Random.Range(-visableTimerVarience, visableTimerVarience);
        }
    }


    /// <summary>
    /// Controls enemy movement
    /// </summary>
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


    /// <summary>
    /// Moves the enemy
    /// </summary>
    /// <param name="target"> Direction to move the enemy </param>
    private void Move(Vector3 target)
    {
        Vector3 dir = Vector3.Normalize(target - body.position);

        body.position += dir * moveSpeed;
    }


    /// <summary>
    /// Sets the enemy speed
    /// </summary>
    /// <param name="point"> Enemy speed value </param>
    public void SetMoveSpeed(float point)
    {
        moveSpeed = moveSpeeds.x + ((moveSpeeds.y - moveSpeeds.x) * point);
        visableTime = visableTimes.x + ((visableTimes.y - visableTimes.x) * point);
    }
}
