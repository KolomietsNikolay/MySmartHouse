using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart_House.Model.Classes;
using Smart_House.Model.Interfaces;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Smart_House.Control
{


    public class ControlDevice : Panel
    {
        private IDictionary<int, Device> Devices;
        private int ID;
        private bool post;
        //private Label nameLabel;
        private Image img;
        private ImageButton power;
        private Button plus;
        private Button minus;
        private Button plusFreeze;
        private Button minusFreeze;
        private Label stan;
        private Label volume;
        private ImageButton delete;
        private TextBox name;
        private Button savename;
        private Label head;
        private Label volumeFreeze;
        private Image imgF;


        public bool Post { get; set; }

        public ControlDevice(int id, IDictionary<int, Device> dv)
        {
            this.ID = id;
            Devices = dv;
            Initializer();
        }

        private void Initializer()
        {
            CssClass = "figure-div";
            name = new TextBox();
            head = new Label();
            if (name.Visible)
            {
                name.Text = Devices[ID].Name + ID.ToString();
            }
            name.Width = 150;
            head.Text = "Устройство: ";

            Controls.Add(head);

            savename = new Button();
            savename.ID = ID.ToString() + "save";
            savename.Text = "Создать!";
            savename.Click += savename_Click;
            Controls.Add(name);
            Controls.Add(savename);
            PlaceHolder gd;
            gd = new PlaceHolder();

            Controls.Add(br());



            //ICloses
            if (Devices[ID] is iClouses)
            {

                img = new Image();
                img.AlternateText = "Дверь";
                img.ID = "img" + ID.ToString();

                power = new ImageButton();
                power.ToolTip = Devices[ID].Funct;
                power.ID = "power" + ID.ToString();
                power.Click += power_Click1;
                stan = new Label();
                if (!((iClouses)(Devices[ID])).Clouses)
                {
                    img.ImageUrl = "~/Content/closeDoor.jpg";
                    power.ImageUrl = "~/Content/close.png";
                    stan.Text = "Закрыто!";
                }
                else
                {
                    img.ImageUrl = "~/Content/openDoor.jpg";
                    power.ImageUrl = "~/Content/open.png";
                    stan.Text = "Открыто!";
                }


                Controls.Add(img);
                Controls.Add(addP(""));



                Controls.Add(power);
                Controls.Add(addP(""));



                Controls.Add(stan);
            }
            #region TV ivolume ipower ichanel
            if (Devices[ID] is iPower && Devices[ID] is iVolume && Devices[ID] is iChanels)
            {
                img = new Image();
                img.AlternateText = "Телевизор";
                img.ID = "img" + ID.ToString();
                img.ImageUrl = "~/Content/tv.jpg";

                power = new ImageButton();
                power.ToolTip = Devices[ID].Funct;
                power.ID = "power" + ID.ToString();
                power.Click += power_ClickTv;
                power.ImageUrl = "~/Content/powerClick.jpg";
                stan = new Label();
                if (((iPower)(Devices[ID])).Power)
                {


                    img.ImageUrl = "~/Content/tvOn.png";
                    stan.Text = "Включен!";
                }
                else
                {

                    img.ImageUrl = "~/Content/tv.jpg";
                    stan.Text = "Выключен!";
                }


                Controls.Add(img);

                plusFreeze = new Button();

                plus = new Button();
                plus.ID = "plus" + ID.ToString();
                plus.Text = "V+";
                plus.Click += plus_ClickTVVolume;
                //power.Click += plus_Click;
                minus = new Button();
                minus.ID = "minus" + ID.ToString();
                minus.Text = "V-";
                minus.Click += minus_ClickTVVolume;
                volume = new Label();
                volume.ID = "label" + ID.ToString();
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString();



                plusFreeze.ID = "plusFreeze" + ID.ToString();
                plusFreeze.Text = "P+";
                plusFreeze.Click += plus_ClickTVCh;
                //power.Click += plus_Click;
                minusFreeze = new Button();
                minusFreeze.ID = "minusFreeze" + ID.ToString();
                minusFreeze.Text = "P-";
                minusFreeze.Click += minus_ClickTVCh;
                volumeFreeze = new Label();
                volumeFreeze.ID = "labelTV" + ID.ToString();
                volumeFreeze.Text = ((TV)Devices[ID]).ChanelName();

                Controls.Add(minus);
                Controls.Add(volume);
                Controls.Add(plus);

                Controls.Add(br());
                Controls.Add(power);

                Controls.Add(minusFreeze);
                Controls.Add(volumeFreeze);
                Controls.Add(plusFreeze);

                Controls.Add(addP(""));



                Controls.Add(stan);


                minus.Visible = false;
                plus.Visible = false;
                volume.Text = "";

                minusFreeze.Visible = false;
                plusFreeze.Visible = false;
                volumeFreeze.Text = "";
            }
            else

            #endregion
                #region Fridge Ivolume Ipower IFrezee

                if (Devices[ID] is iPower && Devices[ID] is iVolume && Devices[ID] is iFreeze)
                {
                    ((Fridge)Devices[ID]).creatFreze();
                    img = new Image();
                    img.AlternateText = "Холодильник";
                    img.ID = "img" + ID.ToString();
                    img.ImageUrl = "~/Content/fridge1.jpg";
                    power = new ImageButton();
                    power.ToolTip = Devices[ID].Funct;
                    power.ID = "power" + ID.ToString();
                    power.Click += power_Click3;
                    stan = new Label();
                    if (((iPower)(Devices[ID])).Power)
                    {

                        power.ImageUrl = "~/Content/onFridge.png";
                        stan.Text = "Включен!";
                    }
                    else
                    {
                        power.ImageUrl = "~/Content/offFridge.png";
                        stan.Text = "Выключен!";
                    }


                    Controls.Add(img);

                    plusFreeze = new Button();

                    plus = new Button();
                    plus.ID = "plus" + ID.ToString();
                    plus.Text = "+";
                    plus.Click += plus_Click;
                    //power.Click += plus_Click;
                    minus = new Button();
                    minus.ID = "minus" + ID.ToString();
                    minus.Text = "-";
                    minus.Click += minus_Click;
                    volume = new Label();
                    volume.ID = "label" + ID.ToString();
                    volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

                    imgF = new Image();
                    imgF.ID = ID.ToString() + "Freeze";
                    imgF.AlternateText = "Freeze";
                    imgF.ImageUrl = "~/Content/morozilka.png";

                    plusFreeze.ID = "plusFreeze" + ID.ToString();
                    plusFreeze.Text = "+";
                    plusFreeze.Click += plus_ClickFreeze;
                    //power.Click += plus_Click;
                    minusFreeze = new Button();
                    minusFreeze.ID = "minusFreeze" + ID.ToString();
                    minusFreeze.Text = "-";
                    minusFreeze.Click += minus_ClickFreeze;
                    volumeFreeze = new Label();
                    volumeFreeze.ID = "labelFreeze" + ID.ToString();
                    volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString();

                    Controls.Add(minus);
                    Controls.Add(volume);
                    Controls.Add(plus);

                    gd.ID = ID.ToString();
                    Controls.Add(gd);
                    Controls.Add(addP(""));

                    Controls.Add(imgF);
                    Controls.Add(minusFreeze);
                    Controls.Add(volumeFreeze);
                    Controls.Add(plusFreeze);

                    Controls.Add(addP(""));

                    Controls.Add(power);
                    Controls.Add(addP(""));



                    Controls.Add(stan);


                    minus.Visible = false;
                    plus.Visible = false;
                    volume.Text = "";

                    minusFreeze.Visible = false;
                    plusFreeze.Visible = false;
                    volumeFreeze.Text = "";
                }
                else
                #endregion
                    #region  IPOWER and IVOLUME for Light
                    if (Devices[ID] is iPower && Devices[ID] is iVolume)
                    {
                        img = new Image();
                        power = new ImageButton();
                        img.AlternateText = "Лампочка";
                        stan = new Label();

                        if (!((iPower)Devices[ID]).Power)
                        {
                            img.ImageUrl = "~/Content/offLight.png";
                            power.ImageUrl = "~/Content/off.png";
                            stan.Text = "Выключено!";
                        }
                        else
                        {
                            int p = ((iVolume)Devices[ID]).Volume;
                            if (p >= 40 && p < 90)
                            {
                                img.ImageUrl = "~/Content/onLight1.png";
                            }
                            else if (p < 40)
                            {
                                img.ImageUrl = "~/Content/onLight2.png";
                            }
                            else if (p >= 90)
                            {
                                img.ImageUrl = "~/Content/onLight.png";
                            }
                            power.ImageUrl = "~/Content/on.jpg";
                            stan.Text = "Включено!";
                        }
                        Controls.Add(img);

                        gd.ID = ID.ToString();
                        Controls.Add(gd);
                        Controls.Add(addP(""));

                        power.ID = "power" + ID.ToString();
                        power.ToolTip = Devices[ID].Funct;
                        power.Click += power_Click2;
                        Controls.Add(power);
                        Controls.Add(addP(""));


                        Controls.Add(stan);

                        plus = new Button();
                        plus.ID = "plus" + ID.ToString();
                        plus.Text = "+";
                        plus.Click += plus_Click;
                        //power.Click += plus_Click;
                        minus = new Button();
                        minus.ID = "minus" + ID.ToString();
                        minus.Text = "-";
                        minus.Click += minus_Click;
                        volume = new Label();
                        volume.ID = "label" + ID.ToString();
                        volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

                        gd.Controls.Add(minus);
                        gd.Controls.Add(volume);
                        gd.Controls.Add(plus);

                        minus.Visible = false;
                        plus.Visible = false;
                        volume.Text = "";
                        // Controls.Add(plus);
                        //Controls.Add(minus);
                    }
                    #endregion


            Controls.Add(hr());

            delete = new ImageButton();
            delete.ID = "delete" + ID.ToString();
            delete.ImageUrl = "~/Content/del.png";
            delete.ToolTip = "Удалить устройство";
            delete.AlternateText = "Delete";
            delete.Click += delete_Click;
            Controls.Add(delete);



            power.Visible = false;

            //delete.Visible = false;


            if (Devices[ID].Name != "Door" && Devices[ID].Name != "Light" && Devices[ID].Name != "Fridge" && Devices[ID].Name != "TV")
            {
                refresch();
            }
            else
            {

            }

        }

        private void minus_ClickTVCh(object sender, EventArgs e)
        {
            ((iChanels)Devices[ID]).chanelBack();
            volumeFreeze.Text = ((TV)Devices[ID]).ChanelName();
        }

        private void plus_ClickTVCh(object sender, EventArgs e)
        {
            ((iChanels)Devices[ID]).chanelNext();
            volumeFreeze.Text = ((TV)Devices[ID]).ChanelName();
        }

        private void power_ClickTv(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (((iPower)(Devices[ID])).Power)
            {
                ((iPower)(Devices[ID])).Power = false;
                img.ImageUrl = "~/Content/tv.jpg";
                stan.Text = "Выключено!";

                minus.Visible = false;
                plus.Visible = false;
                volume.Text = "";

                minusFreeze.Visible = false;
                plusFreeze.Visible = false;
                volumeFreeze.Text = "";
            }
            else
            {
                ((iPower)(Devices[ID])).Power = true;
                img.ImageUrl = "~/Content/tvOn.png";
                stan.Text = "Включено!";

                minus.Visible = true;
                plus.Visible = true;
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

                minusFreeze.Visible = true;
                plusFreeze.Visible = true;
                volumeFreeze.Text = ((TV)Devices[ID]).ChanelName();
            }
        }

        private void minus_ClickTVVolume(object sender, EventArgs e)
        {

            ((iVolume)Devices[ID]).Volume -= 10;
            volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

        }

        private void plus_ClickTVVolume(object sender, EventArgs e)
        {
            ((iVolume)Devices[ID]).Volume += 10;
            volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
        }




        void savename_Click(object sender = null, EventArgs e = null)
        {
            if (name.Text == "Door" && name.Text == "Light" && name.Text == "Fridge" && name.Text == "TV") return;

            name.Visible = false;
            savename.Visible = false;

            Devices[ID].Name = name.Text;

            head.Text += name.Text;
            name.Text = "";
            power.Visible = true;
            if (Devices[ID] is iVolume)
            {
                if ((!(Devices[ID] is iChanels) || ((iPower)(Devices[ID])).Power) && !(Devices[ID] is iFreeze))
                {
                    minus.Visible = true;
                    plus.Visible = true;
                    volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
                }
                if (Devices[ID] is iFreeze && ((iPower)(Devices[ID])).Power)
                {
                    minus.Visible = true;
                    plus.Visible = true;
                    volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

                    volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString() + "°C";
                    minusFreeze.Visible = true;
                    plusFreeze.Visible = true;
                    volume.Text += "°C";

                }
            }
            delete.Visible = true;
        }

        void refresch()
        {
            {
                name.Visible = false;
                savename.Visible = false;

                head.Text = "Устройство: " + Devices[ID].Name;


                power.Visible = true;
                if (Devices[ID] is iVolume)
                {
                    if( (!(Devices[ID] is iChanels) || ((iPower)(Devices[ID])).Power) && !(Devices[ID] is iFreeze))
                    {
                        minus.Visible = true;
                        plus.Visible = true;
                        volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
                    }
                    if (Devices[ID] is iFreeze && ((iPower)(Devices[ID])).Power)
                    {
                        minus.Visible = true;
                        plus.Visible = true;
                        volume.Text = ((iVolume)Devices[ID]).Volume.ToString();

                        volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString() + "°C";
                        minusFreeze.Visible = true;
                        plusFreeze.Visible = true;
                        volume.Text += "°C";

                    }else if(Devices[ID] is iChanels)
                    {
                        volumeFreeze.Text = ((TV)Devices[ID]).ChanelName();
                        minusFreeze.Visible = true;
                        plusFreeze.Visible = true;
                    }
                }
                delete.Visible = true;
            }
        }

        //Buutons on PANELS
        void delete_Click(object sender, EventArgs e)
        {
            Devices.Remove(ID);
            Parent.Controls.Remove(this);
        }

        void minus_Click(object sender, EventArgs e)
        {
            if (Devices[ID] is iFreeze)
            {
                ((iVolume)Devices[ID]).Volume -= 1;
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString() + "°C";
                return;
            }


            ((iVolume)Devices[ID]).Volume -= 10;
            int p = ((iVolume)Devices[ID]).Volume;
            if (p == 0)
            {
                ((iPower)(Devices[ID])).Power = false;
                img.ImageUrl = "~/Content/offLight.png";
                power.ImageUrl = "~/Content/off.png";
                stan.Text = "Выключено!";
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
                return;

            }

            volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
            if (((iPower)(Devices[ID])).Power)
            {
                if (p > 40 && p < 90)
                {
                    img.ImageUrl = "~/Content/onLight1.png";
                }
                else if (p < 40)
                {
                    img.ImageUrl = "~/Content/onLight2.png";
                }
                else if (p > 90)
                {
                    img.ImageUrl = "~/Content/onLight.png";
                }
            }
        }

        void plus_Click(object sender = null, EventArgs e = null)
        {

            if (Devices[ID] is iFreeze)
            {
                ((iVolume)Devices[ID]).Volume += 1;
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString() + "°C";
                return;
            }

            int p;

            ((iVolume)Devices[ID]).Volume += 10;
            p = ((iVolume)Devices[ID]).Volume;
            volume.Text = ((iVolume)Devices[ID]).Volume.ToString();
            if (((iPower)(Devices[ID])).Power)
            {
                if (p >= 30 && p <= 80)
                {
                    img.ImageUrl = "~/Content/onLight1.png";
                }
                else if (p < 30)
                {
                    img.ImageUrl = "~/Content/onLight2.png";
                }
                else if (p > 80)
                {
                    img.ImageUrl = "~/Content/onLight.png";
                }
                if (p == 100)
                {
                    img.ImageUrl = "~/Content/onLight.png";
                }
            }
        }
        //Powers tymler for Light
        private void power_Click2(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (((iPower)(Devices[ID])).Power)
            {
                ((iPower)(Devices[ID])).Power = false;
                img.ImageUrl = "~/Content/offLight.png";
                power.ImageUrl = "~/Content/off.png";
                stan.Text = "Выключено!";

            }
            else
            {
                ((iPower)(Devices[ID])).Power = true;
                power.ImageUrl = "~/Content/on.jpg";
                stan.Text = "Включено!";
                if (Devices[ID] is iVolume)
                {
                    if (((iVolume)Devices[ID]).Volume != 0)
                    {
                        ((iVolume)Devices[ID]).Volume -= 10;
                    }
                    plus_Click(sender, e);
                }
            }

        }
        //Powers click for DOOR
        void power_Click1(object sender, EventArgs e)
        {
            if (((iClouses)(Devices[ID])).Clouses)
            {
                ((iClouses)(Devices[ID])).Clouses = false;
                power.ImageUrl = "~/Content/close.png";
                img.ImageUrl = "~/Content/closeDoor.jpg";
                stan.Text = "Закрыто!";

            }
            else
            {
                ((iClouses)(Devices[ID])).Clouses = true;
                power.ImageUrl = "~/Content/open.png";
                img.ImageUrl = "~/Content/openDoor.jpg";
                stan.Text = "Открыто!";
            }
        }
        // Powers click for Fridge
        void power_Click3(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (((iPower)(Devices[ID])).Power)
            {
                ((iPower)(Devices[ID])).Power = false;
                power.ImageUrl = "~/Content/offFridge.png";

                stan.Text = "Выключено!";


                minus.Visible = false;
                plus.Visible = false;
                volume.Text = "";

                minusFreeze.Visible = false;
                plusFreeze.Visible = false;
                volumeFreeze.Text = "";
            }
            else
            {
                ((iPower)(Devices[ID])).Power = true;
                power.ImageUrl = "~/Content/onFridge.png";
                stan.Text = "Включено!";


                minus.Visible = true;
                plus.Visible = true;
                volume.Text = ((iVolume)Devices[ID]).Volume.ToString() + "°C";

                minusFreeze.Visible = true;
                plusFreeze.Visible = true;
                volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString() + "°C";
            }
        }


        private void plus_ClickFreeze(object sender, EventArgs e)
        {
            if (Devices[ID] is iFreeze)
            {
                ((Fridge)Devices[ID]).Moroz += 6;
                volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString() + "°C";
                return;
            }
        }



        private void minus_ClickFreeze(object sender, EventArgs e)
        {
            if (Devices[ID] is iFreeze)
            {
                ((Fridge)Devices[ID]).Moroz -= 6;
                volumeFreeze.Text = ((Fridge)Devices[ID]).Moroz.ToString() + "°C";
                return;
            }
        }

        protected HtmlGenericControl addP(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("p1");
            span.InnerHtml = innerHTML + "<br/>";
            return span;
        }


        public HtmlGenericControl br()
        {
            HtmlGenericControl span = new HtmlGenericControl("p1");
            span.InnerHtml = "<br/>";
            return span;
        }

        public HtmlGenericControl hr()
        {
            HtmlGenericControl span = new HtmlGenericControl("p1");
            span.InnerHtml = "<hr/>";
            return span;
        }

    }
}