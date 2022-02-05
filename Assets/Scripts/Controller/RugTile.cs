using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

using Models;

public class RugTile :  Tile
{
    Carpet carpet;
    public RawImage rugImage;
    public Text designName;
    public Text rugColor;
    public Text rugSize;
    public RawImage image;
 
    public override void OnPointerClick(PointerEventData eventData)
    {
        CameraViewController.Instance.VisualizeRug(carpet);

    }
    public void Initialize(Carpet crpt, RectTransform gallary, ScrollRect scroll)
    {
        SetGallary(gallary, scroll);
        carpet = crpt;

        designName.text = carpet.GetDesignName();
        StartCoroutine(GetTexture());

    }

    IEnumerator GetTexture(){
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(carpet.image_file);
        yield return www.SendWebRequest();

        Texture myTexture = DownloadHandlerTexture.GetContent(www);
        rugImage.texture = myTexture;
        carpet.texture = myTexture;
    }
}
