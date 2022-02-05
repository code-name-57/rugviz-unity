using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{   
    [Serializable]
    public class FloorTexture{
        public int id;
        public string name;
        public int type;
        public string image_file;

        public Texture texture;
        public static Dictionary<int, FloorTexture> AllFloorTextures;
        public static void AddFloorTextures(FloorTexture[] floorTextures)
        {
            if(AllFloorTextures == null){
                AllFloorTextures = new Dictionary<int, FloorTexture>();

            }
            foreach(FloorTexture floorTexture in floorTextures){
                AllFloorTextures.Add(floorTexture.id, floorTexture);
            }
        }

        

    }

}