using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private Text text;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        text.text = slider.value.ToString();
    }
}
