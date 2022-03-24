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
    private Vector2 damageRange;
    private float damage;
    private Vector3 respawnPoint;
    private int deaths;
    private List<float> recentDeaths = new List<float>();


    private void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < recentDeaths.Count; i++)
        {
            if (recentDeaths[i] < 60)
            {
                recentDeaths[i] += Time.deltaTime;
            }

            else
            {
                recentDeaths.RemoveAt(i);
                break;
            }
        }

        deaths = recentDeaths.Count;
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
            recentDeaths.Add(0);
        }
    }

    public void SetRespawn(Vector3 newSpawn)
    {
        respawnPoint = newSpawn;        
    }


    public int GetDeaths()
    {
        return deaths;
    }


    public void SetDamage(float point)
    {
        damage = damageRange.x + ((damageRange.y - damageRange.x) * point);
    }
}
