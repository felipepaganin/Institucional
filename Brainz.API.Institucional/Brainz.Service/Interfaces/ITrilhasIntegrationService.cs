using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using System;

namespace Brainz.Service.Interfaces
{
    public interface ITrilhasIntegrationService
    {
        PagedListViewModel<ApprenticeCourseCardViewModel> ListInstitutionalCoursesPaginated(InstitutionalCoursePayload payload);
        CourseDetailsViewModel GetCourseDetails(Guid id);
    }
}
