using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;


namespace Models
{
    [Serializable]
    public class SceneImage
    {
        // public int id;
        public string image_file;

        public Texture texture;
        
    }

    [Serializable]
    public class FavoriteItem{
        // public int id;
        // public FavoriteList favorite_list;
        public Carpet carpet;
        public SceneImage[] sceneimage_set;
    }

    [Serializable]
    public class FavoriteList{
        // public int id;
        public string customer_name;
        public string customer_phone_number;
        public string email;
        public FavoriteItem[] favoriteitem_set;
    }

  

   




}