namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusIsDefault : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaskStatus", "IsDefault", c => c.Boolean(nullable: false));
            DropColumn("TaskStatus", "CanDelete");
        }
        
        public override void Down()
        {
            AddColumn("TaskStatus", "CanDelete", c => c.Boolean(nullable: false));
            DropColumn("TaskStatus", "IsDefault");
        }
    }
}
