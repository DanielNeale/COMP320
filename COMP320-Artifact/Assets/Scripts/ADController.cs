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

    private Queue<float> timeInSight = new Queue<float>();
    private List<bool> inSightThisSec = new List<bool>();


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
            if (Physics.Linecast(transform.position, player.position, out RaycastHit hit) && hit.transform == player)
            {
                inSight = true;
            }
        }

        inSightThisSec.Add(inSight);
        
        if (inSightThisSec.Count >= 50)
        {
            int secondAverage = 0;

            for (int i = 0; i < inSightThisSec.Count; i++)
            {
                if (inSightThisSec[i])
                {
                    secondAverage++;
                }

                secondAverage /= inSightThisSec.Count;

                timeInSight.Enqueue(secondAverage);

                if (timeInSight.Count > 30)
                {
                    timeInSight.Dequeue();
                }
            }
        }
    }
}
