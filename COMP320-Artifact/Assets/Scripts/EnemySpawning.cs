using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject openGate;
    [SerializeField]
    private GameObject closeGate;


    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }

        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().SetRespawn(other.transform.position);
        }

        openGate.SetActive(false);
        closeGate.SetActive(true);
    }
}
