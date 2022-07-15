using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMSwebapp.Models
{
    public class Review
    {
        [Key]
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        [Column("PaperID")]
        public int? PaperId { get; set; }
        [Column("ReviewerID")]
        public int? ReviewerId { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Appropiateness")]
        public decimal? AppropriatenessOfTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Timeliness")]
        public decimal? TimelinessOfTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Supportive Evidence")]
        public decimal? SupportiveEvidence { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Technical Quality")]
        public decimal? TechnicalQuality { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Coverage Scope")]
        public decimal? ScopeOfCoverage { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Citation Previous Work")]
        public decimal? CitationOfPreviousWork { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Originality")]
        public decimal? Originality { get; set; }
        [StringLength(int.MaxValue)]
        [DisplayName("Content Comments")]
        public string? ContentComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Paper Organization")]
        public decimal? OrganizationOfPaper { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Main Message Clarity")]
        public decimal? ClarityOfMainMessage { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Mechanics")]
        public decimal? Mechanics { get; set; }
        [StringLength(int.MaxValue)]
        [DisplayName("Document Comments")]
        public string? WrittenDocumentComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Present Suitability")]
        public decimal? SuitabilityForPresentation { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Interest In Paper Topic")]
        public decimal? PotentialInterestInTopic { get; set; }
        [StringLength(int.MaxValue)]
        [DisplayName("Oral Presentation Comments")]
        public string? PotentialForOralPresentationComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Overall Rating")]
        public decimal? OverallRating { get; set; }
        [StringLength(int.MaxValue)]
        [DisplayName("Overall Rating Comments")]
        public string? OverallRatingComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Comfort Level Topic")]
        public decimal? ComfortLevelTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("Comfort Level Acceptability")]
        public decimal? ComfortLevelAcceptability { get; set; }
        public bool? Complete { get; set; }

        [ForeignKey("PaperId")]
        [InverseProperty("Reviews")]
        public virtual Paper? Paper { get; set; }
        [ForeignKey("ReviewerId")]
        [InverseProperty("Reviews")]
        public virtual Reviewer? Reviewer { get; set; }
    }
}
