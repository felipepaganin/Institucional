using Brainz.API.Framework.Exceptions;
using Brainz.Domain.Entities;
using Brainz.Domain.Enumerators;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Brainz.Service.Services
{
    public class GraphService : IGraphService
    {

        #region Fields

        private readonly IMemoryCache memoryCache;

        #endregion

        #region Constructor

        public GraphService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        #endregion

        #region Methods

        public GraphServiceClient GetGraphServiceClient(Institution institution)
        {
            var key = $"ConfidentialServiceClient_{institution.TenantId}";

            return memoryCache.GetOrCreate(key, e =>
            {
                e.SlidingExpiration = TimeSpan.FromMinutes(20);

                var clientApplication = ConfidentialClientApplicationBuilder
                    .Create(institution.AppClientId)
                    .WithTenantId(institution.TenantId)
                    .WithClientSecret(institution.AppSecret)
                    .Build();

                var authProvider = new ClientCredentialProvider(clientApplication);
                return new GraphServiceClient(authProvider);
            });
        }

        public GraphServiceClient GetGraphDelegateClient(Institution institution)
        {
            var key = $"ConfidentialDelegateToken_{institution.TenantId.ToLower()}";

            return memoryCache.GetOrCreate(key, e =>
            {
                e.SlidingExpiration = TimeSpan.FromMinutes(20);

                var scopes = new string[] { "user.read", "user.readwrite.all", "calendars.readwrite", "Calendars.ReadWrite.Shared", "group.readwrite.all", "profile", "directory.accessasuser.all", "directory.readwrite.all", "Presence.Read", "Presence.Read.All" };

                var clientApplication = PublicClientApplicationBuilder
                                .Create(institution.AppClientId)
                                .WithAuthority(AzureCloudInstance.AzurePublic, institution.TenantId)
                                .Build();

                UsernamePasswordProvider authProvider = new UsernamePasswordProvider(clientApplication, scopes);
                return new GraphServiceClient(authProvider);
            });
        }

        /////////////////////

        public UserGraphViewModel GetInformationFromUser(string officeId, Institution institution)
        {
            try
            {
                var graphClient = GetGraphServiceClient(institution);

                var user = graphClient.Users[officeId]
                    .Request()
                    .GetAsync()
                    .Result;

                return new UserGraphViewModel
                {
                    Id = user.Id,
                    Name = user.DisplayName,
                    Email = user.UserPrincipalName,
                    JobTitle = user.JobTitle == null ? "Coordenador" : user.JobTitle
                };
            }
            catch (Exception e)
            {
                throw new BadRequestException(GraphErrors.RetrieveUserInfo.Name.Replace("{error}", e.Message));
            }
        }

        #endregion
    }
}
