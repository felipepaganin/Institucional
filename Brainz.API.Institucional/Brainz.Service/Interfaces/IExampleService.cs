using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace Brainz.Service.Interfaces
{
    public interface IExampleService
    {
        IList<ExampleViewModel> List();
        ExampleViewModel GetById(Guid id);
        ExampleViewModel Insert(ExamplePayload payload);
        ExampleViewModel Update(ExamplePayload payload);
        ExampleViewModel Delete(Guid id);
    }
}