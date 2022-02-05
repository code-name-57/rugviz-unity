using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Models;
public class RugTileManager : TileManager
{
    // public RectTransform gallary;

    // public ScrollRect scroll;
    // public GameObject rugTilePrefab;

    // private GameObject[] rugTiles;

    // public void Clear(){
    //     foreach (Transform child in gallary) {
    //         GameObject.Destroy(child.gameObject);
    //     }
    // }

    public void ShowRugTiles(Dictionary<int, Carpet> carpets){
        Clear();
        
        foreach(Carpet carpet in carpets.Values){
            GameObject newRugTile = Instantiate(tilePrefab, new Vector3(0,0,0), Quaternion.identity);
            newRugTile.GetComponent<RugTile>().Initialize(carpet, gallary, scroll);

        }
    }

}
