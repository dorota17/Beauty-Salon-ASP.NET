using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace SalonKosmetyczny.Models.DbModels
{
    public class Wizyta
    {
        public int WizytaID { get; set; }
        [Display(Name = "Data i Godzina Rozpoczęcia")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DataGodzinaRozpoczecia { get; set; }
        [Display(Name = "Data i Godzina Zakończenia")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DataGodzinaZakonczenia { get; set; }


        //Właściwości do nawigacji
        public int KlientID { get; set; }
        public virtual Klient Klient { get; set; }
        public int PracownikID { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public int ZabiegID { get; set; }
        public virtual Zabieg Zabieg { get; set; }
        

        public Wizyta() { }

        public Wizyta(int wizytaID, DateTime godzinaRozpoczecia)
        {
            WizytaID = wizytaID;
            DataGodzinaRozpoczecia = godzinaRozpoczecia;
            DataGodzinaZakonczenia = godzinaRozpoczecia.AddMinutes(Zabieg.CzasTrwaniaMin);
        }
    }
}