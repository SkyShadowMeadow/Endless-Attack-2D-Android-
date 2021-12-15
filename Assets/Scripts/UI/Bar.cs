using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
