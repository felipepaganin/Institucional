using System;
using System.Text.Json.Serialization;

namespace Brainz.Domain.Payloads
{
    public class ExamplePayload
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
