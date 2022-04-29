using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

using Models;

public class SceneTile :  Tile
{        
    public RawImage image;

    public Text tileText;

    private SceneInfo sceneInfo;

    public void ChangeScene(){
        // SceneManager.LoadScene(sceneInfo.name, LoadSceneMode.Single);
        Debug.Log("Simulated scene change : " + sceneInfo.name);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        ChangeScene();

    }

    public void SetSceneInfo(SceneInfo scene)
    {
        sceneInfo = scene;
        tileText.text = scene.name;
        image.texture = scene.image;

    }


    public void Initialize(SceneInfo scene, RectTransform gallary, ScrollRect scroll)
    {
        SetSceneInfo(scene);
        SetGallary(gallary, scroll);

        image.texture = sceneInfo.image;
    }


}
