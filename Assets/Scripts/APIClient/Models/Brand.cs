using System;
using System.Collections.Generic;

namespace Models
{   
    [Serializable]
    public class Brand{
        public int id;
        public string name;
        public string website;

        public static Dictionary<int, Brand> AllBrands;
        public static void AddBrands(Brand[] brands)
        {
            if(AllBrands == null){
                AllBrands = new Dictionary<int, Brand>();

            }
            foreach(Brand brand in brands){
                AllBrands.Add(brand.id, brand);
            }
        }

        

    }

}