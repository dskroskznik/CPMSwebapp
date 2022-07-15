using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPMSwebapp.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Reviewer",
                columns: table => new
                {
                    ReviewerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AnalysisOfAlgorithms = table.Column<bool>(type: "bit", nullable: true),
                    Applications = table.Column<bool>(type: "bit", nullable: true),
                    Architecture = table.Column<bool>(type: "bit", nullable: true),
                    ArtificialIntelligence = table.Column<bool>(type: "bit", nullable: true),
                    ComputerEngineering = table.Column<bool>(type: "bit", nullable: true),
                    Curriculum = table.Column<bool>(type: "bit", nullable: true),
                    DataStructures = table.Column<bool>(type: "bit", nullable: true),
                    Databases = table.Column<bool>(type: "bit", nullable: true),
                    DistancedLearning = table.Column<bool>(type: "bit", nullable: true),
                    DistributedSystems = table.Column<bool>(type: "bit", nullable: true),
                    EthicalSocietalIssues = table.Column<bool>(type: "bit", nullable: true),
                    FirstYearComputing = table.Column<bool>(type: "bit", nullable: true),
                    GenderIssues = table.Column<bool>(type: "bit", nullable: true),
                    GrantWriting = table.Column<bool>(type: "bit", nullable: true),
                    GraphicsImageProcessing = table.Column<bool>(type: "bit", nullable: true),
                    HumanComputerInteraction = table.Column<bool>(type: "bit", nullable: true),
                    LaboratoryEnvironments = table.Column<bool>(type: "bit", nullable: true),
                    Literacy = table.Column<bool>(type: "bit", nullable: true),
                    MathematicsInComputing = table.Column<bool>(type: "bit", nullable: true),
                    Multimedia = table.Column<bool>(type: "bit", nullable: true),
                    NetworkingDataCommunications = table.Column<bool>(type: "bit", nullable: true),
                    NonMajorCourses = table.Column<bool>(type: "bit", nullable: true),
                    ObjectOrientedIssues = table.Column<bool>(type: "bit", nullable: true),
                    OperatingSystems = table.Column<bool>(type: "bit", nullable: true),
                    ParallelProcessing = table.Column<bool>(type: "bit", nullable: true),
                    Pedagogy = table.Column<bool>(type: "bit", nullable: true),
                    ProgrammingLanguages = table.Column<bool>(type: "bit", nullable: true),
                    Research = table.Column<bool>(type: "bit", nullable: true),
                    Security = table.Column<bool>(type: "bit", nullable: true),
                    SoftwareEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemsAnalysisAndDesign = table.Column<bool>(type: "bit", nullable: true),
                    UsingTechnologyInTheClassroom = table.Column<bool>(type: "bit", nullable: true),
                    WebAndInternetProgramming = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    OtherDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReviewsAcknowledged = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewer", x => x.ReviewerID);
                });

            migrationBuilder.CreateTable(
                name: "Paper",
                columns: table => new
                {
                    PaperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FilenameOriginal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NotesToReviewers = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    AnalysisOfAlgorithms = table.Column<bool>(type: "bit", nullable: true),
                    Applications = table.Column<bool>(type: "bit", nullable: true),
                    Architecture = table.Column<bool>(type: "bit", nullable: true),
                    ArtificialIntelligence = table.Column<bool>(type: "bit", nullable: true),
                    ComputerEngineering = table.Column<bool>(type: "bit", nullable: true),
                    Curriculum = table.Column<bool>(type: "bit", nullable: true),
                    DataStructures = table.Column<bool>(type: "bit", nullable: true),
                    Databases = table.Column<bool>(type: "bit", nullable: true),
                    DistanceLearning = table.Column<bool>(type: "bit", nullable: true),
                    DistributedSystems = table.Column<bool>(type: "bit", nullable: true),
                    EthicalSocietalIssues = table.Column<bool>(type: "bit", nullable: true),
                    FirstYearComputing = table.Column<bool>(type: "bit", nullable: true),
                    GenderIssues = table.Column<bool>(type: "bit", nullable: true),
                    GrantWriting = table.Column<bool>(type: "bit", nullable: true),
                    GraphicsImageProcessing = table.Column<bool>(type: "bit", nullable: true),
                    HumanComputerInteraction = table.Column<bool>(type: "bit", nullable: true),
                    LaboratoryEnvironments = table.Column<bool>(type: "bit", nullable: true),
                    Literacy = table.Column<bool>(type: "bit", nullable: true),
                    MathematicsInComputing = table.Column<bool>(type: "bit", nullable: true),
                    Multimedia = table.Column<bool>(type: "bit", nullable: true),
                    NetworkingDataCommunications = table.Column<bool>(type: "bit", nullable: true),
                    NonMajorCourses = table.Column<bool>(type: "bit", nullable: true),
                    ObjectOrientedIssues = table.Column<bool>(type: "bit", nullable: true),
                    OperatingSystems = table.Column<bool>(type: "bit", nullable: true),
                    ParallelsProcessing = table.Column<bool>(type: "bit", nullable: true),
                    Pedagogy = table.Column<bool>(type: "bit", nullable: true),
                    ProgrammingLanguages = table.Column<bool>(type: "bit", nullable: true),
                    Research = table.Column<bool>(type: "bit", nullable: true),
                    Security = table.Column<bool>(type: "bit", nullable: true),
                    SoftwareEngineering = table.Column<bool>(type: "bit", nullable: true),
                    SystemsAnalysisAndDesign = table.Column<bool>(type: "bit", nullable: true),
                    UsingTechnologyInTheClassroom = table.Column<bool>(type: "bit", nullable: true),
                    WebAndInternetProgramming = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    OtherDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paper", x => x.PaperID);
                    table.ForeignKey(
                        name: "FK_Paper_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperID = table.Column<int>(type: "int", nullable: true),
                    ReviewerID = table.Column<int>(type: "int", nullable: true),
                    AppropriatenessOfTopic = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    TimelinessOfTopic = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    SupportiveEvidence = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    TechnicalQuality = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ScopeOfCoverage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    CitationOfPreviousWork = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Originality = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ContentComments = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    OrganizationOfPaper = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ClarityOfMainMessage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Mechanics = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    WrittenDocumentComments = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    SuitabilityForPresentation = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    PotentialInterestInTopic = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    PotentialForOralPresentationComments = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    OverallRating = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    OverallRatingComments = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ComfortLevelTopic = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ComfortLevelAcceptability = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Paper_PaperID",
                        column: x => x.PaperID,
                        principalTable: "Paper",
                        principalColumn: "PaperID");
                    table.ForeignKey(
                        name: "FK_Review_Reviewer_ReviewerID",
                        column: x => x.ReviewerID,
                        principalTable: "Reviewer",
                        principalColumn: "ReviewerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paper_AuthorID",
                table: "Paper",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PaperID",
                table: "Review",
                column: "PaperID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerID",
                table: "Review",
                column: "ReviewerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Paper");

            migrationBuilder.DropTable(
                name: "Reviewer");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
