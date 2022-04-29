using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Models;
public class FloorTileManager : Singleton<FloorTileManager>
{
    public RectTransform gallary;

    public ScrollRect scroll;
    public GameObject floorTilePrefab;

    public void Clear(){
        foreach (Transform child in gallary) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void ShowFloorTiles(Dictionary<int, FloorTexture> floorTextures){
        Clear();
        
        foreach(FloorTexture floorTexture in floorTextures.Values){
            GameObject newfloorTile = Instantiate(floorTilePrefab, new Vector3(0,0,0), Quaternion.identity);
            newfloorTile.GetComponent<FloorTile>().Initialize(floorTexture, gallary, scroll);

        }
    }

}
