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
    public FloatData timeFast;
    private bool start;
    public UnityEvent timerUpdateEvent;
    
    
    [SerializeField]
    private TextMeshProUGUI currentTime;
    [SerializeField]
    private TextMeshProUGUI fastestTime;
    public TextMeshProUGUI fastestTimeTitle;

    private WaitForSeconds _delaySecondsObj;

    private void Start()
    {
        time.value = 0f;
        start = false;
        
        fastestTimeTitle.text = $"Best Time: {PlayerPrefs.GetFloat("HiScore")}";
    }

    private void Update()
    {
        currentTime.text = time.value.ToString("0.00");

    }

    IEnumerator RaceTimer()
    {
        _delaySecondsObj = new WaitForSeconds(secs);

        while (start == true)
        {
            time.value = Time.time - timer;
            
            timerUpdateEvent.Invoke();

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

    public void FastestTime()
    {
        if (time.value < PlayerPrefs.GetFloat("HiScore", 1000000f))
        {
            PlayerPrefs.SetFloat("HiScore",time.value);
        }

        fastestTime.text = $"Best Time: {PlayerPrefs.GetFloat("HiScore")}";
    }
}
