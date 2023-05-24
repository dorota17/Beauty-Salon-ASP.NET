namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CzasWizyty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wizytas", "DataGodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "DataGodzinaZakonczenia", c => c.DateTime(nullable: false));
            DropColumn("dbo.Wizytas", "DataGodzina");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wizytas", "DataGodzina", c => c.DateTime(nullable: false));
            DropColumn("dbo.Wizytas", "DataGodzinaZakonczenia");
            DropColumn("dbo.Wizytas", "DataGodzinaRozpoczecia");
        }
    }
}
