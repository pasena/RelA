namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLenght : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Changes", name: "Task_TaskID", newName: "TaskID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Changes", name: "TaskID", newName: "Task_TaskID");
        }
    }
}
