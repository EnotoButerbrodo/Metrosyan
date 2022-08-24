using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class SpellView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public virtual void OnBeginDrag(PointerEventData eventData) // Наведение на объект
    {

    }

    public virtual void OnDrag(PointerEventData eventData) // нажатие на объект
    {
       
    }

    public virtual void OnEndDrag(PointerEventData eventData) // отжатие мыши
    {
        
    }

   
}
