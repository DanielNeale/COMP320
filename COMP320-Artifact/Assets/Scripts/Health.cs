using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float health;
    [SerializeField]
    private float[] damageRange;
    public float damage;
    private Vector3 respawnPoint;


    private void Start()
    {
        health = maxHealth;
    }

    public void Damage()
    {
        health -= damage;

        if (health < 0)
        {
            transform.position = respawnPoint;
            health = maxHealth;
        }
    }

    public void SetRespawn(Vector3 newSpawn)
    {
        respawnPoint = newSpawn;
    }
}
