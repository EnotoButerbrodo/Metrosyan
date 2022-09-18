﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellInventorySlotReloadHandler : MonoBehaviour
{
    private SpellInventorySlotLink _link;

    private void Awake()
    {
        _link = GetComponent<SpellInventorySlotLink>();
    }
    private void OnEnable()
    {
        _link.ReloadTimer.Tick += OnTick;
        _link.ReloadTimer.Finished += OnTimerFinish;
    }

    private void OnDisable()
    {
        _link.ReloadTimer.Tick -= OnTick;
        _link.ReloadTimer.Finished -= OnTimerFinish;
    }

    private void OnTick(TimerEventArgs e)
    {
        _link.ReloadImage.fillAmount = 1 - ( e.MaxTime / e.CurrentTime);
    }

    private void OnTimerFinish()
    {
        _link.ReloadImage.fillAmount = 0;
    }
}