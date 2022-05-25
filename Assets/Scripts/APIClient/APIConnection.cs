using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using System.Collections;

[Serializable]
public class LoginCredentials{
    public string username;
    public string password;
}

[Serializable]
public class LoginToken{
    public string token;
}
public class APIConnection : Singleton<APIConnection>
{
    // public string basePath = "http://rugviz.herokuapp.com/";
    private string basePath = "http://127.0.0.1:8000/";

    public Dictionary<int, Collection> AllCollections;
    
	private RequestHelper currentRequest;

	private LoginToken loginToken;
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
        // Get();
        Login();
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

	public void Login(){
        currentRequest = new RequestHelper
        {
            Uri = basePath + "api-token-auth",
            Body = new LoginCredentials{
				username="admin",
				password="admin"
			},
			EnableDebug = true

        };

		RestClient.Post<LoginToken>(currentRequest)
		.Then(res => {
			this.LogMessage("Success",res.token);
            loginToken = res;
            Get();
        })
		.Catch(err => this.LogMessage("Error", err.Message));
        // RestClient.GetArray<Brand>(basePath + "api-token-auth").Then(res => {
		// 	// this.LogMessage("Brandss", JsonHelper.ArrayToJsonString<Brand>(res, true));
		// 	Brand.AddBrands(res);
		// }).Catch(err => this.LogMessage("Get Brands : Error", err.Message));

	}

/*   TEMP CODE    */
	public void PostImage(){

	}

	public void PostSceneImage(int fav_item_id){
		RestClient.DefaultRequestHeaders["Authorization"] = "Token "+loginToken.token;
		// lists[0].id += 10; 

		currentRequest = new RequestHelper {
			Uri = basePath + "rest/FavoriteList/",
			// Params = new Dictionary<string, string> {
			// 	{ "param1", "value 1" },
			// 	{ "param2", "value 2" }
			// },
			Body = lists[0],
			EnableDebug = true
		};
		RestClient.Post<FavoriteList>(currentRequest)
		.Then(res => {

			// And later we can clear the default query string params for all requests
			RestClient.ClearDefaultParams();

			this.LogMessage("Success", JsonUtility.ToJson(res, true));
		})
		.Catch(err => this.LogMessage("Error", err.Message));
	}

	IEnumerator GetTexture(SceneImage scimg)
	{
		Debug.Log(scimg.image_file);
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(scimg.image_file);
		yield return www.SendWebRequest();

		Texture myTexture = DownloadHandlerTexture.GetContent(www);
		scimg.texture = myTexture;
	}

	public void DownloadSceneImages(FavoriteList[] lists){
		Debug.Log("LISTS : " + JsonHelper.ArrayToJsonString<FavoriteList>(lists, true));
		foreach( FavoriteList list in lists)
		{
			Debug.Log("ITEMS : " + JsonHelper.ArrayToJsonString<FavoriteItem>(list.favoriteitem_set, true));

			foreach ( FavoriteItem item in list.favoriteitem_set)
			{
				Debug.Log(item);
				Debug.Log("IMAGES : " + JsonHelper.ArrayToJsonString<SceneImage>(item.sceneimage_set, true));

				foreach ( SceneImage img in item.sceneimage_set )
				{
					StartCoroutine(GetTexture(img));
				}
			}
		}

	}
/*   TEMP CODE    */

	// public void DownloadSceneImages2(SceneImage[] images){
	// 	foreach(SceneImage img in images)
	// 	{
	// 		Debug.Log("Scene Image : " + img);
	// 	}


	// }

	public void Get(){

		// We can add default request headers for all requests
		RestClient.DefaultRequestHeaders["Authorization"] = "Token "+loginToken.token;

		RequestHelper requestOptions = null;

		RestClient.GetArray<Brand>(basePath + "rest/Brands").Then(res => {
			this.LogMessage("Brandss", JsonHelper.ArrayToJsonString<Brand>(res, true));
			Brand.AddBrands(res);
		}).Catch(err => this.LogMessage("Get Brands : Error", err.Message));

		RestClient.GetArray<FavoriteList>(basePath + "rest/FavoriteList").Then(res => {
			// Debug.Log("RESPONSE : " + res );
			this.LogMessage("Favorite Lists", JsonHelper.ArrayToJsonString<FavoriteList>(res, true));
			DownloadSceneImages(res);
			PostFovuriteList(res);
		}).Catch(err => this.LogMessage("Favorite Lists : Error", err.Message));

		RestClient.GetArray<SceneImage>(basePath + "rest/SceneImage").Then(res => {
			this.LogMessage("Scene Image", JsonHelper.ArrayToJsonString<SceneImage>(res, true));
			// DownloadSceneImages2(res);
		}).Catch(err => this.LogMessage("Favorite Lists : Error", err.Message));

        // RestClient.GetArray<Size>(basePath + "rest/Sizes").Then(res => {
		// 	this.LogMessage("Sizes", JsonHelper.ArrayToJsonString<Size>(res, true));
		// 	Size.AddSizes(res);
		// }).Catch(err => this.LogMessage("Get Sizes : Error", err.Message));

        // RestClient.GetArray<Colour>(basePath + "rest/Colors").Then(res => {
		// 	this.LogMessage("Colors", JsonHelper.ArrayToJsonString<Colour>(res, true));
		// 	Colour.AddColors(res);
		// }).Catch(err => this.LogMessage("Get Colors : Error", err.Message));
     
		// RestClient.GetArray<Design>(basePath + "rest/Designs").Then(res => {
		// 	this.LogMessage("Designs", JsonHelper.ArrayToJsonString<Design>(res, true));
		// 	Design.AddDesigns(res);
		// }).Catch(err => this.LogMessage("Error", err.Message));


        // RestClient.GetArray<Collection>(basePath + "rest/Collections").Then(res => {
		// 	this.LogMessage("Collections", JsonHelper.ArrayToJsonString<Collection>(res, true));
		// 	Collection.AddCollections(res);
		// }).Catch(err => this.LogMessage("Error", err.Message));


		// RestClient.GetArray<Carpet>(basePath + "rest/Carpets").Then(res => {
		// 	this.LogMessage("Carpets", JsonHelper.ArrayToJsonString<Carpet>(res, true));
		// 	Carpet.ClearAndAddCarpets(res);

        //     // RugTileManager.Instance.ShowRugTiles(Carpet.CurrentCarpets);

		// }).Catch(err => this.LogMessage("Error", err.Message));

		// RestClient.GetArray<FloorType>(basePath + "rugviz/rest/FloorTypes").Then(res => {
		// 	this.LogMessage("Floor Types", JsonHelper.ArrayToJsonString<FloorType>(res, true));
		// 	FloorType.AddFloorTypes(res);
		// }).Catch(err => this.LogMessage("Error", err.Message));

        // RestClient.GetArray<FloorTexture>(basePath + "rugviz/rest/FloorTextures").Then(res => {
		// 	this.LogMessage("Floor Textures", JsonHelper.ArrayToJsonString<FloorTexture>(res, true));
		// 	FloorTexture.AddFloorTextures(res);

		// 	// FloorTileManager.Instance.ShowFloorTiles(FloorTexture.AllFloorTextures);
		// }).Catch(err => this.LogMessage("Error", err.Message));

		// RestClient.GetArray<EnvColor>(basePath + "rugviz/rest/EnvColors").Then(res => {
		// 	EnvColor.AddColors(res);
		// 	this.LogMessage("Env Colors", JsonHelper.ArrayToJsonString<EnvColor>(res, true));
		// 	// FloorTexture.AddFloorTextures(res);
		// 	// ColorTileManager.Instance.ShowColorTiles(EnvColor.AllColors);
		// 	// FloorTileManager.Instance.ShowFloorTiles(FloorTexture.AllFloorTextures);
		// }).Catch(err => Debug.Log(err));
	}

}
