using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class TextMeshProBehavior : MonoBehaviour
{
    private TextMeshPro textObj;
    public UnityEvent startEvent;
    public string preText;
    
    void Start()
    {
        textObj = GetComponent<TextMeshPro>();
        startEvent.Invoke();
    }

    public void UpdateText(FloatData obj)
    {
        textObj.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    
    public void UpdateText(IntData obj)
    {
        textObj.text =preText + obj.value.ToString(CultureInfo.InvariantCulture);
    }
    
    public void UpdateText(string obj)
    {
        textObj.text =preText + obj.ToString(CultureInfo.InvariantCulture);
    }
}
