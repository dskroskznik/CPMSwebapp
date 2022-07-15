using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMSwebapp.Models
{
    public class Author
    {

        public Author()
        {
            Papers = new HashSet<Paper>();
        }

        [Key]
        [Column("AuthorID")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [MinLength(1, ErrorMessage = "1 Character Required")]
        [DisplayName("Middle Initial")]
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
        [MinLength(5, ErrorMessage = "5 Characters Required")]
        [StringLength(18)]
        public string? Password { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Paper> Papers { get; set; }
    }

}

