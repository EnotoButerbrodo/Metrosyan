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
        _timerText.text = (e.MaxTime).ToString(_timerFormat);

        _reloadImage.enabled = true;
    }

    private void OnTick(TimerEventArgs e)
    {
        _reloadImage.fillAmount = 1f - ( e.CurrentTime / e.MaxTime);

        _timerText.text = (e.MaxTime - e.CurrentTime).ToString(_timerFormat);
    }

    private void OnTimerFinish()
    {
        _reloadImage.fillAmount = 0;
        _timerText.enabled = false;

        _reloadImage.enabled = false;
    }
}
