using API.Framework.Interfaces;
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
    public class MessagingExternalService : ServiceBase, IMessagingExternalService
    {
        #region Fields

        private readonly IApiContext _apiContext;
        private readonly ApiRestClient _client;
        private readonly string _applicationId;

        #endregion

        #region Constructor

        public MessagingExternalService(IApiContext apiContext, IConfiguration configuration)
            : base(apiContext)
        {
            _apiContext = apiContext;
            _apiContext.EnableTelemetry = configuration.GetValue<bool>("Telemetry:Active:Integrador");
            _applicationId = configuration.GetValue<string>("Application:Id:Integrador");

            _client = new ApiRestClient(new JwtUtil(configuration))
            {
                Token = apiContext.SecurityContext.JwtToken,
                BaseEndpoint = new Uri(configuration.GetValue<string>("Service:Messaging:BaseUri") + "/v1/")
                //BaseEndpoint = new Uri("https://localhost:5001/api/v1/")
            };
            _client.AddAuthenticationHeader();
        }

        #endregion

        #region Methods
        public MessagingProxySendViewModel SendMessage(EmailMessagePayload payload)
        {
            var uri = _client.CreateRequestUri($"Email/{_applicationId}/SendMessage");

            _client.AddAuthenticationHeader();
            var json = JsonConvert.SerializeObject(payload);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync<ApiResponse<MessagingProxySendViewModel>>(uri, data).Result;

            return response.Result;
        }

        #endregion
    }
}