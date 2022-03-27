using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField]
    private float easyMod;
    [SerializeField]
    private float hardMod;


    public void SetDiff(int newDiff)
    {
        ADController controller = GetComponent<ADController>();

        if (newDiff == 0)
        {
            controller.SetDiffMod(easyMod);
            controller.SetStats(5, 0.4f, 6, 0.6f);
        }

        else if (newDiff == 1)
        {
            controller.SetDiffMod(0);
            controller.SetStats(10, 0.5f, 4, 0.5f);
        }

        else if (newDiff == 2)
        {
            controller.SetDiffMod(hardMod);
            controller.SetStats(15, 0.6f, 2, 0.4f);
        }       
    }
}
