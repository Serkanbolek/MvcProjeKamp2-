namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Status");
        }
    }
}
