using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miniwd.Models
{
    public class Flat
    {
        [Required(ErrorMessage = "Prosze podać typ oferty")]
        public string KindOfOperation { get; set; } //Czy kupno czy wynajem
        [Required(ErrorMessage = "Proszę podać typ nieruchomości")]
        public string KindOfSpace { get; set; } //Czy pokój czy mieszkanie
        [Required(ErrorMessage = "Proszę podac liczbę pokoi")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podac liczbe pokoi większą niż 1")]
        public int RoomsAmount { get; set; } //Liczba pokoi
        [Required(ErrorMessage = "Prosze podać liczbę łazienek")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać liczbę łazienek większą niż 1")]
        public int BathroomsAmount { get; set; } //Liczba łazienek
        //public string IsGoodLocation { get; set; } //Dobra lokalizacja
        [Required(ErrorMessage ="Prosze podać ocenę lokalizacji")]
        public int LocationRating { get; set; } // Ocena lokalizacji
        [Required(ErrorMessage ="Proszę podać metraż")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać metraż większy niż 1")]
        public double Size { get; set; } //Metraż
        [Required(ErrorMessage = "Prosze podać cenę")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podac cenę większą niż 1zł")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } //Cena
        [Required(ErrorMessage = "Proszę podać standard pokoju/mieszkania")]
        public int Standard { get; set; } //Standard mieszkania
        [Required(ErrorMessage = "Prosze podać piętro")]
        [Range(0, int.MaxValue, ErrorMessage = "Proszę podać piętro większe niż 0")]
        public int Floor { get; set; } //Piętro
        public bool IsGoodOfert { get; set; } //Czy oferta jest dobra (by Python)

    }
}