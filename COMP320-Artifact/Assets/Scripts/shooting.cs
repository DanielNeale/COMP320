using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int shotCount;
    public float totalAccuracy = 50;
    [SerializeField]
    private LayerMask enemyMask;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float newAccuracy = Shoot();

            totalAccuracy = ((totalAccuracy * shotCount) + newAccuracy) / (shotCount + 1);

            shotCount++;

            print(totalAccuracy);
            print(shotCount);
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

            hit.transform.parent.gameObject.SetActive(false);
        }

        return accuracy;
    }

    public float GetAccuracy()
    {
        return totalAccuracy;
    }
}
