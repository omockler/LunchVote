namespace LunchVote.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Fix_DiningOption_Location_FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("DiningOptions", "Location_Id", "Locations");
            DropIndex("DiningOptions", new[] { "Location_Id" });
            RenameColumn(table: "DiningOptions", name: "Location_Id", newName: "LocationId");
            AddForeignKey("DiningOptions", "LocationId", "Locations", "Id", cascadeDelete: true);
            CreateIndex("DiningOptions", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("DiningOptions", new[] { "LocationId" });
            DropForeignKey("DiningOptions", "LocationId", "Locations");
            RenameColumn(table: "DiningOptions", name: "LocationId", newName: "Location_Id");
            CreateIndex("DiningOptions", "Location_Id");
            AddForeignKey("DiningOptions", "Location_Id", "Locations", "Id");
        }
    }
}
