using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Smart_House.Model.Classes
{
    [Serializable]
    public abstract class Device
    {
        [XmlAttribute]
        public string Name { set; get; }
        public string Funct { set; get; }

        public Device(string name,string funct)
        {
            this.Name = name;
            this.Funct = funct;
        }

        public Device()
        {

        }

    }
}