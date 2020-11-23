namespace LeaveManagementSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        StartDate = c.Long(nullable: false),
                        EndDate = c.Long(nullable: false),
                        LeaveType = c.String(),
                        Status = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropTable("dbo.Leaves");
        }
    }
}
