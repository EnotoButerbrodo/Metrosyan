using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ReloadTimer : MonoBehaviour
{
    public Action Finished;

    public Action<ReloadEventArgs> Tick;
    
    public bool IsFinished { get; private set; }
    public void Start(float time)
    {
        IsFinished = false;
        StartCoroutine(TimerHandler(time));
    }

    private IEnumerator TimerHandler(float reloadTime)
    {
        for (float currentTime = 0; currentTime < reloadTime; currentTime += Time.deltaTime)
        {
            Tick?.Invoke(new ReloadEventArgs(currentTime, reloadTime));
            yield return null;
        }

        IsFinished = true;
        Finished?.Invoke();
    }
}

public class ReloadEventArgs
{
    public float CurrentTime { get; private set; }
    public float MaxTime { get; private set; }

    public ReloadEventArgs(float currentTime, float maxTime)
    {
        CurrentTime = currentTime;
        MaxTime = maxTime;
    }
}

