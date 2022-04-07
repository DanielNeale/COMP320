using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles shooting, accuracy and kills
/// </summary>
public class Shooting : MonoBehaviour
{
    public float totalAccuracy = 0.5f;
    private List<RecentAccuracies> recentAccuracy = new List<RecentAccuracies>();
    [SerializeField]
    private LayerMask enemyMask;
    
    public int kills;
    private List<float> recentKills = new List<float>();

    
    /// <summary>
    /// Shoots and adds an accuracy
    /// </summary>
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

    /// <summary>
    /// Removes accuracies and kills after 60 seconds
    /// </summary>
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


    /// <summary>
    /// Handles a shot
    /// </summary>
    /// <returns> The accuracy of the shot </returns>
    private float Shoot()
    {
        float accuracy = 0;

        Ray newCast = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(newCast, out RaycastHit hit, Mathf.Infinity, enemyMask))
        {
            Vector3 centerVector = Vector3.Normalize(hit.transform.position - hit.point);

            float angle = Vector3.Angle(centerVector, newCast.direction);

            accuracy = (100 - angle) / 100;

            hit.transform.parent.parent.gameObject.SetActive(false);
            recentKills.Add(0);       
        }

        return accuracy;
    }


    /// <summary>
    /// Returns the accuracy
    /// </summary>
    /// <returns> Current player accuracy </returns>
    public float GetAccuracy()
    {
        return (totalAccuracy);
    }


    /// <summary>
    /// Sets the player's accuracy
    /// </summary>
    /// <param name="value"> New accuracy </param>
    public void SetAccuracy(float value)
    {
        for (int i = 0; i < 15; i++)
        {
            recentAccuracy.Add(new RecentAccuracies(value, i * 2));
        }
    }


    /// <summary>
    /// Returns the number of kills
    /// </summary>
    /// <returns> Current number of kills </returns>
    public int GetKills()
    {
        return kills;
    }


    /// <summary>
    /// Sets the player's kills
    /// </summary>
    /// <param name="value"> Number of kills </param>
    public void SetKills(int value)
    {
        for (int i = 0; i < value; i++)
        {
            recentKills.Add(i * 2);
        }
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
