using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using Models;

public class SceneTile :  Tile
{

    public GameObject panel0;
    public GameObject panel1;


    public RawImage image;

    public Text tileText;

    private SceneInfo sceneInfo;

    public void ChangeScene(){
        SceneManager.LoadScene(sceneInfo.name, LoadSceneMode.Additive);
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
