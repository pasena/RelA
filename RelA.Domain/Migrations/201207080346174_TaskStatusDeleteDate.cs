namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusDeleteDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaskStatus", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("TaskStatus", "DeleteDate");
        }
    }
}
