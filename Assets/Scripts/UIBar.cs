using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIBar : MonoBehaviour
{
    [SerializeField] private ChangeCounter bar;
    [SerializeField] private Text text;

    private void Start()
    {
        text.text = bar.Value.ToString();
        bar.ValueChanged += UpdateBar;
    }

    private void UpdateBar(int value)
    {
        text.text = value.ToString();
    }
}
