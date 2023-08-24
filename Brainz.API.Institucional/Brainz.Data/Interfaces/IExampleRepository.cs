using Brainz.API.Framework.Database.Interfaces;
using Brainz.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Brainz.Data.Interfaces
{
    public interface IExampleRepository : IDapperRepository<Example>
    {
        IList<Example> List();
        Example GetById(Guid id);
        Example Insert(Example entity);
        Example Delete(Guid id);
        Example UpdateData(Example entity);
    }
}
