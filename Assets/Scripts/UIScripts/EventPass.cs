using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventPass : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    // Start is called before the first frame update
    public string iname = "";

    public ScrollRect scrollRect;
    
    bool moved = false;
    
    public RawImage image;

    public void OnBeginDrag(PointerEventData eventData)
    {
        scrollRect.OnBeginDrag(eventData);
    }
 
    public void OnDrag(PointerEventData eventData)
    {
        scrollRect.OnDrag(eventData);
        moved = true;
    }
 
    public void OnEndDrag(PointerEventData eventData)
    {
        scrollRect.OnEndDrag(eventData);
        moved = false;
    }
 
    public void OnPointerClick(PointerEventData eventData)
    {
        /* Example of click, when not moved.. if needed */
        if(!moved)
            image.color = Random.ColorHSV();

    }
}
