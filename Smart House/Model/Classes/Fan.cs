using Smart_House.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_House.Model.Classes
{
    public class Fan:Device, iPower
    {
        public Fan(string name, string funct)
            : base(name, funct)
        {
            
        }


        public bool Power { set; get; }
        
    
    }
}