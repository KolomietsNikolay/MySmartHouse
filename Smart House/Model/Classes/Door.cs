using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart_House.Model.Interfaces;

namespace Smart_House.Model.Classes
{
    public class Door:Device,iClouses
    {
        public Door(string name, string funct)
            : base(name, funct)
        {

        }

        public bool Clouses
        {
            set;
            get;
        }
    }
}