using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miniwd.Models
{
    //Model formatki
    public class Flat
    {
        public string KindOfOperation { get; set; } //Czy kupno czy wynajem
        public string KindOfSpace { get; set; } //Czy pokój czy mieszkanie
        public int RoomsAmount { get; set; } //Liczba pokoi
        public int BathroomsAmount { get; set; } //Liczba łazienek
        //public string IsGoodLocation { get; set; } //Dobra lokalizacja
        public int LocationRating { get; set; } // Ocena lokalizacji
        public double Size { get; set; } //Metraż
        public decimal Price { get; set; } //Cena
        public int Standard { get; set; } //Standard mieszkania
        public int Floor { get; set; } //Piętro
    }
}