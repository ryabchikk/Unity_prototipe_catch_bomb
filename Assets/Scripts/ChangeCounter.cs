using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeCounter : MonoBehaviour
{

    public int Value => currentValue;
    public event Action<int> ValueChanged;
    public event Action NoEnergy;

    [SerializeField] private int currentValue;

    public void ChangeValue(int val)
    {
        currentValue += val;

        if (currentValue <= -1)
        {
            currentValue = -1;
            NoEnergy?.Invoke();
        }

        ValueChanged?.Invoke(currentValue);
    }
}
