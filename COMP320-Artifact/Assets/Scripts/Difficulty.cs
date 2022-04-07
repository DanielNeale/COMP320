using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField]
    private float easyMod;
    [SerializeField]
    private float hardMod;


    /// <summary>
    /// Sets difficulty values
    /// </summary>
    /// <param name="newDiff"> The player's difficulty input </param>
    public void SetDiff(int newDiff)
    {
        ADController controller = GetComponent<ADController>();

        if (newDiff == 0)
        {
            controller.SetDiffMod(easyMod);
            controller.SetStats(10, 0.4f, 6, 0.6f);
            GetComponent<DataCollection>().SetDiff("e");
        }

        else if (newDiff == 1)
        {
            controller.SetDiffMod(0);
            controller.SetStats(15, 0.5f, 4, 0.5f);
            GetComponent<DataCollection>().SetDiff("n");
        }

        else if (newDiff == 2)
        {
            controller.SetDiffMod(hardMod);
            controller.SetStats(20, 0.6f, 2, 0.4f);
            GetComponent<DataCollection>().SetDiff("h");
        }       
    }
}
