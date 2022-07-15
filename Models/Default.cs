using Microsoft.EntityFrameworkCore;

namespace CPMSwebapp.Models
{
    [Keyless]
    public class Default
    {
        public bool? EnabledReviewers { get; set; }
        public bool? EnabledAuthors { get; set; }
    }
}
