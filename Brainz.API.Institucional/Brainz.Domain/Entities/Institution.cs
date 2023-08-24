using Brainz.API.Framework.Database.EfCore.Model;
using System;

namespace Brainz.Domain.Entities
{
    public class Institution : AuditEntity<Guid>
    {
        public string Name { get; set; }
        public string TenantId { get; set; }
        public string AppClientId { get; set; }
        public string AppSecret { get; set; }
        public string AdminOfficeId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassWord { get; set; }
        public string OfficeIdCoordinatorsGroup { get; set; }
    }
}
