using Brainz.Domain.Entities;
using Brainz.Domain.ViewModels;

namespace Brainz.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : global::AutoMapper.Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Example, ExampleViewModel>();
        }
    }
}
