using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class TeachingViewModel
    {
        public string Image { get; set; }
        public Presentation Presentation { get; set; }
        public Coremu Coremu { get; set; }
    }

    public class Presentation
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }

    public class Coremu
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string TitleMembers { get; set; }
        public string SubTitleMembers { get; set; }
        public List<Members> Members { get; set; }

    }

    public class Members
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
