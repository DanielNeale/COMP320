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
        if (newDiff == 0)
        {
            GetComponent<ADController>().SetDiffMod(easyMod);
        }

        else if (newDiff == 1)
        {
            GetComponent<ADController>().SetDiffMod(0);
        }

        else if (newDiff == 2)
        {
            GetComponent<ADController>().SetDiffMod(hardMod);
        }

        
    }
}
