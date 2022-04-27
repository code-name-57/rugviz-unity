using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneTile : MonoBehaviour
{
    // Start is called before the first frame update
    private string sceneName;

    public string thumbnailFolder;

    public Text tileText;

    public RawImage image;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSceneName(string scene){

        sceneName = scene;
        Debug.Log("Set scene name : " + sceneName);

        tileText.text = sceneName;
        LoadThumbnail();
    }

    public void ChangeScene(){
        // SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Debug.Log("Simulated scene change : " + sceneName);
    }

    private void LoadThumbnail(){
        // load image as texture using thumbnailFolder Path and scene name
        // set RawImage texture as that image
    }
}
