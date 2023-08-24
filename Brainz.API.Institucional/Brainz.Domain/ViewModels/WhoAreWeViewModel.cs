using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class WhoAreWeViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageDescription { get; set; }
        public string ImageDescription2 { get; set; }
        public string ImageDescription3 { get; set; }
        public string ImageDescription4 { get; set; }
        public string Purpose { get; set; }
        public string Mission { get; set; }
        public string OurValues { get; set; }
        public string OurValuesImage { get; set; }
        public string OrganizationChart { get; set; }
        public string OrganizationChartImage { get; set; }
        public ExecutiveBoardViewModel ExecutiveBoard { get; set; }
        public BoardOfTrusteesViewModel BoardOfTrustees { get; set; }
        public FiscalCouncilViewModel FiscalCouncil { get; set; }
    }

    public class ExecutiveBoardViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BoardComposition> BoardComposition { get; set; }

    }
    public class BoardOfTrusteesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BoardComposition> BoardComposition { get; set; }
    }
    public class FiscalCouncilViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }

    }

    public class BoardComposition
    {
        public string Image { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
    }
}
