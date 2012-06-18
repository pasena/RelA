namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus");
            DropForeignKey("Tasks", "User_UserID", "Users");
            DropForeignKey("Changes", "Task_TaskID", "Tasks");
            DropIndex("Tasks", new[] { "Status_TaskStatusID" });
            DropIndex("Tasks", new[] { "User_UserID" });
            DropIndex("Changes", new[] { "Task_TaskID" });
            AlterColumn("Users", "Login", c => c.String(nullable: false));
            AlterColumn("Users", "Password", c => c.String(nullable: false));
            AlterColumn("Tasks", "Title", c => c.String(nullable: false));
            AlterColumn("Tasks", "Description", c => c.String(nullable: false));
            AlterColumn("Tasks", "Status_TaskStatusID", c => c.Int(nullable: false));
            AlterColumn("Tasks", "User_UserID", c => c.Int(nullable: false));
            AlterColumn("Changes", "Unit", c => c.String(nullable: false));
            AlterColumn("Changes", "Modification", c => c.String(nullable: false));
            AlterColumn("Changes", "Task_TaskID", c => c.Int(nullable: false));
            AlterColumn("TaskStatus", "Description", c => c.String(nullable: false));
            AddForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus", "TaskStatusID", cascadeDelete: true);
            AddForeignKey("Tasks", "User_UserID", "Users", "UserID", cascadeDelete: true);
            AddForeignKey("Changes", "Task_TaskID", "Tasks", "TaskID", cascadeDelete: true);
            CreateIndex("Tasks", "Status_TaskStatusID");
            CreateIndex("Tasks", "User_UserID");
            CreateIndex("Changes", "Task_TaskID");
        }
        
        public override void Down()
        {
            DropIndex("Changes", new[] { "Task_TaskID" });
            DropIndex("Tasks", new[] { "User_UserID" });
            DropIndex("Tasks", new[] { "Status_TaskStatusID" });
            DropForeignKey("Changes", "Task_TaskID", "Tasks");
            DropForeignKey("Tasks", "User_UserID", "Users");
            DropForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus");
            AlterColumn("TaskStatus", "Description", c => c.String());
            AlterColumn("Changes", "Task_TaskID", c => c.Int());
            AlterColumn("Changes", "Modification", c => c.String());
            AlterColumn("Changes", "Unit", c => c.String());
            AlterColumn("Tasks", "User_UserID", c => c.Int());
            AlterColumn("Tasks", "Status_TaskStatusID", c => c.Int());
            AlterColumn("Tasks", "Description", c => c.String());
            AlterColumn("Tasks", "Title", c => c.String());
            AlterColumn("Users", "Password", c => c.String());
            AlterColumn("Users", "Login", c => c.String());
            CreateIndex("Changes", "Task_TaskID");
            CreateIndex("Tasks", "User_UserID");
            CreateIndex("Tasks", "Status_TaskStatusID");
            AddForeignKey("Changes", "Task_TaskID", "Tasks", "TaskID");
            AddForeignKey("Tasks", "User_UserID", "Users", "UserID");
            AddForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus", "TaskStatusID");
        }
    }
}
