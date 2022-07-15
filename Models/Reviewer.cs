using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMSwebapp.Models
{
    public class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("ReviewerID")]
        public int ReviewerId { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [MinLength(1, ErrorMessage = "1 Character Required")]
        [DisplayName("Active Reviewer?")]
        public bool? Active { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [MinLength(1, ErrorMessage = "1 Character Required")]
        [DisplayName("M")]
        [StringLength(1)]
        public string? MiddleInitial { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Affiliation { get; set; }
        [StringLength(50)]
        public string? Department { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [StringLength(50)]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [StringLength(50)]
        public string? City { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [StringLength(2)]
        public string? State { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [StringLength(10)]
        public string? ZipCode { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [MinLength(11, ErrorMessage = "11 Number Characters Required")]
        [StringLength(50)]
        [DisplayName("Phone")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Username Required")]
        [DisplayName("Email")]
        [EmailAddress]
        [StringLength(100)]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(5)]
        public string? Password { get; set; }
        public bool? AnalysisOfAlgorithms { get; set; }
        public bool? Applications { get; set; }
        public bool? Architecture { get; set; }
        public bool? ArtificialIntelligence { get; set; }
        public bool? ComputerEngineering { get; set; }
        public bool? Curriculum { get; set; }
        public bool? DataStructures { get; set; }
        public bool? Databases { get; set; }
        [DisplayName("DistanceLearning")]
        public bool? DistancedLearning { get; set; }
        public bool? DistributedSystems { get; set; }
        public bool? EthicalSocietalIssues { get; set; }
        public bool? FirstYearComputing { get; set; }
        public bool? GenderIssues { get; set; }
        public bool? GrantWriting { get; set; }
        public bool? GraphicsImageProcessing { get; set; }
        public bool? HumanComputerInteraction { get; set; }
        public bool? LaboratoryEnvironments { get; set; }
        public bool? Literacy { get; set; }
        public bool? MathematicsInComputing { get; set; }
        public bool? Multimedia { get; set; }
        public bool? NetworkingDataCommunications { get; set; }
        public bool? NonMajorCourses { get; set; }
        public bool? ObjectOrientedIssues { get; set; }
        public bool? OperatingSystems { get; set; }

        public bool? ParallelProcessing { get; set; }
        public bool? Pedagogy { get; set; }
        public bool? ProgrammingLanguages { get; set; }
        public bool? Research { get; set; }
        public bool? Security { get; set; }
        public bool? SoftwareEngineering { get; set; }
        public bool? SystemsAnalysisAndDesign { get; set; }
        public bool? UsingTechnologyInTheClassroom { get; set; }
        public bool WebAndInternetProgramming { get; set; }
        public bool? Other { get; set; }
        [StringLength(50)]
        public string? OtherDescription { get; set; }
        public bool? ReviewsAcknowledged { get; set; }

        [InverseProperty("Reviewer")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

