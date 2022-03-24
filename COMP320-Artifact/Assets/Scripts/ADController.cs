using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Health health;
    [SerializeField]
    private Shooting gun;
    
    [SerializeField]
    private Transform[] enemyParents;
    private List<Transform> enemies = new List<Transform>();
    private List<EnemyController> enemyControllers = new List<EnemyController>();
    private List<EnemyShooting> enemyShootings = new List<EnemyShooting>();

    private List<float> timeInSight = new List<float>();
    private List<bool> inSightThisSec = new List<bool>();
    
    public float averageInSight;
    public float accuracy;
    public int deaths;
    public int kills;

    [SerializeField]
    private int maxKills;
    [SerializeField]
    private int maxDeaths;


    private void Awake()
    {
        InvokeRepeating("HandleDamage", 0, 1);
        InvokeRepeating("HandleSpeed", 0, 1);
        InvokeRepeating("HandleFireRate", 0, 1);
        InvokeRepeating("HandleAccuracy", 0, 1);
    }


    private void Start()
    {
        for (int i = 0; i < enemyParents.Length; i++)
        {
            for (int j = 0; j < enemyParents[i].childCount; j++)
            {
                enemies.Add(enemyParents[i].GetChild(j));
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemyControllers.Add(enemies[i].GetComponent<EnemyController>());
            enemyShootings.Add(enemies[i].GetComponentInChildren<EnemyShooting>());
        }

        health = player.GetComponent<Health>();
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

            if (timeInSight.Count > 60)
            {
                timeInSight.RemoveAt(0);
            }
        }        
    }


    private void GetInSight()
    {
        averageInSight = 0;

        for (int i = 0; i < timeInSight.Count; i++)
        {
            averageInSight += timeInSight[i];
        }

        averageInSight /= timeInSight.Count;
    }


    private void HandleDamage()
    {
        deaths = health.GetDeaths();

        if (deaths < maxDeaths)
        {
            health.SetDamage(1 - (deaths / maxDeaths));
        }

        else
        {
            health.SetDamage(0);
        }
    }


    private void HandleSpeed()
    {
        accuracy = gun.GetAccuracy();

        for (int i = 0; i < enemyControllers.Count; i++)
        {
            enemyControllers[i].SetMoveSpeed(accuracy);
        }
    }


    private void HandleFireRate()
    {
        GetInSight();

        for (int i = 0; i < enemyShootings.Count; i++)
        {
            enemyShootings[i].SetFireRate(averageInSight);
        }
    }


    private void HandleAccuracy()
    {
        kills = gun.GetKills();

        if (kills < maxKills)
        {
            for (int i = 0; i < enemyShootings.Count; i++)
            {
                enemyShootings[i].SetAccuracy(1 - (kills / maxKills));
            }
        }

        else
        {
            for (int i = 0; i < enemyShootings.Count; i++)
            {
                enemyShootings[i].SetAccuracy(0);
            }
        }
    }
}
