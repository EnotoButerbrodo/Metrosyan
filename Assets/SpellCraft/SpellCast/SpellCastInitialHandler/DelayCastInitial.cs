
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

    private Color _startColor = Color.green;
    private Color _endColor = Color.red;

    public DelayCastInitial(float castTime, Timer castTimer, SpellSighManager spellSight)
    {
        _castTime = castTime;
        _castTimer = castTimer;
        _spellSight = spellSight;
    }

    public override void InitialCast()
    {
        Enable();
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
        Initialized?.Invoke();
    }

    private void OnCastTimerTick(TimerEventArgs e)
    {
        float lerpKoeff = e.CurrentTime / e.MaxTime;

        _spellSight.ChangeColor(Color.Lerp(_startColor, _endColor, lerpKoeff));
    }

}
