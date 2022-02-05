using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using System.Collections;
public class APIConnection : Singleton<APIConnection>
{
    public string basePath = "http://rugviz.herokuapp.com/rest";
    // public string basePath = "http://192.168.0.118:8000/rest";

    public Dictionary<int, Collection> AllCollections;
    
	private RequestHelper currentRequest;


	private void LogMessage(string title, string message) {
#if UNITY_EDITOR
		EditorUtility.DisplayDialog (title, message, "Ok");
#else
		Debug.Log(message);
#endif
	}
    // Start is called before the first frame update
    void Start()
    {
        Get();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public IEnumerator ImageRequest(string url, Action<UnityWebRequest> callback)
	{
		using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(url))
		{
			yield return req.SendWebRequest();
			callback(req);
		}
	}


	public void Get(){

		// We can add default request headers for all requests
		// RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

		RequestHelper requestOptions = null;

		RestClient.GetArray<Brand>(basePath + "/Brands").Then(res => {
			// this.LogMessage("Brandss", JsonHelper.ArrayToJsonString<Brand>(res, true));
			Brand.AddBrands(res);
		}).Catch(err => this.LogMessage("Error", err.Message));

        RestClient.GetArray<Size>(basePath + "/Sizes").Then(res => {
			// this.LogMessage("Sizes", JsonHelper.ArrayToJsonString<Size>(res, true));
			Size.AddSizes(res);
		}).Catch(err => this.LogMessage("Error", err.Message));

        RestClient.GetArray<Colour>(basePath + "/Colors").Then(res => {
			// this.LogMessage("Colors", JsonHelper.ArrayToJsonString<Colour>(res, true));
			Colour.AddColors(res);
		}).Catch(err => this.LogMessage("Error", err.Message));
     
		RestClient.GetArray<Design>(basePath + "/Designs").Then(res => {
			// this.LogMessage("Designs", JsonHelper.ArrayToJsonString<Design>(res, true));
			Design.AddDesigns(res);
		}).Catch(err => this.LogMessage("Error", err.Message));


		RestClient.GetArray<Collection>(basePath + "/Collections").Then(res => {
			// this.LogMessage("Collections", JsonHelper.ArrayToJsonString<Collection>(res, true));
			Collection.AddCollections(res);
		}).Catch(err => this.LogMessage("Error", err.Message));


		RestClient.GetArray<Carpet>(basePath + "/Carpets").Then(res => {
			// this.LogMessage("Carpets", JsonHelper.ArrayToJsonString<Carpet>(res, true));
			Carpet.ClearAndAddCarpets(res);

            RugTileManager.Instance.ShowRugTiles(Carpet.CurrentCarpets);

		}).Catch(err => this.LogMessage("Error", err.Message));

		RestClient.GetArray<FloorType>(basePath + "/FloorTypes").Then(res => {
			// this.LogMessage("Floor Types", JsonHelper.ArrayToJsonString<FloorType>(res, true));
			FloorType.AddFloorTypes(res);
		}).Catch(err => this.LogMessage("Error", err.Message));

        RestClient.GetArray<FloorTexture>(basePath + "/FloorTextures").Then(res => {
			// this.LogMessage("Floor Textures", JsonHelper.ArrayToJsonString<FloorTexture>(res, true));
			FloorTexture.AddFloorTextures(res);

			FloorTileManager.Instance.ShowFloorTiles(FloorTexture.AllFloorTextures);
		}).Catch(err => this.LogMessage("Error", err.Message));

		RestClient.GetArray<EnvColor>(basePath + "/EnvColors").Then(res => {
			EnvColor.AddColors(res);
			this.LogMessage("Env Colors", JsonHelper.ArrayToJsonString<EnvColor>(res, true));
			// FloorTexture.AddFloorTextures(res);
			ColorTileManager.Instance.ShowColorTiles(EnvColor.AllColors);
			// FloorTileManager.Instance.ShowFloorTiles(FloorTexture.AllFloorTextures);
		}).Catch(err => Debug.Log(err));
	}

}
