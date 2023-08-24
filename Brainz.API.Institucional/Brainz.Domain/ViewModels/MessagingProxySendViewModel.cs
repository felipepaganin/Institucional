using Brainz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainz.Domain.ViewModels
{
    public class MessagingProxySendViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Message MessageRegister { get; set; }
    }
}
