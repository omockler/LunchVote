namespace LunchVote.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DiningOptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Votes = c.Int(nullable: false),
                        Location_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Days",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("DiningOptions", new[] { "Location_Id" });
            DropForeignKey("DiningOptions", "Location_Id", "Locations");
            DropTable("Days");
            DropTable("Locations");
            DropTable("DiningOptions");
        }
    }
}
