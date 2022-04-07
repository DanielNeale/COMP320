using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles chackpoint behaviour
/// </summary>
public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject openGate;
    [SerializeField]
    private GameObject closeGate;

    [SerializeField]
    private bool startActive;


    /// <summary>
    /// Sets starting enemies to active
    /// </summary>
    private void Start()
    {
        if (startActive)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }
        }
    }


    /// <summary>
    /// Sets enemies to active and player checkpoint
    /// </summary>
    /// <param name="other"> other collider </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }

            other.GetComponent<Health>().SetRespawn(other.transform.position);

            openGate.SetActive(false);
            closeGate.SetActive(true);
        }
    }
}
