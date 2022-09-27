using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMesh))]
public class OnValueChangedText : MonoBehaviour
{
    private TextMesh ValueText;

    private void Start()
    {
        ValueText = GetComponent<TextMesh>();
    }

    public void OnSliderValueChanged(float value)
    {
        ValueText.text = value.ToString("0.00");
    }
}
