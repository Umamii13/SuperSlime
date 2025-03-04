using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarslidce : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxmana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

    }

    public void SetMana(int mana)
    {
        slider.value = mana;
        
    }
}
