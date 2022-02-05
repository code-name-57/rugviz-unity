using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class MouseClick : MonoBehaviour
{
    //Drag Orthographic top down camera here
    public Camera miniMapCam;
 

    // public GameObject ColorPicker;
    // private ColorPickerTriangle CP;
    // private bool isPaint = false;
    public GameObject camView;

    bool Selected = false;
    private Material mat;
    public void OnPointerClick(BaseEventData bData)
    {
        PointerEventData eventData = (PointerEventData) bData;
        Vector2 localCursor = new Vector2(0, 0);
 
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(camView.GetComponent<RawImage>().rectTransform, eventData.pressPosition, eventData.pressEventCamera, out localCursor))
        {
 
            Texture tex = camView.GetComponent<RawImage>().texture;
            Rect r = camView.GetComponent<RawImage>().rectTransform.rect;
 
            //Using the size of the texture and the local cursor, clamp the X,Y coords between 0 and width - height of texture
            float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
            float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);
 
            //Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height
            float recalcX = coordX / tex.width;
            float recalcY = coordY / tex.height;
 
            localCursor = new Vector2(recalcX, recalcY);
 
            CastMiniMapRayToWorld(localCursor);
         
        }
 
    }

    public void OnPointerDrag(BaseEventData bData)
    {
        Debug.Log("Dragged");
    }
 
    private void CastMiniMapRayToWorld(Vector2 localCursor)
    {
        Ray miniMapRay = miniMapCam.ScreenPointToRay(new Vector2(localCursor.x * miniMapCam.pixelWidth, localCursor.y * miniMapCam.pixelHeight));
 
        RaycastHit miniMapHit;
 
        if (Physics.Raycast(miniMapRay, out miniMapHit, Mathf.Infinity))
        {
            Debug.Log("miniMapHit: " + miniMapHit.collider.gameObject.name);
            CameraViewController.Instance.ApplyColor( miniMapHit.collider.gameObject);
            // mat = miniMapHit.collider.gameObject.GetComponentInChildren<Renderer>().material;
            // StartPaint();
            // ColorPicker.SetActive(true);
            // Selected=true;
            // ColorPicker.Create(mat.color, "Choose the cube's color!", SetColor, ColorFinished, true);
            
        }
        // else if(Selected){
        //     ColorPicker.SetActive(false);
        //     Selected = false;
        // }
 
    }
    private void SetColor(Color currentColor)
    {
        mat.color = currentColor;
    }

    private void ColorFinished(Color finishedColor)
    {
        Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }
    void Start(){
        // ColorPicker.SetActive(false);

    }
    public void ColorSelected(Color col){
        if(mat != null)
            mat.color = col;
        // ColorPicker.SetActive(false);
        // Selected =  false;
        
    }
 


 
}
 