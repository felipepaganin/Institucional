using System;
using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class ModuleDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string WorkLoad { get; set; }
        public bool HasCertificate { get; set; }
        public int QtyLesson { get; set; }
        public ICollection<ModuleContentDetailViewModel> ModuleContents { get; set; }
    }

}
