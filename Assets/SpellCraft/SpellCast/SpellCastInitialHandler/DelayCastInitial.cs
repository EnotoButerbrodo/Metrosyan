﻿
using System;
using UnityEngine;

public class DelayCastInitial : SpellCastInitialHandler
{
    //При выборе слота начать процесс каста
    //Активировать прицел
    //Изменять состояние прицела по ходу длительности
    //После завершения приготовления начать каст
    public override event Action CastStarted;

    public override event Action Initialized;


    private float _castTime;
    private Timer _castTimer;
    private SpellSighManager _spellSight;
    private IInputLisener _slotSelectLisener;

    private Color _startColor = Color.green;
    private Color _endColor = Color.red;

    public DelayCastInitial(float castTime, Timer castTimer, SpellSighManager spellSight, IInputLisener slotSelectLisener)
    {
        _castTime = castTime;
        _castTimer = castTimer;
        _spellSight = spellSight;
        _slotSelectLisener = slotSelectLisener;
    }

    public override void InitialCast()
    {
        Enable();
        _slotSelectLisener.DisableInput();
        _castTimer.StartTimer(_castTime);

        _spellSight.Show();
        CastStarted?.Invoke();
    }

    public override void Disable()
    {
        _castTimer.Tick -= OnCastTimerTick;
        _castTimer.Finished -= OnCastTimerFinished;

        if (_castTimer.IsStarted == true)
        {
            _castTimer.Stop();
        }

        _slotSelectLisener.EnableInput();
    }
    private void Enable()
    {
        if (_castTimer.IsStarted == true)
        {
            _castTimer.Stop();
        }

        _castTimer.Tick += OnCastTimerTick;
        _castTimer.Finished += OnCastTimerFinished;
    }
    private void OnCastTimerFinished()
    {
        Disable();
        _slotSelectLisener.EnableInput();
        Initialized?.Invoke();
    }

    private void OnCastTimerTick(TimerEventArgs e)
    {
        float lerpKoeff = e.CurrentTime / e.MaxTime;

        _spellSight.ChangeColor(Color.Lerp(_startColor, _endColor, lerpKoeff));
    }

}
