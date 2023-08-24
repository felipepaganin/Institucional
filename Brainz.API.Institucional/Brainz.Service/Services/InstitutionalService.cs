using API.Framework.Interfaces;
using AutoMapper;
using Brainz.API.Framework.Exceptions;
using Brainz.API.Framework.Interfaces;
using Brainz.API.Framework.Services;
using Brainz.Data.Interfaces;
using Brainz.Domain.Enumerators;
using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Brainz.Service.Services
{
    public class InstitutionalService : ServiceBase, IInstitutionalService
    {
        #region Fields

        private readonly IApiContext _apiContext;
        private readonly IConfiguration _configuration;
        private readonly IJwtUtil _jwtUtil;
        private readonly IExampleRepository _exampleRepository;
        private readonly IGraphService _graphService;
        private readonly IMapper _mapper;
        private readonly IRedisServiceBase _rediscache;
        private readonly IMessagingExternalService _messagingExternalService;


        private const string keyMemberProfile = "MemberProfile_{0}";
        private const int keyExpirationMemberProfile = 5;

        #endregion

        #region Constructor

        public InstitutionalService(IApiContext apiContext, IConfiguration configuration, IJwtUtil jwtUtil, IExampleRepository exampleRepository,
            IGraphService graphService, IMapper mapper, IRedisServiceBase rediscache, IMessagingExternalService messagingExternalService) : base(apiContext)
        {
            _apiContext = apiContext;
            _configuration = configuration;
            _jwtUtil = jwtUtil;
            _exampleRepository = exampleRepository;
            _graphService = graphService;
            _mapper = mapper;
            _rediscache = rediscache;
            _messagingExternalService = messagingExternalService;
        }
        #endregion

        public InstitutionalViewModel List(Guid id)
        {
            var viewModel = new InstitutionalViewModel();

            var page = ReturnPage(id);

            if (page != null)
            {
                viewModel.Home = _mapper.Map<HomeViewModel>(page.Home);

                viewModel.Footer = _mapper.Map<FooterViewModel>(page.Footer);

                viewModel.TransparencyPortal = _mapper.Map<TransparencyPortalViewModel>(page.TransparencyPortal);

                viewModel.Events = _mapper.Map<EventsViewModel>(page.Events);

                viewModel.ContactUs = _mapper.Map<ContactUsViewModel>(page.ContactUs);

                viewModel.WhoAreWe = _mapper.Map<WhoAreWeViewModel>(page.WhoAreWe);

                viewModel.Search = _mapper.Map<SearchViewModel>(page.Search);

                viewModel.Teaching = _mapper.Map<TeachingViewModel>(page.Teaching);
            }

            else { throw new NotFoundException(ExampleErrors.NotFoundName); }

            return viewModel;
        }

        public SendCodeViewModel SendCode(string email)
        {
            var viewModel = new SendCodeViewModel();

            viewModel.Email = email;

            string key = string.Format(keyMemberProfile, viewModel.Email).ToLower();

            viewModel.Code = GenerateCode();

            var code = viewModel;

            _rediscache.SetDataToRedis(key, keyExpirationMemberProfile, JsonConvert.SerializeObject(code));

            var data = new EmailMessagePayload();
            data.Subject = "Código autenticação 2 fatores";
            data.Body = "-";
            data.TemplateId = "d-5d9d0342e3674cc6992f7ba1191f36c0";
            data.To = email;
            data.Attachment = new List<string>();
            data.TemplateDataJson = JsonConvert.SerializeObject(code);

            _messagingExternalService.SendMessage(data);

            return viewModel;
        }

        public SendCodeViewModel VerifyCode(SendCodeViewModel sendCodeViewModel)
        {
            var viewModel = new SendCodeViewModel();

            string key = string.Format(keyMemberProfile, sendCodeViewModel.Email).ToLower();

            var redisData = _rediscache.GetDataFromRedis(key);

            var cachedViewModel = JsonConvert.DeserializeObject<SendCodeViewModel>(redisData);

            if (cachedViewModel != null && cachedViewModel.Code == sendCodeViewModel.Code)
            {
                return viewModel;
            }

            else { throw new NotFoundException(ExampleErrors.InvalidPayload); }
        }

        private InstitutionalViewModel ReturnPage(Guid id)
        {
            string url = $"https://storagebrainzservices.blob.core.windows.net/files-institucional-dev/{id}.json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        InstitutionalViewModel institutionalViewModel = JsonConvert.DeserializeObject<InstitutionalViewModel>(content);

                        return institutionalViewModel;
                    }
                }
                catch (Exception ex)
                {
                    throw new BadRequestException(ExampleErrors.InvalidRequest);
                }
            }
            return null;
        }

        private string GenerateCode()
        {
            Random random = new Random();

            int randomNumber = random.Next(100_000_0);

            string numberFormated = randomNumber.ToString("D6");

            return numberFormated;
        }
    }
}