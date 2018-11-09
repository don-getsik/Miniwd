using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miniwd.Models
{
    public class Flat
    {
        public string KindOfOperation { get; set; } //Czy kupno czy wynajem
        public string KindOfSpace { get; set; } //Czy pokój czy mieszkanie
        public int RoomsAmount { get; set; } //Liczba pokoi
        public int BathroomsAmount { get; set; } //Liczba łazienek


    }
}