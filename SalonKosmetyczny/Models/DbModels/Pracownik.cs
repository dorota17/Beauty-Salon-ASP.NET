using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonKosmetyczny.Models.DbModels
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string ImiePracownika { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string NazwiskoPracownika { get; set; }
        [Display(Name = "Pracownik")]
        public string DanePracownika => PracownikId.ToString() + " " + ImiePracownika + " " + NazwiskoPracownika;


        //Właściwości do nawigacji
        public List<Wizyta> Wizyty { get; set; }

        public Pracownik() { }

        public Pracownik(int pracownikId, string imiePracownika, string nazwiskoPracownika, List<Zabieg> zabiegi)
        {
            PracownikId = pracownikId;
            ImiePracownika = imiePracownika;
            NazwiskoPracownika = nazwiskoPracownika;
        }
    }
}