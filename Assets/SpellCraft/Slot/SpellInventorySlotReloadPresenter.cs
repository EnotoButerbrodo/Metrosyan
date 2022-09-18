using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellInventorySlotReloadPresenter : MonoBehaviour
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private string _timerFormat = "0.00";

    private SpellInventorySlotLink _link;

    private void Awake()
    {
        _link = GetComponent<SpellInventorySlotLink>();
    }
    private void OnEnable()
    {
        _link.ReloadTimer.Started += OnTimerStart;
        _link.ReloadTimer.Tick += OnTick;
        _link.ReloadTimer.Finished += OnTimerFinish;
    }

    private void OnDisable()
    {
        _link.ReloadTimer.Started += OnTimerStart;
        _link.ReloadTimer.Tick -= OnTick;
        _link.ReloadTimer.Finished -= OnTimerFinish;
    }

    private void OnTimerStart(TimerEventArgs e)
    {
        _timerText.enabled = true;

        SetTimerTime(e.MaxTime);

        _reloadImage.enabled = true;
    }

    private void OnTick(TimerEventArgs e)
    {
        _reloadImage.fillAmount = 1f - ( e.CurrentTime / e.MaxTime);

        float reloadPercent = e.MaxTime - e.CurrentTime;
        SetTimerTime(reloadPercent);
    }

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
