using System.ComponentModel.DataAnnotations;

namespace CustomFormsApp.Models
{
    public class Template
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; } // Markdown supported
        public string Topic { get; set; }

        [StringLength(100)]
        public string Tags { get; set; } // comma-separated tags
    }
}
