using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Models;
public class SceneTileManager : Singleton<SceneTileManager>
{

    public SceneInfo[] sceneInfoList;

    public RectTransform gallary;

    public ScrollRect scroll;
    public GameObject sceneTilePrefab;

    public void Clear(){
        foreach (Transform child in gallary) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void Start(){
        ShowSceneTiles();
    }
    public void ShowSceneTiles(){
        Clear();
        
        foreach(SceneInfo scene in sceneInfoList){
            GameObject newSceneTile = Instantiate(sceneTilePrefab, new Vector3(0,0,0), Quaternion.identity);
            newSceneTile.GetComponent<SceneTile>().Initialize(scene, gallary, scroll);

        }
    }

}
