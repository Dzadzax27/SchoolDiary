namespace SchoolDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectsStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectsStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Student_Id = c.Int(),
                        Subjects_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studenti", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subjects_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subjects_Id);
            
            AlterColumn("dbo.Subjects", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectsStudents", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectsStudents", "Student_Id", "dbo.Studenti");
            DropIndex("dbo.SubjectsStudents", new[] { "Subjects_Id" });
            DropIndex("dbo.SubjectsStudents", new[] { "Student_Id" });
            AlterColumn("dbo.Subjects", "Name", c => c.Int(nullable: false));
            DropTable("dbo.SubjectsStudents");
        }
    }
}
