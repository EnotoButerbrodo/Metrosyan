using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellInventorySlotReloadPresenter : MonoBehaviour
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private string _timerFormat = "0.00";
    [SerializeField] private Timer _reloadTimer;

    [SerializeField] private bool _reversed;

    private Func<TimerEventArgs, float> _getFillAmount;


    private void Awake()
    {
        _getFillAmount = _reversed ? GetReversedFillAmount : GetFillAmount;
    }
    private void OnEnable()
    {
        _reloadTimer.Started += OnTimerStart;
        _reloadTimer.Tick += OnTick;
        _reloadTimer.Finished += OnTimerFinish;
    }

    private void OnDisable()
    {
        _reloadTimer.Started += OnTimerStart;
        _reloadTimer.Tick -= OnTick;
        _reloadTimer.Finished -= OnTimerFinish;
    }

    private void OnTimerStart(TimerEventArgs e)
    {
        _timerText.enabled = true;
        SetTimerTime(e.MaxTime);
        _reloadImage.enabled = true;
    }

    private void OnTick(TimerEventArgs e)
    {
        _reloadImage.fillAmount = _getFillAmount(e);

        float reloadPercent = e.MaxTime - e.CurrentTime;
        SetTimerTime(reloadPercent);
    }

    private float GetFillAmount(TimerEventArgs e)
        => 1f - (e.CurrentTime / e.MaxTime);

    private float GetReversedFillAmount(TimerEventArgs e)
        => e.CurrentTime / e.MaxTime;


    private void SetTimerTime(float time)
    {
        string format = time > 1f ? "0" : _timerFormat;

        _timerText.text = (time).ToString(format, System.Globalization.CultureInfo.InvariantCulture);
    }

    private void OnTimerFinish()
    {
        _reloadImage.fillAmount = 0;
        _timerText.enabled = false;

        _reloadImage.enabled = false;
    }
}
