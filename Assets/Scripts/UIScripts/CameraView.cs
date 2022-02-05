using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : MonoBehaviour
{
    public Texture2D texture;
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        GetComponent<Image>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
