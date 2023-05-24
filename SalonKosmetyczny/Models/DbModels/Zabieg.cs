using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonKosmetyczny.Models.DbModels
{
    
    public class Zabieg
    {
        public int ZabiegID { get; set; }
        [Required]
        [Display(Name = "Nazwa Zabiegu")]
        public string NazwaZabiegu { get; set; }
        [Display(Name = "Czas trwania [min]")]
        public int CzasTrwaniaMin { get; set; }
        [Display(Name = "Cena [zł]")]
        public float Cena { get; set; }

        //Właściwości do nawigacji
        public List<Wizyta> Wizyty { get; set; }

        public Zabieg() { }

        public Zabieg(int zabiegID, string nazwaZabiegu, int czasTrwania, float cena)
        {
            ZabiegID = zabiegID;
            NazwaZabiegu = nazwaZabiegu;
            CzasTrwaniaMin = czasTrwania;
            Cena = cena;
        }
    }
}