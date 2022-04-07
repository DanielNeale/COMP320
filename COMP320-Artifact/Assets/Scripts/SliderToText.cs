using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Adds text element to sliders
/// </summary>
public class SliderToText : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private Text text;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Sets text to slider value
    /// </summary>
    void Update()
    {
        text.text = slider.value.ToString();
    }
}
