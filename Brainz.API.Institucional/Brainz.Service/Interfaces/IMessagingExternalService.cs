using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainz.Service.Interfaces
{
    public interface IMessagingExternalService
    {
        MessagingProxySendViewModel SendMessage(EmailMessagePayload payload);
    }
}
