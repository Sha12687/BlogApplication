namespace BlogDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraintToEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmpInfoes", "EmailId", c => c.String(maxLength: 255));
            CreateIndex("dbo.EmpInfoes", "EmailId", unique: true, name: "UQ_EmailId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmpInfoes", "UQ_EmailId");
            AlterColumn("dbo.EmpInfoes", "EmailId", c => c.String());
        }
    }
}
