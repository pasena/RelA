namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Tasks", "ProjectID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Tasks", "ProjectID");
        }
    }
}
