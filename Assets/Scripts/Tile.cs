using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

using Models;

public abstract class Tile :  MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public ScrollRect scrollRect;
    
    bool moved = false;
    
    // public RawImage image;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        scrollRect.OnBeginDrag(eventData);
    }
 
    public virtual void OnDrag(PointerEventData eventData)
    {
        scrollRect.OnDrag(eventData);
        moved = true;
    }
 
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        scrollRect.OnEndDrag(eventData);
        moved = false;
    }
 
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public virtual void SetGallary(RectTransform gallary, ScrollRect scroll)
    {
        scrollRect = scroll;
        transform.parent = gallary;
    }

}
