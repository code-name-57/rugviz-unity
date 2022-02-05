using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationManager : MonoBehaviour
{
    private bool landscape; //true for landscape; false for potrait

    public GameObject cameraViewPanel;
    public GameObject tabPanel;

    public GameObject HorizontalParent;
    public GameObject VerticalParent;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.width > Screen.height)
        {
            Landscape();
            landscape = true;
        }
        else if(Screen.width < Screen.height){
            Potrait();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.width > Screen.height && !landscape)
        {
            Landscape();
        }
        else if(Screen.width < Screen.height && landscape){
            Potrait();
        }
    }

    void Landscape()
    {
        landscape = true;

        Debug.Log("Landscape");
        cameraViewPanel.transform.parent = HorizontalParent.transform;
        tabPanel.transform.parent = HorizontalParent.transform;
    }

    void Potrait()
    {
        landscape = false;

        Debug.Log("Potrait");
        cameraViewPanel.transform.parent = VerticalParent.transform;
        tabPanel.transform.parent = VerticalParent.transform;
    }


}
