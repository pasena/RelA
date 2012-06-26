namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MaxLenghthFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Users", "Login", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("Users", "Password", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("Tasks", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("Tasks", "Note", c => c.String(maxLength: 500));
            AlterColumn("Changes", "Note", c => c.String(maxLength: 500));
            AlterColumn("TaskStatus", "Description", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("TaskStatus", "Description", c => c.String(nullable: false));
            AlterColumn("Changes", "Note", c => c.String());
            AlterColumn("Tasks", "Note", c => c.String());
            AlterColumn("Tasks", "Title", c => c.String(nullable: false));
            AlterColumn("Users", "Password", c => c.String(nullable: false));
            AlterColumn("Users", "Login", c => c.String(nullable: false));
        }
    }
}
