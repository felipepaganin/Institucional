using API.Framework.Interfaces;
using AutoMapper;
using Brainz.API.Framework.ApiClient;
using Brainz.API.Framework.Result;
using Brainz.API.Framework.Security;
using Brainz.API.Framework.Services;
using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Brainz.Service.Services
{
    public class TrilhasIntegrationService : ServiceBase, ITrilhasIntegrationService
    {
        #region Fields

        private readonly IApiContext _apiContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApiRestClient _client;

        #endregion

        #region Constructor

        public TrilhasIntegrationService(IApiContext apiContext,
            IConfiguration configuration, IMapper mapper) : base(apiContext)
        {
            _apiContext = apiContext;
            _configuration = configuration;
            _mapper = mapper;
            _client = new ApiRestClient(new JwtUtil(configuration))
            {
                Token = apiContext.SecurityContext.JwtToken,
                BaseEndpoint = new Uri(configuration.GetValue<string>("Service:Trilhas:APIUri") + "/v1/")
                //BaseEndpoint = new Uri("https://localhost:5001/api/v1/")
            };
            _client.AddAuthenticationHeader();

        }
        #endregion

        public PagedListViewModel<ApprenticeCourseCardViewModel> ListInstitutionalCoursesPaginated(InstitutionalCoursePayload payload)
        {


            var uri = _client.CreateRequestUri($"Institutional/GetInstitutionalCoursesPaginated",$"PageNumber={payload.PageNumber}&PageSize={payload.PageSize}");

            _client.AddAuthenticationHeader();

            var response = _client.GetAsync<ApiResponse<PagedListViewModel<ApprenticeCourseCardViewModel>>>(uri).Result;

            return response.Result;
        }

        public CourseDetailsViewModel GetCourseDetails(Guid id)
        {
            var uri = _client.CreateRequestUri($"Course/{id}/GetCourseDetails");

            _client.AddAuthenticationHeader();

            var response = _client.GetAsync<ApiResponse<CourseDetailsViewModel>>(uri).Result;

            return response.Result;
        }
    }
}