namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TaskHistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus");
            DropForeignKey("Tasks", "ProjectID", "Projects");
            DropIndex("Tasks", new[] { "Status_TaskStatusID" });
            DropIndex("Tasks", new[] { "ProjectID" });
            CreateTable(
                "TaskHistories",
                c => new
                    {
                        TaskHistoryID = c.Int(nullable: false, identity: true),
                        HistoryDate = c.DateTime(nullable: false),
                        Task_TaskID = c.Int(nullable: false),
                        Status_TaskStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskHistoryID)
                .ForeignKey("Tasks", t => t.Task_TaskID, cascadeDelete: true)
                .ForeignKey("TaskStatus", t => t.Status_TaskStatusID, cascadeDelete: true)
                .Index(t => t.Task_TaskID)
                .Index(t => t.Status_TaskStatusID);
            
            AddColumn("Tasks", "ProjectID_ProjectID", c => c.Int(nullable: false));
            AddColumn("Tasks", "TaskStatus_TaskStatusID", c => c.Int());
            AddForeignKey("Tasks", "ProjectID_ProjectID", "Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("Tasks", "TaskStatus_TaskStatusID", "TaskStatus", "TaskStatusID");
            CreateIndex("Tasks", "ProjectID_ProjectID");
            CreateIndex("Tasks", "TaskStatus_TaskStatusID");
            DropColumn("Tasks", "ProjectID");
            DropColumn("Tasks", "Status_TaskStatusID");
        }
        
        public override void Down()
        {
            AddColumn("Tasks", "Status_TaskStatusID", c => c.Int(nullable: false));
            AddColumn("Tasks", "ProjectID", c => c.Int(nullable: false));
            DropIndex("TaskHistories", new[] { "Status_TaskStatusID" });
            DropIndex("TaskHistories", new[] { "Task_TaskID" });
            DropIndex("Tasks", new[] { "TaskStatus_TaskStatusID" });
            DropIndex("Tasks", new[] { "ProjectID_ProjectID" });
            DropForeignKey("TaskHistories", "Status_TaskStatusID", "TaskStatus");
            DropForeignKey("TaskHistories", "Task_TaskID", "Tasks");
            DropForeignKey("Tasks", "TaskStatus_TaskStatusID", "TaskStatus");
            DropForeignKey("Tasks", "ProjectID_ProjectID", "Projects");
            DropColumn("Tasks", "TaskStatus_TaskStatusID");
            DropColumn("Tasks", "ProjectID_ProjectID");
            DropTable("TaskHistories");
            CreateIndex("Tasks", "ProjectID");
            CreateIndex("Tasks", "Status_TaskStatusID");
            AddForeignKey("Tasks", "ProjectID", "Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("Tasks", "Status_TaskStatusID", "TaskStatus", "TaskStatusID", cascadeDelete: true);
        }
    }
}
