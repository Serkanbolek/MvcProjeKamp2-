﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactaddreadstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ReadStatus");
        }
    }
}
