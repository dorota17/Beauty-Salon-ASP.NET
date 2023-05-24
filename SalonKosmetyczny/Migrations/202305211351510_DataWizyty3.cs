namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataWizyty3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wizytas", "DataGodzinaRozpoczecia", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Wizytas", "DataGodzinaZakonczenia", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wizytas", "DataGodzinaZakonczenia", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Wizytas", "DataGodzinaRozpoczecia", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
