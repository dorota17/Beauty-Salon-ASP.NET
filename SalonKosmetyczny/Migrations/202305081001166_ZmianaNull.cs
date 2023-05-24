namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Klients", "ImieKlienta", c => c.String(nullable: false));
            AlterColumn("dbo.Klients", "NazwiskoKlienta", c => c.String(nullable: false));
            AlterColumn("dbo.Pracowniks", "ImiePracownika", c => c.String(nullable: false));
            AlterColumn("dbo.Pracowniks", "NazwiskoPracownika", c => c.String(nullable: false));
            AlterColumn("dbo.Zabiegs", "NazwaZabiegu", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zabiegs", "NazwaZabiegu", c => c.String());
            AlterColumn("dbo.Pracowniks", "NazwiskoPracownika", c => c.String());
            AlterColumn("dbo.Pracowniks", "ImiePracownika", c => c.String());
            AlterColumn("dbo.Klients", "NazwiskoKlienta", c => c.String());
            AlterColumn("dbo.Klients", "ImieKlienta", c => c.String());
        }
    }
}
