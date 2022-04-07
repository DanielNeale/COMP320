using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles health, deaths and damage
/// </summary>
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


    /// <summary>
    /// Sets health to max
    /// </summary>
    private void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }


    /// <summary>
    /// Removes deaths after 60 seconds
    /// </summary>
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


    /// <summary>
    /// Deals damage to player and respawn player if health drops below zero
    /// </summary>
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

    /// <summary>
    /// Sets player spawn point
    /// </summary>
    /// <param name="newSpawn"> New spawn point </param>
    public void SetRespawn(Vector3 newSpawn)
    {
        respawnPoint = newSpawn;        
    }


    /// <summary>
    /// Returns player deaths
    /// </summary>
    /// <returns> Number of deaths in the past 60 seconds </returns>
    public int GetDeaths()
    {
        return deaths;
    }


    /// <summary>
    /// Sets the number of deaths
    /// </summary>
    /// <param name="value"> Number of deaths </param>
    public void SetDeaths(int value)
    {
        for (int i = 0; i < value; i++)
        {
            recentDeaths.Add(i * 5);
        }
    }


    /// <summary>
    /// Sets damage
    /// </summary>
    /// <param name="point"> Damage value </param>
    public void SetDamage(float point)
    {
        damage = damageRange.x + ((damageRange.y - damageRange.x) * point);
    }
}
