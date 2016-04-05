using Smart_House.Control;
using Smart_House.Model.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Smart_House
{
    public partial class Default : System.Web.UI.Page
    {
        private IDictionary<int, Device> Devices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || Session["devic"] != null)
            {
                Devices = (SortedDictionary<int, Device>)Session["devic"];
                Button1.Click += Button1_Click;
                Button2.Click += Button2_Click;
                Button5.Click += Button4_Click;
                Button4.Click += Button5_Click;

                Application["Dv" + Request.UserHostName.ToString()] = Devices;
                Application["id" + Request.UserHostName.ToString()] = Session["id"];
                Application["idSes"] = Request.UserHostName;
            }
            else if(Application["Dv"] == null)
            {
                
                Devices = new SortedDictionary<int, Device>();
                Devices.Add(1, new Door("Door", "Open/Close Door"));
                //Devices.Add(2, new Light("Light", "On/Off Light", 50));
                //Devices.Add(3, new Fridge("Fridge", "On/Off Fridging", 50));
                Session["devic"] = Devices;
                Session["id"] = 2;
            }
            else if(Application["idSes"] == Request.UserHostName)
            {
                Devices = (SortedDictionary<int, Device>)Application["Dv" + Request.UserHostName.ToString()];
                Button1.Click += Button1_Click;
                Button2.Click += Button2_Click;
                Button5.Click += Button4_Click;
                Button4.Click += Button5_Click;

                Session["devic"] = Devices;
                Session["id"] = Application["id" + Request.UserHostName.ToString()];
            }
            InitialiseFiguresPanel();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int key = (int)Session["id"];
            Devices.Add(key, new TV("TV", "TVing", 50));
            deviceHolder.Controls.Add(new ControlDevice(key, Devices));
            Session["id"] = key + 1;
        }

        void Button4_Click(object sender, EventArgs e)
        {
            int key = (int)Session["id"];
            Devices.Add(key, new Fridge("Fridge", "Fridging", 5));
            deviceHolder.Controls.Add(new ControlDevice(key, Devices));
            Session["id"] = key + 1;
        }

        void Button2_Click(object sender, EventArgs e)
        {
            int key = (int)Session["id"];
            Devices.Add(key, new Light("Light", "Lighting",50));
            deviceHolder.Controls.Add(new ControlDevice(key, Devices));
            Session["id"] = key + 1;
        }

        void Button1_Click(object sender, EventArgs e)
        {
            int key = (int)Session["id"];
            Devices.Add(key,new Door("Door","Open/Close"));
            deviceHolder.Controls.Add(new ControlDevice(key, Devices));
            Session["id"] = key + 1;
            
        }


        protected void InitialiseFiguresPanel()
        {

           

            foreach (int key in Devices.Keys)
            {
                deviceHolder.Controls.Add(new ControlDevice(key, Devices));  
            }

           
        }
    }
}