using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSite.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Name (Title)")]
        public virtual string Title { get; set; }

        [Display(Name = "Short Description")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Full Description")]
        public virtual string Text { get; set; }

        [Display(Name = "Title Picture")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO metatag Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO metatag Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO metatag Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}