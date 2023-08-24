using Brainz.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainz.Service.Interfaces
{
    public interface IInstitutionalService
    {
        InstitutionalViewModel List(Guid id);

        SendCodeViewModel SendCode(string email);

        SendCodeViewModel VerifyCode(SendCodeViewModel sendCodeViewModel);
    }
}
