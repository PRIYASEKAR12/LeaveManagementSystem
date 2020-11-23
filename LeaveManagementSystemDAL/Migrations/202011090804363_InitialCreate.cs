namespace LeaveManagementSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 40),
                        EmployeeAge = c.Short(nullable: false),
                        EmployeePhoneNumber = c.Long(nullable: false),
                        EmployeeEmail = c.String(nullable: false, maxLength: 255),
                        EmployeeGender = c.String(nullable: false, maxLength: 6),
                        ManagerId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.EmployeePhoneNumber, unique: true)
                .Index(t => t.EmployeeEmail, unique: true)
                .Index(t => t.ManagerId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentName, unique: true);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DesignationId)
                .Index(t => t.DesignationName, unique: true);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ManagerId)
                .Index(t => t.ManagerName, unique: true);
            
            CreateStoredProcedure(
                "dbo.Manager_Insert",
                p => new
                    {
                        ManagerName = p.String(maxLength: 40),
                    },
                body:
                    @"INSERT [dbo].[Managers]([ManagerName])
                      VALUES (@ManagerName)
                      
                      DECLARE @ManagerId int
                      SELECT @ManagerId = [ManagerId]
                      FROM [dbo].[Managers]
                      WHERE @@ROWCOUNT > 0 AND [ManagerId] = scope_identity()
                      
                      SELECT t0.[ManagerId]
                      FROM [dbo].[Managers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ManagerId] = @ManagerId"
            );
            
            CreateStoredProcedure(
                "dbo.Manager_Update",
                p => new
                    {
                        ManagerId = p.Int(),
                        ManagerName = p.String(maxLength: 40),
                    },
                body:
                    @"UPDATE [dbo].[Managers]
                      SET [ManagerName] = @ManagerName
                      WHERE ([ManagerId] = @ManagerId)"
            );
            
            CreateStoredProcedure(
                "dbo.Manager_Delete",
                p => new
                    {
                        ManagerId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Managers]
                      WHERE ([ManagerId] = @ManagerId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Manager_Delete");
            DropStoredProcedure("dbo.Manager_Update");
            DropStoredProcedure("dbo.Manager_Insert");
            DropForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Managers", new[] { "ManagerName" });
            DropIndex("dbo.Designations", new[] { "DesignationName" });
            DropIndex("dbo.Departments", new[] { "DepartmentName" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropIndex("dbo.Employees", new[] { "EmployeeEmail" });
            DropIndex("dbo.Employees", new[] { "EmployeePhoneNumber" });
            DropIndex("dbo.Accounts", new[] { "EmployeeId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Accounts");
        }
    }
}
