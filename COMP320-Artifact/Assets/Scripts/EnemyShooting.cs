using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles enemy shooting
/// </summary>
public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector2 accuracies;
    private float accuracy;
    [SerializeField]
    private Vector2 fireRates;
    private float fireRate;
    private float timer;

    
    /// <summary>
    /// Looks at player and handles when to attept a shot
    /// </summary>
    void FixedUpdate()
    {
        transform.LookAt(player.position);

        if (Physics.Linecast(transform.position, player.position, out RaycastHit hit) && hit.transform == player && timer < 0)
        {           
            Shoot();

            timer = fireRate;
        }

        timer -= Time.fixedDeltaTime;
    }


    /// <summary>
    /// Handles shooting
    /// </summary>
    private void Shoot()
    {
        print(accuracy);

        if (Random.Range(0, 100) < accuracy)
        {
            player.GetComponent<Health>().Damage();
        }     
    }


    /// <summary>
    /// Sets the accuracy of this enemy
    /// </summary>
    /// <param name="point"> The accuracy value </param>
    public void SetAccuracy(float point)
    {
        accuracy = accuracies.x + ((accuracies.y - accuracies.x) * point);
    }


    /// <summary>
    /// Sets the fire rate of this enemy
    /// </summary>
    /// <param name="point"> The fire rate value </param>
    public void SetFireRate(float point)
    {
        fireRate = fireRates.x + ((fireRates.y - fireRates.x) * point);
    }
}
