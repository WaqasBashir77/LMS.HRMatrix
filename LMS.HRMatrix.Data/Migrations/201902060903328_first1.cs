namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseEnrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.LessonContents", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.CourseEnrollments", "LessonContentId", "dbo.LessonContents");
            DropForeignKey("dbo.CourseEnrollments", "TrainerId", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ReportsToId", "dbo.Employees");
            DropForeignKey("dbo.ChatGroups", "AdministratorId", "dbo.Employees");
            DropForeignKey("dbo.Chats", "ChatGroupId", "dbo.ChatGroups");
            DropForeignKey("dbo.Chats", "FromId", "dbo.Employees");
            DropForeignKey("dbo.Chats", "ToId", "dbo.Employees");
            DropForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EnrolledEmployeeResults", "CourseEnrollmentId", "dbo.CourseEnrollments");
            DropForeignKey("dbo.TopicContentQuestions", "LessonContentId", "dbo.LessonContents");
            DropForeignKey("dbo.EnrolledEmployeeResults", "TopicContentQuestionId", "dbo.TopicContentQuestions");
            DropForeignKey("dbo.form_field_values", "FieldId", "dbo.form_fields");
            DropForeignKey("dbo.form_form_fields", "fieldId", "dbo.form_fields");
            DropForeignKey("dbo.form_form_fields", "formId", "dbo.form");
            DropForeignKey("dbo.LessonContentResults", "CourseEnrollmentId", "dbo.CourseEnrollments");
            DropForeignKey("dbo.LessonContentResults", "LessonContentId", "dbo.LessonContents");
            DropIndex("dbo.ChatGroups", new[] { "AdministratorId" });
            DropIndex("dbo.Employees", new[] { "ReportsToId" });
            DropIndex("dbo.CourseEnrollments", new[] { "LessonContentId" });
            DropIndex("dbo.CourseEnrollments", new[] { "TrainerId" });
            DropIndex("dbo.CourseEnrollments", new[] { "EmployeeId" });
            DropIndex("dbo.CourseEnrollments", new[] { "CourseId" });
            DropIndex("dbo.CourseEnrollments", new[] { "Employee_Id" });
            DropIndex("dbo.Courses", new[] { "EmployeeId" });
            DropIndex("dbo.LessonContents", new[] { "LessonId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Chats", new[] { "ToId" });
            DropIndex("dbo.Chats", new[] { "FromId" });
            DropIndex("dbo.Chats", new[] { "ChatGroupId" });
            DropIndex("dbo.Connections", new[] { "EmployeeId" });
            DropIndex("dbo.EnrolledEmployeeResults", new[] { "TopicContentQuestionId" });
            DropIndex("dbo.EnrolledEmployeeResults", new[] { "CourseEnrollmentId" });
            DropIndex("dbo.TopicContentQuestions", new[] { "LessonContentId" });
            DropIndex("dbo.form_form_fields", new[] { "formId" });
            DropIndex("dbo.form_form_fields", new[] { "fieldId" });
            DropIndex("dbo.form_field_values", new[] { "FieldId" });
            DropIndex("dbo.LessonContentResults", new[] { "LessonContentId" });
            DropIndex("dbo.LessonContentResults", new[] { "CourseEnrollmentId" });
            DropColumn("dbo.Employees", "LocationId");
            DropColumn("dbo.Employees", "DivisionId");
            DropColumn("dbo.Employees", "DepartmentId");
            DropColumn("dbo.Employees", "JobTitleId");
            DropColumn("dbo.Employees", "ReportsToId");
            DropColumn("dbo.Employees", "EmploymentStatusId");
            DropColumn("dbo.Employees", "HomeEmail");
            DropColumn("dbo.Employees", "SSNumber");
            DropColumn("dbo.Employees", "SINumber");
            DropColumn("dbo.Employees", "NINumber");
            DropColumn("dbo.Employees", "TaxFileNumber");
            DropColumn("dbo.Employees", "BloodGroup");
            DropColumn("dbo.Employees", "Gender");
            DropColumn("dbo.Employees", "Linkedin");
            DropColumn("dbo.Employees", "Facebook");
            DropColumn("dbo.Employees", "Twitter");
            DropColumn("dbo.Employees", "MaritalStatusId");
            DropColumn("dbo.Employees", "NationalityId");
            DropColumn("dbo.Employees", "DateOfBirth");
            DropColumn("dbo.Employees", "EthnicityId");
            DropColumn("dbo.Employees", "EEOJobCategoryId");
            DropColumn("dbo.Employees", "VeteranStatus");
            DropColumn("dbo.Employees", "HireDate");
            DropColumn("dbo.Employees", "TerminationDate");
            DropColumn("dbo.Employees", "WorkPhone");
            DropColumn("dbo.Employees", "WorkExt");
            DropColumn("dbo.Employees", "MobilePhone");
            DropColumn("dbo.Employees", "HomePhone");
            DropColumn("dbo.Employees", "Street1");
            DropColumn("dbo.Employees", "Street2");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Region");
            DropColumn("dbo.Employees", "Region2");
            DropColumn("dbo.Employees", "CountryId");
            DropColumn("dbo.Employees", "PostalCode");
            DropColumn("dbo.Employees", "RoleId");
            DropColumn("dbo.Employees", "Status");
            DropColumn("dbo.Employees", "LastLogin");
            DropColumn("dbo.Employees", "CreationDate");
            DropColumn("dbo.Employees", "LastUpdateDate");
            DropTable("dbo.ChatGroups");
            DropTable("dbo.CourseEnrollments");
            DropTable("dbo.Courses");
            DropTable("dbo.LessonContents");
            DropTable("dbo.Lessons");
            DropTable("dbo.Chats");
            DropTable("dbo.Connections");
            DropTable("dbo.Dependencies");
            DropTable("dbo.EnrolledEmployeeResults");
            DropTable("dbo.TopicContentQuestions");
            DropTable("dbo.form");
            DropTable("dbo.form_form_fields");
            DropTable("dbo.form_fields");
            DropTable("dbo.form_field_values");
            DropTable("dbo.LessonContentResults");
            DropTable("dbo.Taskings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Taskings",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Title = c.String(),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        Summary = c.Boolean(nullable: false),
                        Expanded = c.Boolean(nullable: false),
                        PercentComplete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.LessonContentResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonContentId = c.Int(nullable: false),
                        Result = c.String(),
                        CourseEnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.form_field_values",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FieldId = c.Int(nullable: false),
                        EntryId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 500),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.form_fields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(maxLength: 50),
                        Text = c.String(maxLength: 100),
                        FieldType = c.String(maxLength: 20, unicode: false),
                        IsRequired = c.Boolean(),
                        MaxChars = c.Int(),
                        HoverText = c.String(maxLength: 150),
                        Hint = c.String(maxLength: 150),
                        SubLabel = c.String(maxLength: 50),
                        Size = c.String(maxLength: 10, unicode: false),
                        SelectedOption = c.String(nullable: false, maxLength: 50),
                        Columns = c.Int(),
                        Rows = c.Int(),
                        Options = c.String(maxLength: 300),
                        Validation = c.String(maxLength: 50, unicode: false),
                        DomId = c.Int(),
                        Order = c.Int(),
                        MinimumAge = c.Int(),
                        MaximumAge = c.Int(),
                        HelpText = c.String(maxLength: 50),
                        DateAdded = c.DateTime(nullable: false),
                        MaxFilesizeInKb = c.Int(),
                        ValidFileExtensions = c.String(maxLength: 50),
                        MinFilesizeInKb = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.form_form_fields",
                c => new
                    {
                        formId = c.Int(nullable: false),
                        fieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.formId, t.fieldId });
            
            CreateTable(
                "dbo.form",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Slug = c.String(nullable: false, maxLength: 50),
                        Status = c.String(maxLength: 50),
                        ConfirmationMessage = c.String(nullable: false, maxLength: 300),
                        DateAdded = c.DateTime(),
                        Theme = c.String(maxLength: 50),
                        NotificationEmail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TopicContentQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        Question = c.String(),
                        optionone = c.String(),
                        optiononestatus = c.String(),
                        optiontwo = c.String(),
                        optiontwostatus = c.String(),
                        optionthree = c.String(),
                        optionthreestatus = c.String(),
                        optionfour = c.String(),
                        optionfourstatus = c.String(),
                        LessonContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrolledEmployeeResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        TopicContentQuestionId = c.Int(nullable: false),
                        CourseEnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dependencies",
                c => new
                    {
                        DependencyID = c.Int(nullable: false, identity: true),
                        PredecessorID = c.Int(nullable: false),
                        SuccessorID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DependencyID);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionId = c.String(),
                        Time = c.DateTime(nullable: false),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        ReadStatus = c.Boolean(nullable: false),
                        HasGroup = c.Boolean(nullable: false),
                        ReadTime = c.DateTime(),
                        MembersRead = c.String(),
                        ToId = c.Int(nullable: false),
                        FromId = c.Int(nullable: false),
                        ChatGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        Date = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Url = c.String(),
                        ContentText = c.String(),
                        Status = c.String(),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        OverviewVideo = c.String(),
                        Date = c.DateTime(),
                        Hours = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnrolledDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        OverallResult = c.Int(nullable: false),
                        LessonContentId = c.Int(nullable: false),
                        LessonContentTime = c.String(),
                        TrainerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChatGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NameBit = c.Boolean(nullable: false),
                        Memebers = c.String(),
                        Created = c.DateTime(nullable: false),
                        AdministratorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "LastUpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "LastLogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Status", c => c.Boolean());
            AddColumn("dbo.Employees", "RoleId", c => c.Int());
            AddColumn("dbo.Employees", "PostalCode", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "CountryId", c => c.Int());
            AddColumn("dbo.Employees", "Region2", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "Region", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "City", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "Street2", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "Street1", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "HomePhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "MobilePhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "WorkExt", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "WorkPhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "TerminationDate", c => c.DateTime());
            AddColumn("dbo.Employees", "HireDate", c => c.DateTime());
            AddColumn("dbo.Employees", "VeteranStatus", c => c.Int());
            AddColumn("dbo.Employees", "EEOJobCategoryId", c => c.Int());
            AddColumn("dbo.Employees", "EthnicityId", c => c.Int());
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Employees", "NationalityId", c => c.Int());
            AddColumn("dbo.Employees", "MaritalStatusId", c => c.Int());
            AddColumn("dbo.Employees", "Twitter", c => c.String(maxLength: 30));
            AddColumn("dbo.Employees", "Facebook", c => c.String(maxLength: 30));
            AddColumn("dbo.Employees", "Linkedin", c => c.String(maxLength: 30));
            AddColumn("dbo.Employees", "Gender", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "BloodGroup", c => c.String(maxLength: 10));
            AddColumn("dbo.Employees", "TaxFileNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "NINumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "SINumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "SSNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Employees", "HomeEmail", c => c.String(maxLength: 50));
            AddColumn("dbo.Employees", "EmploymentStatusId", c => c.Int());
            AddColumn("dbo.Employees", "ReportsToId", c => c.Int());
            AddColumn("dbo.Employees", "JobTitleId", c => c.Int());
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int());
            AddColumn("dbo.Employees", "DivisionId", c => c.Int());
            AddColumn("dbo.Employees", "LocationId", c => c.Int());
            CreateIndex("dbo.LessonContentResults", "CourseEnrollmentId");
            CreateIndex("dbo.LessonContentResults", "LessonContentId");
            CreateIndex("dbo.form_field_values", "FieldId");
            CreateIndex("dbo.form_form_fields", "fieldId");
            CreateIndex("dbo.form_form_fields", "formId");
            CreateIndex("dbo.TopicContentQuestions", "LessonContentId");
            CreateIndex("dbo.EnrolledEmployeeResults", "CourseEnrollmentId");
            CreateIndex("dbo.EnrolledEmployeeResults", "TopicContentQuestionId");
            CreateIndex("dbo.Connections", "EmployeeId");
            CreateIndex("dbo.Chats", "ChatGroupId");
            CreateIndex("dbo.Chats", "FromId");
            CreateIndex("dbo.Chats", "ToId");
            CreateIndex("dbo.Lessons", "CourseId");
            CreateIndex("dbo.LessonContents", "LessonId");
            CreateIndex("dbo.Courses", "EmployeeId");
            CreateIndex("dbo.CourseEnrollments", "Employee_Id");
            CreateIndex("dbo.CourseEnrollments", "CourseId");
            CreateIndex("dbo.CourseEnrollments", "EmployeeId");
            CreateIndex("dbo.CourseEnrollments", "TrainerId");
            CreateIndex("dbo.CourseEnrollments", "LessonContentId");
            CreateIndex("dbo.Employees", "ReportsToId");
            CreateIndex("dbo.ChatGroups", "AdministratorId");
            AddForeignKey("dbo.LessonContentResults", "LessonContentId", "dbo.LessonContents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LessonContentResults", "CourseEnrollmentId", "dbo.CourseEnrollments", "Id");
            AddForeignKey("dbo.form_form_fields", "formId", "dbo.form", "ID", cascadeDelete: true);
            AddForeignKey("dbo.form_form_fields", "fieldId", "dbo.form_fields", "ID", cascadeDelete: true);
            AddForeignKey("dbo.form_field_values", "FieldId", "dbo.form_fields", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EnrolledEmployeeResults", "TopicContentQuestionId", "dbo.TopicContentQuestions", "Id");
            AddForeignKey("dbo.TopicContentQuestions", "LessonContentId", "dbo.LessonContents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrolledEmployeeResults", "CourseEnrollmentId", "dbo.CourseEnrollments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chats", "ToId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Chats", "FromId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Chats", "ChatGroupId", "dbo.ChatGroups", "Id");
            AddForeignKey("dbo.ChatGroups", "AdministratorId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "ReportsToId", "dbo.Employees", "Id");
            AddForeignKey("dbo.CourseEnrollments", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.CourseEnrollments", "TrainerId", "dbo.Employees", "Id");
            AddForeignKey("dbo.CourseEnrollments", "LessonContentId", "dbo.LessonContents", "Id");
            AddForeignKey("dbo.LessonContents", "LessonId", "dbo.Lessons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseEnrollments", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Courses", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseEnrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
