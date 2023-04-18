namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagereadstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageReadStatus");
        }
    }
}
