namespace LunchVote.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Fix_DiningOption_Day_navigation_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("DiningOptions", "Day_Id", "Days");
            DropIndex("DiningOptions", new[] { "Day_Id" });
            RenameColumn(table: "DiningOptions", name: "Day_Id", newName: "DayId");
            AddForeignKey("DiningOptions", "DayId", "Days", "Id", cascadeDelete: true);
            CreateIndex("DiningOptions", "DayId");
        }
        
        public override void Down()
        {
            DropIndex("DiningOptions", new[] { "DayId" });
            DropForeignKey("DiningOptions", "DayId", "Days");
            RenameColumn(table: "DiningOptions", name: "DayId", newName: "Day_Id");
            CreateIndex("DiningOptions", "Day_Id");
            AddForeignKey("DiningOptions", "Day_Id", "Days", "Id");
        }
    }
}
