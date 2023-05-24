namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Harmonograms",
                c => new
                    {
                        HarmonogramID = c.Int(nullable: false, identity: true),
                        DataGodzina = c.DateTime(nullable: false),
                        KlientID = c.Int(nullable: false),
                        PracownikID = c.Int(nullable: false),
                        ZabiegID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HarmonogramID);
            
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        KlientId = c.Int(nullable: false, identity: true),
                        ImieKlienta = c.String(),
                        NazwiskoKlienta = c.String(),
                        NumerTelefonu = c.String(),
                    })
                .PrimaryKey(t => t.KlientId);
            
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        PracownikId = c.Int(nullable: false, identity: true),
                        ImiePracownika = c.String(),
                        NazwiskoPracownika = c.String(),
                    })
                .PrimaryKey(t => t.PracownikId);
            
            CreateTable(
                "dbo.Zabiegs",
                c => new
                    {
                        ZabiegID = c.Int(nullable: false, identity: true),
                        NazwaZabiegu = c.String(),
                        CzasTrwaniaMin = c.Int(nullable: false),
                        Cena = c.Single(nullable: false),
                        Pracownik_PracownikId = c.Int(),
                    })
                .PrimaryKey(t => t.ZabiegID)
                .ForeignKey("dbo.Pracowniks", t => t.Pracownik_PracownikId)
                .Index(t => t.Pracownik_PracownikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zabiegs", "Pracownik_PracownikId", "dbo.Pracowniks");
            DropIndex("dbo.Zabiegs", new[] { "Pracownik_PracownikId" });
            DropTable("dbo.Zabiegs");
            DropTable("dbo.Pracowniks");
            DropTable("dbo.Klients");
            DropTable("dbo.Harmonograms");
        }
    }
}
