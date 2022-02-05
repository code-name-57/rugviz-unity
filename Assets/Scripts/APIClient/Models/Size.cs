using System;
using System.Collections.Generic;

namespace Models
{   
    [Serializable]
    public class Size{
        public int id;
        public string shape;
        public float length;
        public float width;

        public static Dictionary<int, Size> AllSizes;
        public static void AddSizes(Size[] sizes)
        {
            if(AllSizes == null){
                AllSizes = new Dictionary<int, Size>();

            }
            foreach(Size size in sizes){
                AllSizes.Add(size.id, size);
            }
        }

    }

}