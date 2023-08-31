using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    public Slider value;
    TextMeshProUGUI text;
    public string textToShow;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();        
    }

    private void Update()
    {
        text.text=textToShow + value.value;
    }
}
