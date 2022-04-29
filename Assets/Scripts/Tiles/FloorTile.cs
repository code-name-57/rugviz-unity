using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

using Models;

public class FloorTile :  Tile
{
    FloorTexture floorTexture;
    public RawImage floorImage;

    public string iname = "";
    
    public RawImage image;
 
    public override void OnPointerClick(PointerEventData eventData)
    {
        CameraViewController.Instance.VisualizeFloor(floorTexture);

    }
    public void Initialize(FloorTexture flrTex, RectTransform gallary, ScrollRect scroll)
    {
        SetGallary(gallary, scroll);
        floorTexture = flrTex;

        // DownloadImage(floorTexture.image_file);

    }

    public void DownloadImage(string url)
    {
        StartCoroutine(APIConnection.Instance.ImageRequest(url, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            } else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                floorImage.texture = texture;

            }
        }));
    }
    public void OnEnable(){
        StartCoroutine(GetTexture());

    }
    IEnumerator GetTexture(){
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(floorTexture.image_file);
        yield return www.SendWebRequest();

        Texture myTexture = DownloadHandlerTexture.GetContent(www);
        floorImage.texture = myTexture;
        floorTexture.texture = myTexture;
    }
}
