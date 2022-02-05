using System;
using System.Collections.Generic;
using UnityEngine;
 
namespace Models
{
    [Serializable]
    public class Carpet{
        public int id;
        public int design;
        public int color;
        public int size;
        public int inventory;
        public string image_file;

        public Texture texture;
        public static Dictionary<int, Carpet> CurrentCarpets;
        public static void ClearAndAddCarpets(Carpet[] carpets)
        {
            CurrentCarpets = new Dictionary<int, Carpet>();

            foreach(Carpet carpet in carpets){
                CurrentCarpets.Add(carpet.id, carpet);
            }
        }

        public string GetDesignName(){
            string designName =  Design.AllDesigns[design].name;
            return designName;
        }

        public string GetSize(){
            // string 
            return "NOT IMPLEMETED";
        }

        public string GetColor(){
            return "NOT IMPLEMETED";

        }
    }
}