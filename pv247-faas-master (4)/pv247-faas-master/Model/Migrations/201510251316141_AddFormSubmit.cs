namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFormSubmit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Elements", "Type_Id", "dbo.ElementTypes");
            DropForeignKey("dbo.Forms", "Type_Id", "dbo.FormTypes");
            DropIndex("dbo.Elements", new[] { "Type_Id" });
            DropIndex("dbo.Forms", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Elements", name: "Type_Id", newName: "TypeId");
            RenameColumn(table: "dbo.Forms", name: "Type_Id", newName: "TypeId");
            AlterColumn("dbo.Elements", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Forms", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Elements", "TypeId");
            CreateIndex("dbo.Forms", "TypeId");
            AddForeignKey("dbo.Elements", "TypeId", "dbo.ElementTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Forms", "TypeId", "dbo.FormTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forms", "TypeId", "dbo.FormTypes");
            DropForeignKey("dbo.Elements", "TypeId", "dbo.ElementTypes");
            DropIndex("dbo.Forms", new[] { "TypeId" });
            DropIndex("dbo.Elements", new[] { "TypeId" });
            AlterColumn("dbo.Forms", "TypeId", c => c.Int());
            AlterColumn("dbo.Elements", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Forms", name: "TypeId", newName: "Type_Id");
            RenameColumn(table: "dbo.Elements", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.Forms", "Type_Id");
            CreateIndex("dbo.Elements", "Type_Id");
            AddForeignKey("dbo.Forms", "Type_Id", "dbo.FormTypes", "Id");
            AddForeignKey("dbo.Elements", "Type_Id", "dbo.ElementTypes", "Id");
        }
    }
}
