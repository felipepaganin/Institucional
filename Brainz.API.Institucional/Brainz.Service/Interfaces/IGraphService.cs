using Brainz.Domain.Entities;
using Brainz.Domain.ViewModels;
using Microsoft.Graph;

namespace Brainz.Service.Interfaces
{
    public interface IGraphService 
    {
        GraphServiceClient GetGraphServiceClient(Institution institution);
        GraphServiceClient GetGraphDelegateClient(Institution institution);

        UserGraphViewModel GetInformationFromUser(string officeId, Institution institution);
    }
}