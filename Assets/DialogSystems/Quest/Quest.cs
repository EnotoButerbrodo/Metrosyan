using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questView;

    private List<QuestView> _questes = new List<QuestView>();
    private Dictionary<string,QuestView> _dictionaryQuest = new Dictionary<string, QuestView>();

    public static System.Action<QuestDescription> OnAddQuest;
    public static System.Action<QuestDescription> OnRemoveQuest;
    private int _selectedQuest = 0;

    private void OnEnable()
    {
        OnAddQuest += AddQuest;
        OnRemoveQuest += DeleteQuest;
    }

    private void OnDisable()
    {
        OnAddQuest -= AddQuest;
        OnRemoveQuest -= DeleteQuest;
    }

    private void AddQuest(QuestDescription Quest)
    {
        if(Quest is null) return;
        
        if(_dictionaryQuest.ContainsKey(Quest.TextQuestDescription)) return;

        QuestView _view = new QuestView();
        _view.Init(Quest);
 
        _questes.Add(_view);

        _dictionaryQuest.Add(Quest.TextQuestDescription,_view);
        if(_questView.text == string.Empty )UpdateUI();
    }

    public void DeleteQuest(QuestDescription Quest)
    {
        if(Quest is null) return;
        if(!_dictionaryQuest.ContainsKey(Quest.TextQuestDescription)) return;
        
        _questes.Remove(_dictionaryQuest[Quest.TextQuestDescription]);
        _dictionaryQuest.Remove(Quest.TextQuestDescription);
       UpdateUI();
    }

    private void UpdateUI()
    {
        if(_questes.Count != 0)
        {
            Debug.Log(_selectedQuest);
            _questView.text = _questes[_selectedQuest].Desctiprition.TextQuestDescription;
        }
        else
        {
            _questView.text = System.String.Empty;
        }
    }

    public void Next()
    {
        if(_selectedQuest >= _questes.Count-1) return;
        _selectedQuest++;
        UpdateUI();
    }

    public void Previus()
    {
        _selectedQuest--;
        if(_selectedQuest < 0) _selectedQuest = 0;        
        UpdateUI();
    }
}