using Brainz.Domain.Entities;
using Brainz.Domain.ViewModels;

namespace Brainz.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : global::AutoMapper.Profile
    {
        public ViewModelToDomainMappingProfile()
        {
           CreateMap<ExampleViewModel, Example>();
        }
    }
}
