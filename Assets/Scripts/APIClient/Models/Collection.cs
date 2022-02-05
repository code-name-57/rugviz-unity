using System;
using System.Collections.Generic;

namespace Models
{   
    [Serializable]
    public class Collection{
        public int id;
        public string name;
        public string description;
        public Brand brand;
        public int pile_count;
        public float pile_length;

        public static Dictionary<int, Collection> AllCollections;
        public static void AddCollections(Collection[] collections)
        {
            if(AllCollections == null){
                AllCollections = new Dictionary<int, Collection>();

            }
            foreach(Collection collection in collections){
                AllCollections.Add(collection.id, collection);
            }
        }
    }

}