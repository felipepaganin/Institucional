using System;

namespace Brainz.Domain.Entities
{
    public class Message
    {
        public Guid ApplicationId { get; set; }

        public string MessagePayload { get; set; }

        public string MessageResponse { get; set; }

        public string Type { get; set; }
    }
}
