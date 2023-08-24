using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class HomeViewModel
    {
        public string Institutional { get; set; }
        public string ImageInstitutional { get; set; }
        public string WhoWeAre { get; set; }
        public string ImageWhoWeAre { get; set; }
        public List<OurActivities> OurActivities { get; set; }
    }

    public class OurActivities
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string RedirectUrl { get; set; }
    }
}