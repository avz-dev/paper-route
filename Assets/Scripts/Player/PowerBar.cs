using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPower(int maxPower, int minPower, int power)
    {
        slider.maxValue = maxPower;
        slider.minValue = minPower;
        slider.value = power;
    }

    public void SetPower(float power)
    {
        slider.value = power;
    }

    public void SetProgress(int progress)
    {
        slider.value = progress;
    }
}
