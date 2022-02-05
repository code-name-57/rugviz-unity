using System;
using System.Collections.Generic;

namespace Models
{   
    
    [Serializable]
    public class Colour{
        public int id;
        public string primary_color;
        public string texture_color;

        public static Dictionary<int, Colour> AllColors;
        public static void AddColors(Colour[] colors)
        {
            if(AllColors == null){
                AllColors = new Dictionary<int, Colour>();

            }
            foreach(Colour color in colors){
                AllColors.Add(color.id, color);
            }
        }
    }

}