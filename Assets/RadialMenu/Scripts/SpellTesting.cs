using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SpellTesting : SpellView , IPointerClickHandler
{

    private Transform _dragParent;
    private Transform _originParent;

    private ItemMagic _itemMagic;

    public void Init(Transform parent,Sprite sprite)
    {
        _dragParent = parent;
        _originParent = transform.parent;
        _itemMagic = new ItemMagic("Vampire","Aura death",sprite);
        gameObject.GetComponent<Image>().sprite = _itemMagic.Sprite;
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_dragParent,false);
    }

    public override void OnDrag(PointerEventData data)
    {
       transform.localPosition = Input.mousePosition;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
       transform.SetParent(_originParent,false);
    }

     public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(string.Format("Name = {0}, Specification = {1}", _itemMagic.Name,_itemMagic.Specifications));
    }
}
