using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{   
    [Serializable]
    public class EnvColor{
        public int id;

        public string color;

        public Color texColor;
        public string name;


        public static Dictionary<int, EnvColor> AllColors;
        public static void AddColors(EnvColor[] colors)
        {
            if(AllColors == null){
                AllColors = new Dictionary<int, EnvColor>();

            }
            foreach(EnvColor color in colors){
                color.Parse();
                AllColors.Add(color.id, color);
            }
        }

        public void Parse(){
            ColorUtility.TryParseHtmlString(color,out texColor);
        }
        

    }

}