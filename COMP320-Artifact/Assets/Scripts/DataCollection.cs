using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all data collection and formatting
/// </summary>
public class DataCollection : MonoBehaviour
{
    private List<float> skillLevel = new List<float>();

    private float constantDiff;
    private float fun;

    private string adEnabled;
    private string diff;


    /// <summary>
    /// Adds a skill to the list
    /// </summary>
    /// <param name="skill"> The skill to be added /param>
    public void AddSkill(float skill)
    {
        skillLevel.Add(skill);
    }


    /// <summary>
    /// Generates a csv file of with the data
    /// </summary>
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


    /// <summary>
    /// Sets the consistant difficulty question
    /// </summary>
    /// <param name="value"> Player's answer </param>
    public void SetConstantDiff(float value)
    {
        constantDiff = value;
    }


    /// <summary>
    /// Sets the fun question
    /// </summary>
    /// <param name="value"> Player's answer </param>
    public void SetFun(float value)
    {
        fun = value;
    }


    /// <summary>
    /// Sets the difficulty
    /// </summary>
    /// <param name="newDiff"> The selected difficulty </param>
    public void SetDiff(string newDiff)
    {
        diff = newDiff;
    }


    /// <summary>
    /// Sets if AD is enabled
    /// </summary>
    /// <param name="isEnabled"> If AD is enabled</param>
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
