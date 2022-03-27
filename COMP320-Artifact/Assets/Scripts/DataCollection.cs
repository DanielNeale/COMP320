using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : MonoBehaviour
{
    private List<float> skillLevel = new List<float>();

    private float constantDiff;
    private float fun;

    private string adEnabled;
    private string diff;


    public void AddSkill(float skill)
    {
        skillLevel.Add(skill);
    }


    public void GenerateFile()
    {
        string fileName = adEnabled + diff + Random.Range(0, 999999999);
        string filePath = Application.dataPath + "/" + fileName + ".csv";
        string data = "";

        for (int i = 0; i < skillLevel.Count; i++)
        {
            data += skillLevel[i].ToString() + ", "; 
        }

        data += "\n" + constantDiff.ToString() + ", " + fun.ToString();

        System.IO.File.WriteAllText(filePath, data);
    }


    public void SetConstantDiff(float value)
    {
        constantDiff = value;
    }


    public void SetFun(float value)
    {
        fun = value;
    }


    public void SetDiff(string newDiff)
    {
        diff = newDiff;
    }


    public void SetADEnabled(bool isEnabled)
    {
        if (isEnabled)
        {
            adEnabled = "y";
        }

        else
        {
            adEnabled = "n";
        }
    }
}
