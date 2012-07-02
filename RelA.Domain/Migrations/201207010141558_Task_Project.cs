namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Task_Project : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Tasks", "ProjectID_ProjectID", "Projects");
            DropIndex("Tasks", new[] { "ProjectID_ProjectID" });
            AddColumn("Tasks", "Project_ProjectID", c => c.Int(nullable: false));
            AddForeignKey("Tasks", "Project_ProjectID", "Projects", "ProjectID", cascadeDelete: true);
            CreateIndex("Tasks", "Project_ProjectID");
            DropColumn("Tasks", "ProjectID_ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("Tasks", "ProjectID_ProjectID", c => c.Int(nullable: false));
            DropIndex("Tasks", new[] { "Project_ProjectID" });
            DropForeignKey("Tasks", "Project_ProjectID", "Projects");
            DropColumn("Tasks", "Project_ProjectID");
            CreateIndex("Tasks", "ProjectID_ProjectID");
            AddForeignKey("Tasks", "ProjectID_ProjectID", "Projects", "ProjectID", cascadeDelete: true);
        }
    }
}
