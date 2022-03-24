using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector2 accuracies;
    public float accuracy;
    [SerializeField]
    private Vector2 fireRates;
    public float fireRate;
    private float timer;

    
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


    private void Shoot()
    {
        if (Random.Range(0, 100) < accuracy)
        {
            player.GetComponent<Health>().Damage();
        }     
    }


    public void SetAccuracy(float point)
    {
        accuracy = accuracies.x + ((accuracies.y - accuracies.x) * point);
    }


    public void SetFireRate(float point)
    {
        fireRate = fireRates.x + ((fireRates.y - fireRates.x) * point);
    }
}
