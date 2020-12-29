using System.ComponentModel.DataAnnotations;

namespace SimpleSite.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Fill the service name")]
        [Display(Name = "Service name")]
        public override string Title { get; set; }

        [Display(Name = "Short Description")]
        public override string Subtitle { get; set; }

        [Display(Name = "Full Description")]
        public override string Text { get; set; }
    }
}