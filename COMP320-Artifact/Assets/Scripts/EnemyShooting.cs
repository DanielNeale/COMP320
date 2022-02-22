using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    void FixedUpdate()
    {
        transform.LookAt(player.position);

        if (Physics.Linecast(transform.position, player.position, out RaycastHit hit) && hit.transform == player)
        {
            timer -= Time.fixedDeltaTime;
        }

        Shoot();
    }


    private void Shoot()
    {
        
    }
}
