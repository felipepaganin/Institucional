using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class SearchViewModel
    {
        public InnovationResearch InnovationResearch { get; set; }
        public ClinicalResearch ClinicalResearch { get; set; }
        public ContractManagement ContractManagement { get; set; }
    }

    public class InnovationResearch
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string TitleImage2 { get; set; }
        public string DescriptionImage2 { get; set; }
        public string ScientificResearchTitle { get; set; }
        public string ScientificResearchDescription { get; set; }
        public string SearchProjectTitle { get; set; }
        public string SearchProjectDescription { get; set; }
        public string VideoTitle { get; set; }
        public string VideoLink { get; set; }
        public string SearchFlow { get; set; }
        public string SearchFlowImage { get; set; }
        public string TitleDocument { get; set; }
        public List<Documents> Documents { get; set; }
    }

    public class Structure
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }

    public class Documents
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class ClinicalResearch
    {
        public string ClinicalResearchTitle { get; set; }
        public string ClinicalResearchImage { get; set; }
        public string StageClinicalResearchTitle { get; set; }
        public string StageClinicalResearchSubtitle { get; set; }
        public string StageClinicalResearchImage { get; set; }
        public string StageClinicalResearchDescription { get; set; }
        public string CaseSucessTitle { get; set; }
        public string CaseSucessSubTitle { get; set; }
        public string CaseSucessDescription { get; set; }
        public string CaseSucessImage { get; set; }
        public Structure Structure { get; set; }
    }

    public class ContractManagement
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageDescription { get; set; }
        public string Title2 { get; set; }
        public string SubTitle2 { get; set; }
        public string Image2 { get; set; }
    }
}