namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UserModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Tasks", "Project_ProjectID", "Projects");
            DropIndex("Tasks", new[] { "Project_ProjectID" });
            RenameColumn(table: "Tasks", name: "User_UserID", newName: "UserID");
            AddColumn("Tasks", "ProjectID", c => c.Int(nullable: false));
            AddForeignKey("Tasks", "ProjectID", "Projects", "ProjectID", cascadeDelete: true);
            CreateIndex("Tasks", "ProjectID");
            DropColumn("Tasks", "Project_ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("Tasks", "Project_ProjectID", c => c.Int(nullable: false));
            DropIndex("Tasks", new[] { "ProjectID" });
            DropForeignKey("Tasks", "ProjectID", "Projects");
            DropColumn("Tasks", "ProjectID");
            RenameColumn(table: "Tasks", name: "UserID", newName: "User_UserID");
            CreateIndex("Tasks", "Project_ProjectID");
            AddForeignKey("Tasks", "Project_ProjectID", "Projects", "ProjectID", cascadeDelete: true);
        }
    }
}
