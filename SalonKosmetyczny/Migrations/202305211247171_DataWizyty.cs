namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataWizyty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wizytas", "DataGodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "DataGodzinaZakonczenia", c => c.DateTime(nullable: false));
            DropColumn("dbo.Wizytas", "Data");
            DropColumn("dbo.Wizytas", "GodzinaRozpoczecia");
            DropColumn("dbo.Wizytas", "GodzinaZakonczenia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wizytas", "GodzinaZakonczenia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "GodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Wizytas", "DataGodzinaZakonczenia");
            DropColumn("dbo.Wizytas", "DataGodzinaRozpoczecia");
        }
    }
}
