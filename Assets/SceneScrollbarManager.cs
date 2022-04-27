using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScrollbarManager : MonoBehaviour
{
    [SerializeField]
    private string[] sceneList;

    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private Transform scrollViewContentTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sceneList.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, new Vector3(0,0,0), Quaternion.identity);
            newButton.transform.parent = scrollViewContentTransform;
            newButton.GetComponent<SceneTile>().SetSceneName(sceneList[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
