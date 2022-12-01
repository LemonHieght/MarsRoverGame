using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float timer;
    public float secs = 1f;
    public FloatData time;
    private bool start;
    public UnityEvent timerUpdateEvent;
    
    
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    private WaitForSeconds _delaySecondsObj;

    private void Start()
    {
        time.value = 0f;
        start = false;
    }

    private void Update()
    {
        textMeshPro.text = time.value.ToString("0.00");
    }

    IEnumerator RaceTimer()
    {
        _delaySecondsObj = new WaitForSeconds(secs);

        while (start == true)
        {
            time.value = Time.time - timer;
            
            timerUpdateEvent.Invoke();
            
            Debug.Log(time.value);
            
            yield return _delaySecondsObj;
        }
        
    }
    public void StartTimer()
    {
        timer = Time.time;
        Debug.Log(timer);
        start = true;
        StartCoroutine("RaceTimer");
    }

    public void StopTimer()
    {
        start = false;
    }
}
