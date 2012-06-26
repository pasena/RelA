namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaskStatus", "Color", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("TaskStatus", "Color");
        }
    }
}
