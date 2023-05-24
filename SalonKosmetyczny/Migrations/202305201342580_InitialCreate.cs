namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wizytas", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "GodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "GodzinaZakonczenia", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Klients", "NumerTelefonu", c => c.String(nullable: false));
            DropColumn("dbo.Wizytas", "DataGodzinaRozpoczecia");
            DropColumn("dbo.Wizytas", "DataGodzinaZakonczenia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wizytas", "DataGodzinaZakonczenia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wizytas", "DataGodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Klients", "NumerTelefonu", c => c.String());
            DropColumn("dbo.Wizytas", "GodzinaZakonczenia");
            DropColumn("dbo.Wizytas", "GodzinaRozpoczecia");
            DropColumn("dbo.Wizytas", "Data");
        }
    }
}
