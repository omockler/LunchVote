namespace LunchVote.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SwitchIEnumerabletoICollectiononDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("DiningOptions", "Day_Id", c => c.Guid());
            AddForeignKey("DiningOptions", "Day_Id", "Days", "Id");
            CreateIndex("DiningOptions", "Day_Id");
        }
        
        public override void Down()
        {
            DropIndex("DiningOptions", new[] { "Day_Id" });
            DropForeignKey("DiningOptions", "Day_Id", "Days");
            DropColumn("DiningOptions", "Day_Id");
        }
    }
}
