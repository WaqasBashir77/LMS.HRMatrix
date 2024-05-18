namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AdministratorId, cascadeDelete: true)
                .Index(t => t.AdministratorId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        OnboardingId = c.Int(nullable: false),
                        Salutation = c.String(maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 75),
                        NickName = c.String(maxLength: 50),
                        DisplayName = c.String(maxLength: 50),
                        PersonNumber = c.String(maxLength: 20),
                        WorkEmail = c.String(nullable: false, maxLength: 50),
                        LocationId = c.Int(),
                        DivisionId = c.Int(),
                        DepartmentId = c.Int(),
                        JobTitleId = c.Int(),
                        ReportsToId = c.Int(),
                        EmploymentStatusId = c.Int(),
                        HomeEmail = c.String(maxLength: 50),
                        SSNumber = c.String(maxLength: 20),
                        SINumber = c.String(maxLength: 20),
                        NINumber = c.String(maxLength: 20),
                        TaxFileNumber = c.String(maxLength: 20),
                        BloodGroup = c.String(maxLength: 10),
                        Gender = c.String(maxLength: 20),
                        Linkedin = c.String(maxLength: 30),
                        Facebook = c.String(maxLength: 30),
                        Twitter = c.String(maxLength: 30),
                        MaritalStatusId = c.Int(),
                        NationalityId = c.Int(),
                        DateOfBirth = c.DateTime(),
                        EthnicityId = c.Int(),
                        EEOJobCategoryId = c.Int(),
                        VeteranStatus = c.Int(),
                        HireDate = c.DateTime(),
                        TerminationDate = c.DateTime(),
                        WorkPhone = c.String(maxLength: 20),
                        WorkExt = c.String(maxLength: 20),
                        MobilePhone = c.String(maxLength: 20),
                        HomePhone = c.String(maxLength: 20),
                        Street1 = c.String(maxLength: 20),
                        Street2 = c.String(maxLength: 20),
                        City = c.String(maxLength: 20),
                        Region = c.String(maxLength: 20),
                        Region2 = c.String(maxLength: 20),
                        CountryId = c.Int(),
                        PostalCode = c.String(maxLength: 20),
                        RoleId = c.Int(),
                        Status = c.Boolean(),
                        LastLogin = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ReportsToId)
                .Index(t => t.ReportsToId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.LessonContents", t => t.LessonContentId)
                .ForeignKey("dbo.Employees", t => t.TrainerId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.LessonContentId)
                .Index(t => t.TrainerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CourseId)
                .Index(t => t.Employee_Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .Index(t => t.LessonId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChatGroups", t => t.ChatGroupId)
                .ForeignKey("dbo.Employees", t => t.FromId)
                .ForeignKey("dbo.Employees", t => t.ToId)
                .Index(t => t.ToId)
                .Index(t => t.FromId)
                .Index(t => t.ChatGroupId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
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
                "dbo.EnrolledEmployeeResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        TopicContentQuestionId = c.Int(nullable: false),
                        CourseEnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseEnrollments", t => t.CourseEnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.TopicContentQuestions", t => t.TopicContentQuestionId)
                .Index(t => t.TopicContentQuestionId)
                .Index(t => t.CourseEnrollmentId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonContents", t => t.LessonContentId, cascadeDelete: true)
                .Index(t => t.LessonContentId);
            
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
                "dbo.form_form_fields",
                c => new
                    {
                        formId = c.Int(nullable: false),
                        fieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.formId, t.fieldId })
                .ForeignKey("dbo.form_fields", t => t.fieldId, cascadeDelete: true)
                .ForeignKey("dbo.form", t => t.formId, cascadeDelete: true)
                .Index(t => t.formId)
                .Index(t => t.fieldId);
            
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
                "dbo.form_field_values",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FieldId = c.Int(nullable: false),
                        EntryId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 500),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.form_fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.LessonContentResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonContentId = c.Int(nullable: false),
                        Result = c.String(),
                        CourseEnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseEnrollments", t => t.CourseEnrollmentId)
                .ForeignKey("dbo.LessonContents", t => t.LessonContentId, cascadeDelete: true)
                .Index(t => t.LessonContentId)
                .Index(t => t.CourseEnrollmentId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonContentResults", "LessonContentId", "dbo.LessonContents");
            DropForeignKey("dbo.LessonContentResults", "CourseEnrollmentId", "dbo.CourseEnrollments");
            DropForeignKey("dbo.form_form_fields", "formId", "dbo.form");
            DropForeignKey("dbo.form_form_fields", "fieldId", "dbo.form_fields");
            DropForeignKey("dbo.form_field_values", "FieldId", "dbo.form_fields");
            DropForeignKey("dbo.EnrolledEmployeeResults", "TopicContentQuestionId", "dbo.TopicContentQuestions");
            DropForeignKey("dbo.TopicContentQuestions", "LessonContentId", "dbo.LessonContents");
            DropForeignKey("dbo.EnrolledEmployeeResults", "CourseEnrollmentId", "dbo.CourseEnrollments");
            DropForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Chats", "ToId", "dbo.Employees");
            DropForeignKey("dbo.Chats", "FromId", "dbo.Employees");
            DropForeignKey("dbo.Chats", "ChatGroupId", "dbo.ChatGroups");
            DropForeignKey("dbo.ChatGroups", "AdministratorId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ReportsToId", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "TrainerId", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "LessonContentId", "dbo.LessonContents");
            DropForeignKey("dbo.LessonContents", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseEnrollments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Courses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CourseEnrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.LessonContentResults", new[] { "CourseEnrollmentId" });
            DropIndex("dbo.LessonContentResults", new[] { "LessonContentId" });
            DropIndex("dbo.form_field_values", new[] { "FieldId" });
            DropIndex("dbo.form_form_fields", new[] { "fieldId" });
            DropIndex("dbo.form_form_fields", new[] { "formId" });
            DropIndex("dbo.TopicContentQuestions", new[] { "LessonContentId" });
            DropIndex("dbo.EnrolledEmployeeResults", new[] { "CourseEnrollmentId" });
            DropIndex("dbo.EnrolledEmployeeResults", new[] { "TopicContentQuestionId" });
            DropIndex("dbo.Connections", new[] { "EmployeeId" });
            DropIndex("dbo.Chats", new[] { "ChatGroupId" });
            DropIndex("dbo.Chats", new[] { "FromId" });
            DropIndex("dbo.Chats", new[] { "ToId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.LessonContents", new[] { "LessonId" });
            DropIndex("dbo.Courses", new[] { "EmployeeId" });
            DropIndex("dbo.CourseEnrollments", new[] { "Employee_Id" });
            DropIndex("dbo.CourseEnrollments", new[] { "CourseId" });
            DropIndex("dbo.CourseEnrollments", new[] { "EmployeeId" });
            DropIndex("dbo.CourseEnrollments", new[] { "TrainerId" });
            DropIndex("dbo.CourseEnrollments", new[] { "LessonContentId" });
            DropIndex("dbo.Employees", new[] { "ReportsToId" });
            DropIndex("dbo.ChatGroups", new[] { "AdministratorId" });
            DropTable("dbo.Taskings");
            DropTable("dbo.LessonContentResults");
            DropTable("dbo.form_field_values");
            DropTable("dbo.form_fields");
            DropTable("dbo.form_form_fields");
            DropTable("dbo.form");
            DropTable("dbo.TopicContentQuestions");
            DropTable("dbo.EnrolledEmployeeResults");
            DropTable("dbo.Dependencies");
            DropTable("dbo.Connections");
            DropTable("dbo.Chats");
            DropTable("dbo.Lessons");
            DropTable("dbo.LessonContents");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseEnrollments");
            DropTable("dbo.Employees");
            DropTable("dbo.ChatGroups");
        }
    }
}
