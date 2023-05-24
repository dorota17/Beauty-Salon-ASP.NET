using SalonKosmetyczny.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalonKosmetyczny.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("SalonKosmetycznyConnectionString")
        {

        }
        public DbSet<Zabieg> Zabiegi { get; set; }
        public DbSet <Pracownik> Pracownicy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }

    }
}