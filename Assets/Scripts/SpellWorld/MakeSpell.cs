using UnityEngine;

public class MakeSpell : MonoBehaviour
{
    [SerializeField] private Transform _pointToCreatMagic;
    

    public static MakeSpell Instance;

    public System.Action<Projectale> AddSpellInTheWorld;

    private void Awake() 
    {
        OnAwake();
    }
    private void OnAwake() => Instance = this;

  
    
    private void CreatSpellWithProjectale(Projectale projectale)
    {
        var temporarySpell = Instantiate(projectale.ViewObject,
            _pointToCreatMagic.position,_pointToCreatMagic.rotation) as GameObject;

        Destroy(temporarySpell,5f);
    }





    private void OnEnable()
    {
        AddSpellInTheWorld += CreatSpellWithProjectale;
    }

    private void OnDisable()
    {
        AddSpellInTheWorld -= CreatSpellWithProjectale;
    }
}
