using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonKosmetyczny.Models.DbModels
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Zabieg> zabiegi  = new List<Zabieg> ();

        Salon() { }
        public Salon(int id, string name, List<Zabieg> zabiegi)
        {
            Id = id;
            Name = name;
            this.zabiegi = zabiegi;
        }
    }
}