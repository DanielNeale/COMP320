using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADController : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemyParents;
    private List<Transform> enemies = new List<Transform>();


    private void Start()
    {
        for (int i = 0; i < enemyParents.Length; i++)
        {
            for (int j = 0; j < enemyParents[i].childCount; j++)
            {
                enemies.Add(enemyParents[i].GetChild(j));
            }
        }
    }
}
