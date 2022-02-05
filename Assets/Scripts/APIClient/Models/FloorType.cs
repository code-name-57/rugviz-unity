using System;
using System.Collections.Generic;

namespace Models
{   
    [Serializable]
    public class FloorType{
        public int id;
        public string name;
        
        public static Dictionary<int, FloorType> AllFloorTypes;
        public static void AddFloorTypes(FloorType[] floorTypes)
        {
            if(AllFloorTypes == null){
                AllFloorTypes = new Dictionary<int, FloorType>();

            }
            foreach(FloorType floorType in floorTypes){
                AllFloorTypes.Add(floorType.id, floorType);
            }
        }

        

    }

}