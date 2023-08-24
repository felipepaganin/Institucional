using API.Framework.Interfaces;
using Brainz.API.Framework.Database;
using Brainz.API.Framework.Database.Repository;
using Brainz.Data.Interfaces;
using Brainz.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brainz.Data.Repositories
{
    public class ExampleRepository : DapperRepository<Example>, IExampleRepository
    {
        #region Fields


        #endregion

        #region Constructor

        public ExampleRepository(IApiContext apiContext, IConfiguration configuration) : base(apiContext, configuration, "Example", "DB:Teste") 
        {
            
        }

        #endregion

        #region Methods

        public IList<Example> List()
        {
            var query = @"SELECT * FROM [Example] WHERE DeleteDate IS NULL ORDER BY CreationDate DESC";
            var entity = base.Get(query, null, true).ToList();
            return entity;
        }

        public Example GetById(Guid id)
        {
            var param = new DynamicParameters();
            param.Add("Id", id);

            var query = @"SELECT * FROM [Example] WHERE Id = @id AND DeleteDate IS NULL";
            var entity = base.Get(query, param, true).FirstOrDefault();
            return entity;
        }

        public Example Insert(Example entity)
        {
            base.Add(entity);
            return GetById(entity.Id);
        }

        public Example Delete(Guid id)
        {
            var entity = GetById(id);
            entity.DeleteDate = DateTime.Now;
            base.Update(entity);
            return entity;
        }

        public Example UpdateData(Example entity)
        {
            entity.UpdateDate = DateTime.Now;
            base.Update(entity);
            return entity;
        }

        #endregion
    }
}