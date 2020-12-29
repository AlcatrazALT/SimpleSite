using System.ComponentModel.DataAnnotations;

namespace SimpleSite.Domain.Entities
{
    public class Textfield : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Page name(title)")]
        public override string Title { get; set; } = "Information page";

        [Display(Name = "Page content")]
        public override string Text { get; set; } = "The content of the page is filled in by the administrator";
    }
}