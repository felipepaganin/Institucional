using API.Framework.Interfaces;
using Brainz.API.Framework.Controllers;
using Brainz.API.Framework.Result;
using Brainz.API.Framework.Security.Authorization;
using Brainz.API.Framework.Swagger;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Brainz.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainz.API.Institucional.Controllers
{
    /// <summary>
    /// Example Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstitutionalController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly IInstitutionalService _institutionalService = null;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>

        public InstitutionalController(IApiContext apiContext, IInstitutionalService institutionalService) : base(apiContext)
        {
            _institutionalService = institutionalService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Retorna as paginas "Site institucional"
        /// </summary>
        /// <returns></returns>
        [Authorize("sub")]
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(typeof(ApiResponse<InstitutionalViewModel>), 200)]
        public IActionResult List(Guid id)
        {
            var response = this.ServiceInvoke(_institutionalService.List, id);
            return response;
        }

        [Authorize("sub")]
        [HttpPost]
        [Route("SendCode")]
        [ProducesResponseType(typeof(ApiResponse<SendCodeViewModel>), 200)]

        public IActionResult SendCode(string email) 
        {
            var response = this.ServiceInvoke(_institutionalService.SendCode, email);
            return response;
        }

        [Authorize("sub")]
        [HttpPost]
        [Route("VerifyCode")]
        [ProducesResponseType(typeof(ApiResponse<SendCodeViewModel>), 200)]

        public IActionResult VerifyCode(SendCodeViewModel sendCodeViewModel)
        {
            var response = this.ServiceInvoke(_institutionalService.VerifyCode, sendCodeViewModel);
            return response;
        }

        #endregion
    }
}