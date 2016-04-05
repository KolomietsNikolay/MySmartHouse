using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart_House.Model.Interfaces;

namespace Smart_House.Model.Classes
{
    public class Light:Device,iPower,iVolume
    {
        //
        public Light(string name, string funct, int volume)
            : base(name, funct)
        {
            Volume = volume;
        }

        public bool Power { set; get; }
        private int volume;
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if(value>=0 && value<=100)
                volume = value;   
            }
            
        }
    }
}