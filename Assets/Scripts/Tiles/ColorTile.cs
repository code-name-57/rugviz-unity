using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

using Models;

public class ColorTile :  Tile
{
    EnvColor color;
        
    public RawImage image;
 
    public override void OnPointerClick(PointerEventData eventData)
    {
        CameraViewController.Instance.ChangeColor(color);

    }
    public void Initialize(EnvColor clr, RectTransform gallary, ScrollRect scroll)
    {
        SetGallary(gallary, scroll);
        color = clr;

        image.color = color.texColor;
    }

}
