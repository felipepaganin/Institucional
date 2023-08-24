using API.Framework.Interfaces;
using Brainz.API.Framework.Result;
using Brainz.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Brainz.Service.Interfaces;
using System.Collections.Generic;
using Brainz.API.Framework.Controllers;
using Brainz.API.Framework.Security.Authorization;
using System;
using Brainz.Domain.Payloads;
using Brainz.API.Framework.Swagger;

namespace Brainz.API.Institucional.Controllers
{
    /// <summary>
    /// Example Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExampleController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly IExampleService _exampleService = null;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>

        public ExampleController(IApiContext apiContext, IExampleService exampleService) : base(apiContext)
        {
            _exampleService = exampleService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Busca todos "exemplos"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        [Authorize("sub")]
        [SwaggerParameter("page", "Page to be returned", DataType = "integer", ParameterType = "query")]
        [SwaggerParameter("pageSize", "Records per page", DataType = "integer", ParameterType = "query")]
        [ProducesDefaultResponseType(typeof(ApiPaginatedResponse<List<ExampleViewModel>>))]
        public IActionResult List()
        {
            var response = this.ServiceInvoke(_exampleService.List);
            return response;
        }

        /// <summary>
        /// Busca "exemplos" pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}/[action]")]
        [Authorize("sub")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(ApiResponse<List<ExampleViewModel>>))]
        public IActionResult GetById(Guid id)
        {
            var response = this.ServiceInvoke(_exampleService.GetById, id);
            return response;
        }

        /// <summary>
        /// Insere um "exemplo"
        /// </summary>
        /// <param name="payload"></param>
        [Route("[action]")]
        [Authorize("sub")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ExampleViewModel>), 200)]
        public IActionResult Insert(ExamplePayload payload)
        {
            var response = ServiceInvoke(_exampleService.Insert, payload);
            return response;
        }

        /// <summary>
        /// Atualiza um "exemplo"
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="exampleId"></param>
        [Route("{exampleId}/[action]")]
        [Authorize("sub")]
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<ExampleViewModel>), 200)]
        public IActionResult Update(ExamplePayload payload, Guid exampleId)
        {
            payload.Id = exampleId;
            var response = ServiceInvoke(_exampleService.Update, payload);
            return response;
        }

        /// <summary>
        /// Remove um "exemplo"
        /// </summary>
        /// <param name="exampleId"></param>
        [Route("{exampleId}/[action]")]
        [Authorize("sub")]
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse<ExampleViewModel>), 200)]
        public IActionResult Delete(Guid exampleId)
        {
            var response = ServiceInvoke(_exampleService.Delete, exampleId);
            return response;
        }

        #endregion
    }
}
