namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Type_Id = c.Int(),
                        Form_FormId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ElementTypes", t => t.Type_Id)
                .ForeignKey("dbo.Forms", t => t.Form_FormId)
                .Index(t => t.Type_Id)
                .Index(t => t.Form_FormId);
            
            CreateTable(
                "dbo.ElementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ElementHtmlType = c.Int(nullable: false),
                        FormType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormTypes", t => t.FormType_Id)
                .Index(t => t.FormType_Id);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        Type_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FormId)
                .ForeignKey("dbo.FormTypes", t => t.Type_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.FormTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.FormTypes", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Forms", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Forms", "Type_Id", "dbo.FormTypes");
            DropForeignKey("dbo.ElementTypes", "FormType_Id", "dbo.FormTypes");
            DropForeignKey("dbo.Elements", "Form_FormId", "dbo.Forms");
            DropForeignKey("dbo.Elements", "Type_Id", "dbo.ElementTypes");
            DropIndex("dbo.Users", new[] { "Project_Id" });
            DropIndex("dbo.FormTypes", new[] { "Project_Id" });
            DropIndex("dbo.Forms", new[] { "Project_Id" });
            DropIndex("dbo.Forms", new[] { "Type_Id" });
            DropIndex("dbo.ElementTypes", new[] { "FormType_Id" });
            DropIndex("dbo.Elements", new[] { "Form_FormId" });
            DropIndex("dbo.Elements", new[] { "Type_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.FormTypes");
            DropTable("dbo.Forms");
            DropTable("dbo.ElementTypes");
            DropTable("dbo.Elements");
        }
    }
}
