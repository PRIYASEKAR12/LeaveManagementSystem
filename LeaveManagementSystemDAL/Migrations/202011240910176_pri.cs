namespace LeaveManagementSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pri : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leaves", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Leaves", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leaves", "EndDate", c => c.Long(nullable: false));
            AlterColumn("dbo.Leaves", "StartDate", c => c.Long(nullable: false));
        }
    }
}
