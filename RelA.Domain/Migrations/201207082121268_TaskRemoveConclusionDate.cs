namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskRemoveConclusionDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("Tasks", "ConclusionDate");
        }
        
        public override void Down()
        {
            AddColumn("Tasks", "ConclusionDate", c => c.DateTime());
        }
    }
}
