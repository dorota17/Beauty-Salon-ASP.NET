using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;

namespace SalonKosmetyczny.Models.DbModels
{
    public class Klient
    {
        public int KlientId { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string ImieKlienta { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string NazwiskoKlienta { get; set; }
        [Required]
        [Display(Name = "Numer Telefonu")]
        public string NumerTelefonu { get; set; }
        [Display(Name = "Klient")]
        public string DaneKlienta => KlientId.ToString() + " " + ImieKlienta + " " + NazwiskoKlienta;

        //Właściwości do nawigacji
        public List<Wizyta> Wizyty { get; set; }

        public Klient() { }

        public Klient(int klientId, string imieKlienta, string nazwiskoKlienta, string numerTelefonu)
        {
            KlientId = klientId;
            ImieKlienta = imieKlienta;
            NazwiskoKlienta = nazwiskoKlienta;
            NumerTelefonu = numerTelefonu;
        }
    }
}