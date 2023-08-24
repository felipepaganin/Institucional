using API.Framework.Interfaces;
using Brainz.API.Framework.Controllers;
using Brainz.API.Framework.Result;
using Brainz.API.Framework.Security.Authorization;
using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Brainz.API.Institucional.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TrilhasIntegrationController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly ITrilhasIntegrationService _trilhasIntegrationService = null;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>

        public TrilhasIntegrationController(IApiContext apiContext, ITrilhasIntegrationService trilhasIntegrationService) : base(apiContext)
        {
            _trilhasIntegrationService = trilhasIntegrationService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Retorna as paginas "Site institucional"
        /// </summary>
        /// <returns></returns>
        [Authorize("sub")]
        [HttpGet]
        [Route("ListInstitutionalCoursesPaginated")]
        [ProducesResponseType(typeof(ApiResponse<PagedListViewModel<ApprenticeCourseCardViewModel>>), 200)]
        public IActionResult ListInstitutionalCoursesPaginated([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            InstitutionalCoursePayload payload= new InstitutionalCoursePayload() { 
                PageNumber= pageNumber,
                PageSize= pageSize
            };

            var response = this.ServiceInvoke(_trilhasIntegrationService.ListInstitutionalCoursesPaginated, payload);
            return response;
        }

        [Authorize("sub")]
        [HttpGet]
        [Route("GetCourseDetails")]
        [ProducesResponseType(typeof(ApiResponse<CourseDetailsViewModel>), 200)]
        public IActionResult GetCourseDetails([FromQuery] Guid id)
        {
            var response = this.ServiceInvoke(_trilhasIntegrationService.GetCourseDetails, id);
            return response;
        }
        #endregion
    }
}