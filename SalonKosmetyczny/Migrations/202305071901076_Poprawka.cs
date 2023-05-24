namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawka : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Harmonograms");
        }
        
        public override void Down()
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
            
        }
    }
}
