using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value = 1;

    public void SetValue(int num)
    {
        value = num;
    }

    public void ChangeValue(int num)
    {
        value += num;
    }
    
    public void SetValue(IntData obj)
    {
        value = obj.value;
    }

    public void CompareValue(IntData obj)
    {
        if (value <= obj.value)
        {
            value = obj.value;
        }
    }
}
