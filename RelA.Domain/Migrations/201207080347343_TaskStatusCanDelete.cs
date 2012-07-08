namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusCanDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaskStatus", "CanDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TaskStatus", "CanDelete");
        }
    }
}
