using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : MonoBehaviour
{
    private List<float> skillLevel = new List<float>();


    private void Start()
    {
        
    }

    public void AddSkill(float skill)
    {
        skillLevel.Add(skill);
    }


    public void GenerateFile()
    {
        string filePath = Application.dataPath + "/" + Random.Range(0, 999999999) + ".csv";
        string data = "";

        for (int i = 0; i < skillLevel.Count; i++)
        {
            data += skillLevel[i].ToString() + ", "; 
        }

        System.IO.File.WriteAllText(filePath, data);
    }
}
