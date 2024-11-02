using System.ComponentModel.DataAnnotations;

namespace CustomFormsApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        public bool DisplayInResults { get; set; }

        // Foreign key for Template
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
    public enum QuestionType
    {
        SingleLineText,
        MultiLineText,
        PositiveInteger,
        Checkbox
    }
}
