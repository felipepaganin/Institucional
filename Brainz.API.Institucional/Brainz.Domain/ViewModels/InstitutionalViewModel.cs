using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainz.Domain.ViewModels
{
    public class InstitutionalViewModel
    {
        public HomeViewModel Home { get; set; }

        public FooterViewModel Footer { get; set; }

        public TransparencyPortalViewModel TransparencyPortal { get; set; } 

        public EventsViewModel Events { get; set; } 

        public ContactUsViewModel ContactUs { get; set; }

        public WhoAreWeViewModel WhoAreWe { get; set; }

        public SearchViewModel Search { get; set; }

        public TeachingViewModel Teaching { get; set; }
    }
}
