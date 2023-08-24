using System;
using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class CourseDetailsViewModel
    {
        // AutoMapper properties
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Presentation { get; set; }
        public string WorkLoad { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool EnableCertificate { get; set; }

        public string IntroductionVideoUrl { get; private set; }
        public string IntroductionImageUrl { get; private set; }

        // Manual set value -> model to viewmodel
        public bool UserCanPrintCertificate { get; set; }
        public string ResponsibleUserCourse { get; set; }
        public bool Started { get; set; }
        // end

        public float Price { get; set; }


        public ICollection<CategoryDetailViewModel> Categories { get; set; }
        public ICollection<SubCategoryDetailViewModel> SubCategories { get; set; }
        public ICollection<ModuleDetailViewModel> Modules { get; set; }
    }

}
