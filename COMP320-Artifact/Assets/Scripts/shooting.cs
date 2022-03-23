using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float totalAccuracy = 50;
    private List<RecentAccuracies> recentAccuracy = new List<RecentAccuracies>();
    [SerializeField]
    private LayerMask enemyMask;
    
    public int kills;
    private List<float> recentKills = new List<float>();

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float newAccuracy = Shoot();

            recentAccuracy.Add(new RecentAccuracies(newAccuracy, 0));

            totalAccuracy = 0;

            for (int i = 0; i < recentAccuracy.Count; i++)
            {
                totalAccuracy += recentAccuracy[i].accuracy;
            }

            totalAccuracy /= recentAccuracy.Count;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < recentAccuracy.Count; i++)
        {
            if (recentAccuracy[i].timer < 60)
            {
                recentAccuracy[i].timer += Time.fixedDeltaTime;
            }

            else
            {
                recentAccuracy.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < recentKills.Count; i++)
        {
            if (recentKills[i] < 60)
            {
                recentKills[i] += Time.fixedDeltaTime;
            }

            else
            {
                recentKills.RemoveAt(i);
                break;
            }
        }

        kills = recentKills.Count;
    }


    private float Shoot()
    {
        float accuracy = 0;

        Ray newCast = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(newCast, out RaycastHit hit, Mathf.Infinity, enemyMask))
        {
            Vector3 centerVector = Vector3.Normalize(hit.transform.position - hit.point);

            float angle = Vector3.Angle(centerVector, newCast.direction);

            accuracy = 100 - angle;

            hit.transform.parent.parent.gameObject.SetActive(false);
            recentKills.Add(0);       
        }

        return accuracy;
    }

    public float GetAccuracy()
    {
        return (totalAccuracy);
    }
}


public class RecentAccuracies
{
    public float accuracy;
    public float timer;

    public RecentAccuracies(float acc, float tim)
    {
        accuracy = acc;
        timer = tim;
    }
}
