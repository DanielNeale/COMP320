using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int shotCount;
    public float totalAccuracy = 50;
    private SortedList<float, float> recentAccuracy = new SortedList<float, float>();
    [SerializeField]
    private LayerMask enemyMask;
    private int kills;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float newAccuracy = Shoot();

            recentAccuracy.Add(newAccuracy, 0);

            totalAccuracy = 0;

            for (int i = 0; i < recentAccuracy.Count; i++)
            {
                totalAccuracy += recentAccuracy[i];
            }

            totalAccuracy /= recentAccuracy.Count;

            shotCount++;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < recentAccuracy.Count; i++)
        {
            if(recentAccuracy.)
        }
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
            kills++;
        }

        return accuracy;
    }

    public float GetAccuracy()
    {
        return totalAccuracy;
    }
}


public class RecentAccuracies
{

}
