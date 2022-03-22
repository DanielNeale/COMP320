using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform[] enemyParents;
    private List<Transform> enemies = new List<Transform>();

    private List<float> timeInSight = new List<float>();
    private List<bool> inSightThisSec = new List<bool>();
    
    private float averageInSight;
    private float accuracy;
    private int deaths;
    private int kills;


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


    private void FixedUpdate()
    {
        bool inSight = false;

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].gameObject.activeSelf == true)
            {
                if (Physics.Linecast(enemies[i].position, player.position, out RaycastHit hit) && hit.transform == player)
                {
                    inSight = true;
                }

                Debug.DrawLine(enemies[i].position, player.position, Color.red);
            }         
        }

        inSightThisSec.Add(inSight);
        
        if (inSightThisSec.Count >= 50)
        {
            float secondAverage = 0;

            for (int i = 0; i < inSightThisSec.Count; i++)
            {
                if (inSightThisSec[i])
                {
                    secondAverage++;
                }
                
            }

            secondAverage /= inSightThisSec.Count;

            inSightThisSec.Clear();

            timeInSight.Add(secondAverage);

            print(secondAverage);

            averageInSight = 0;

            for (int i = 0; i < timeInSight.Count; i++)
            {
                averageInSight += timeInSight[i];
            }

            averageInSight /= timeInSight.Count;

            if (timeInSight.Count > 60)
            {
                timeInSight.RemoveAt(0);
            }
        }
    }
}
