using System.ComponentModel.DataAnnotations;

namespace CustomFormsApp.Models
{
    public class Template
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Topic { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }

        public bool IsPublic { get; set; }

        // Collection of Questions
        public List<Question> Questions { get; set; } = new();
    }
}
