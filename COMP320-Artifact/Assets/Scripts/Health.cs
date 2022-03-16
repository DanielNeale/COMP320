using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private float maxHealth;
    private float health;
    [SerializeField]
    private float[] damageRange;
    public float damage;
    private Vector3 respawnPoint;
    private int deaths;


    private void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void Damage()
    {
        health -= damage;
        healthBar.value = health;

        if (health < 0)
        {
            transform.position = respawnPoint;
            health = maxHealth;
            healthBar.value = health;
            deaths++;
        }
    }

    public void SetRespawn(Vector3 newSpawn)
    {
        respawnPoint = newSpawn;        
    }
}
