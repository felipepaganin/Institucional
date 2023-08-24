using System.Collections.Generic;

namespace Brainz.Domain.ViewModels
{
    public class TransparencyPortalViewModel
    {
        public string Title { get; set; }
        public List<DocumentsViewModel> Documents { get; set; }
    }
    public class DocumentsViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
