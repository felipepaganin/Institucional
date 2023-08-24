using Brainz.API.Framework.Database.EfCore.Model;
using System;

namespace Brainz.Domain.Entities
{
    public class Example : AuditEntity<Guid>
    {
        /// <summary>
        /// Campos Id, CreationDate, UpdateDate e DeleteDate são criados automaticamente em todas as tabelas por causa da 
        /// implementação do EF realizada na Brainz API Framework
        /// </summary>

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
