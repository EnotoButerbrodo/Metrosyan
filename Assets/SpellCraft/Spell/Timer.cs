using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public Action<TimerEventArgs> Started;
    public Action<TimerEventArgs> Tick;
    public Action Finished;
    private bool _stopRequsted;

    public bool IsFinished { get; private set; }
    public void StartTimer(float time)
    {
        IsFinished = false;
        StartCoroutine(TimerHandler(time));

    }

    public void Stop()
    {
        _stopRequsted = true;
        Finished?.Invoke();
    }


    private IEnumerator TimerHandler(float reloadTime)
    {
        Started?.Invoke(new TimerEventArgs(0, reloadTime));

        for (float currentTime = 0; currentTime < reloadTime; currentTime += Time.deltaTime)
        {
            if (_stopRequsted)
            {
                _stopRequsted = false;
                break;
            }
            Tick?.Invoke(new TimerEventArgs(currentTime, reloadTime));
            yield return null;
        }

        IsFinished = true;
        Finished?.Invoke();
    }
}

public class TimerEventArgs
{
    public float CurrentTime { get; private set; }
    public float MaxTime { get; private set; }

    public TimerEventArgs(float currentTime, float maxTime)
    {
        CurrentTime = currentTime;
        MaxTime = maxTime;
    }
}


