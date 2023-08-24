using System;

namespace Brainz.Domain.ViewModels
{
    public class ApprenticeCourseCardViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string WorkLoad { get; set; }
        public bool Favorite { get; set; }
        public float Price { get; set; }
    }
}
