using Smart_House.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House.Model.Classes
{
    public class Fridge : Device, iVolume, iPower, iFreeze
    {
        private Freeze moroz;

        public Fridge(string name, string funct, int volume)
            : base(name, funct)
        {
            this.Volume = volume;
            
        }

        public void creatFreze()
        {
            if(moroz == null)
            moroz = new Freeze(Name, Funct, -12); 
        }

        public bool Power { set; get; }
        private int volume;
        public int Volume
        {
            set
            {
                if (value >= 3 && value <= 10)
                    volume = value;
            }
            get
            {
                return this.volume;
            }
        }
        public int Moroz
        {
            get
            {
                return moroz.Volume;
            }
            set
            {
                moroz.Volume = value;
            }
        }
    }
}