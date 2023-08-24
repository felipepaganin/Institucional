using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Brainz.Domain.Payloads
{
    public class EmailMessagePayload
    {
        [JsonIgnore]

        public Guid ApplicationId { get; set; }

        public string TemplateId { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<string> Attachment { get; set; }

        public List<ExtraInfo> ExtraInfo { get; set; }

        public string TemplateDataJson { get; set; }
    }
}