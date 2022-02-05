using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;

public class CameraViewController : Singleton<CameraViewController>
{
    public GameObject rug;

    public GameObject floor;

    private Color SelectedColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        rug = GameObject.FindGameObjectsWithTag("Rug")[0];

        floor = GameObject.FindGameObjectsWithTag("Floor")[0];

    }


    public void VisualizeRug(Carpet carpet)
    {
        Debug.Log("Changing Rug");
        string designName =  Design.AllDesigns[carpet.design].name;
        string collectionName = Collection.AllCollections[Design.AllDesigns[carpet.design].collection].name;
        Debug.Log("Carpet to be visualized"  + carpet.id + " Design name : " + designName + " Collection name : " + collectionName);
        Renderer rnd = rug.GetComponent<Renderer>();
        Material mtl = rnd.material;
        mtl.SetTexture("_BaseMap", carpet.texture);   
    }

    public void VisualizeFloor(FloorTexture flrTx)
    {
        Debug.Log("CHainging floor ");
        Renderer rnd = floor.GetComponent<Renderer>();
        Material mtl = rnd.material;
        mtl.SetTexture("_BaseMap", flrTx.texture);   
    }

    public void ApplyColor(GameObject gobj)
    {
        Renderer rnd = gobj.GetComponent<Renderer>();
        Material mtl = rnd.sharedMaterial;
        mtl.SetColor("_BaseColor", SelectedColor);
    }
    public void ChangeColor(EnvColor color)
    {
        SelectedColor = color.texColor;
        Debug.Log("Selected color : " + SelectedColor);
    }

}
