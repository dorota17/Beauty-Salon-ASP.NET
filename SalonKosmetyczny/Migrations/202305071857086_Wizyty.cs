namespace SalonKosmetyczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wizyty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zabiegs", "Pracownik_PracownikId", "dbo.Pracowniks");
            DropIndex("dbo.Zabiegs", new[] { "Pracownik_PracownikId" });
            CreateTable(
                "dbo.Wizytas",
                c => new
                    {
                        WizytaID = c.Int(nullable: false, identity: true),
                        DataGodzina = c.DateTime(nullable: false),
                        KlientID = c.Int(nullable: false),
                        PracownikID = c.Int(nullable: false),
                        ZabiegID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WizytaID)
                .ForeignKey("dbo.Klients", t => t.KlientID, cascadeDelete: true)
                .ForeignKey("dbo.Pracowniks", t => t.PracownikID, cascadeDelete: true)
                .ForeignKey("dbo.Zabiegs", t => t.ZabiegID, cascadeDelete: true)
                .Index(t => t.KlientID)
                .Index(t => t.PracownikID)
                .Index(t => t.ZabiegID);
            
            DropColumn("dbo.Zabiegs", "Pracownik_PracownikId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zabiegs", "Pracownik_PracownikId", c => c.Int());
            DropForeignKey("dbo.Wizytas", "ZabiegID", "dbo.Zabiegs");
            DropForeignKey("dbo.Wizytas", "PracownikID", "dbo.Pracowniks");
            DropForeignKey("dbo.Wizytas", "KlientID", "dbo.Klients");
            DropIndex("dbo.Wizytas", new[] { "ZabiegID" });
            DropIndex("dbo.Wizytas", new[] { "PracownikID" });
            DropIndex("dbo.Wizytas", new[] { "KlientID" });
            DropTable("dbo.Wizytas");
            CreateIndex("dbo.Zabiegs", "Pracownik_PracownikId");
            AddForeignKey("dbo.Zabiegs", "Pracownik_PracownikId", "dbo.Pracowniks", "PracownikId");
        }
    }
}
