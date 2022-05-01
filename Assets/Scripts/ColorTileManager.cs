using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Models;
public class ColorTileManager : Singleton<ColorTileManager>
{
    public RectTransform gallary;

    public ScrollRect scroll;
    public GameObject colorTilePrefab;

    public void Clear(){
        foreach (Transform child in gallary) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void ShowColorTiles(Dictionary<int, EnvColor> envColors){
        Clear();
        
        foreach(EnvColor envColor in envColors.Values){
            GameObject newColorTile = Instantiate(colorTilePrefab, new Vector3(0,0,0), Quaternion.identity);
            newColorTile.GetComponent<ColorTile>().Initialize(envColor, gallary, scroll);

        }
    }
}
