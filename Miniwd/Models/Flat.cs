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

        //public string UserKindOfOperation { get; set; } //Czy kupno czy wynajem - decyzja użytkownika

        [Required(ErrorMessage = "Proszę podać typ nieruchomości")]
        public string KindOfSpace { get; set; } //Czy pokój czy mieszkanie

        //public string UserKindOfSpace { get; set; } //Czy pokój czy mieszkanie - decyzja użytkownika

        [Required(ErrorMessage = "Proszę podać liczbę pokoi z oferty")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać liczbę pokoi z oferty większą niż 1")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Nieprawidłowa liczba pokoi z oferty")]
        public int RoomsAmount { get; set; } //Liczba pokoi

        [Required(ErrorMessage = "Prosze podać liczbę łazienek")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać liczbę łazienek większą niż 1")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nieprawidłowa liczba łazienek")]
        public int BathroomsAmount { get; set; } //Liczba łazienek

        //public string IsGoodLocation { get; set; } //Dobra lokalizacja

        [Required(ErrorMessage ="Prosze wybrać ocenę lokalizacji mieszkania/pokoju z oferty")]
        public int LocationRating { get; set; } // Ocena lokalizacji

        [Required(ErrorMessage ="Proszę podać metraż")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać metraż większy niż 1")]
        [RegularExpression("(^[0-9]*$)|(^[0-9]*,[0-9]{1,2}$)", ErrorMessage = "Nieprawidłowy metraż z oferty")]
        public double Size { get; set; } //Metraż

        [Required(ErrorMessage = "Prosze podać cenę z oferty")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podac preferowaną cenę większą niż 1zł")]
        [RegularExpression("(^[0-9]*$)|(^[0-9]*,[0-9]{1,2}$)", ErrorMessage = "Nieprawidłowa cena z oferty")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } //Cena

        [Required(ErrorMessage = "Proszę wybrać standard pokoju/mieszkania z oferty")]
        public int Standard { get; set; } //Standard mieszkania

        [Required(ErrorMessage = "Prosze podać piętro")]
        [Range(0, int.MaxValue, ErrorMessage = "Proszę podać piętro większe niż 0")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nieprawidłowe piętro")]
        public int Floor { get; set; } //Piętro

        [Required(ErrorMessage = "Proszę wybrać miejscowość")]
        public string City { get; set; } // Miejscowość

        [Required(ErrorMessage = "Proszę podać preferowaną liczbę pokoi")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podać preferowaną liczbę pokoi większą niż 1")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nieprawidłowa preferowana liczba pokoi")]
        public int UserRoomsAmount { get; set; } //Liczba pokoi które chce użytkownika

        [Required(ErrorMessage = "Prosze podać preferowaną cenę")]
        [Range(1, int.MaxValue, ErrorMessage = "Proszę podac preferowaną cenę większą niż 1zł")]
        [RegularExpression("(^[0-9]*$)|(^[0-9]*,[0-9]{1,2}$)", ErrorMessage = "Nieprawidłowa preferowana cena")]
        [DataType(DataType.Currency)]
        public decimal UserPrice { get; set; } //Cena która interesuje użytkownika

        [Required(ErrorMessage = "Proszę podać preferowany standard pokoju/mieszkania")]
        public int UserStandard { get; set; } //Standard mieszkania który chce użytkownik

        [Required(ErrorMessage = "Prosze podać preferowaną ocenę lokalizacji mieszkania/pokoju")]
        public int UserLocationRating { get; set; } // Ocena lokalizacji, którą chce użytkownik

        public bool IsGoodOfert { get; set; } //Czy oferta jest dobra (by Python)
    }
}