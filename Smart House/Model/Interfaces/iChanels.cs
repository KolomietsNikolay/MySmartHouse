﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Model.Interfaces
{
    interface iChanels
    {
         int Chanel { get; set; }
         void findChanel(string str);
         void chanelNext();
         void chanelBack();
    }
}
