using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Models;
public abstract class TileManager : Singleton<RugTileManager>
{
    public RectTransform gallary;

    public ScrollRect scroll;
    public GameObject tilePrefab;

    public void Clear(){
        foreach (Transform child in gallary) {
            GameObject.Destroy(child.gameObject);
        }
    }


}
