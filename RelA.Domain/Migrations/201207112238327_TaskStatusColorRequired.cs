namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskStatusColorRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TaskStatus", "Color", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("TaskStatus", "Color", c => c.String(maxLength: 20));
        }
    }
}
