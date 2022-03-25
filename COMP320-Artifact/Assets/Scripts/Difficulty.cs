using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public enum Diff {Easy, Normal, Hard};

    [SerializeField]
    private float easyMod;
    [SerializeField]
    private float hardMod;


    public void SetDiff(Diff newDiff)
    {
        if (newDiff == Diff.Easy)
        {
            GetComponent<ADController>().SetDiffMod(easyMod);
        }

        else if (newDiff == Diff.Normal)
        {
            GetComponent<ADController>().SetDiffMod(0);
        }

        else if (newDiff == Diff.Hard)
        {
            GetComponent<ADController>().SetDiffMod(hardMod);
        }

        
    }
}
