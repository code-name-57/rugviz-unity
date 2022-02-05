using System;
using System.Collections.Generic;

namespace Models
{   
    [Serializable]
    public class Design{
        public int id;
        public string name;
        public string description;
        public int collection;

        public static Dictionary<int, Design> AllDesigns;
        public static void AddDesigns(Design[] designs)
        {
            if(AllDesigns == null){
                AllDesigns = new Dictionary<int, Design>();

            }
            foreach(Design design in designs){
                AllDesigns.Add(design.id, design);
            }
        }
    }

}