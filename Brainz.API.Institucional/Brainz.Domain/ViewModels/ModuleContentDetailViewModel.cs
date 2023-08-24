using System;

namespace Brainz.Domain.ViewModels
{
    public class ModuleContentDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int ModuleContentTypeId { get; set; }
        public bool IsRequired { get; set; }
    }

}
