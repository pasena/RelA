namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            AddColumn("Tasks", "ProjectID", c => c.Int(nullable: false));
            AddForeignKey("Tasks", "ProjectID", "Projects", "ProjectID", cascadeDelete: true);
            CreateIndex("Tasks", "ProjectID");
        }
        
        public override void Down()
        {
            DropIndex("Tasks", new[] { "ProjectID" });
            DropForeignKey("Tasks", "ProjectID", "Projects");
            DropColumn("Tasks", "ProjectID");
            DropTable("Projects");
        }
    }
}
