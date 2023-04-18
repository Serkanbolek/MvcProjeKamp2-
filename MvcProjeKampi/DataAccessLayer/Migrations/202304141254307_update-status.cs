namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Status", c => c.String());
        }
    }
}
