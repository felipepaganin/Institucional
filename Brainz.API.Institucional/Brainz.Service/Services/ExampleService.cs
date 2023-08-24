using API.Framework.Interfaces;
using AutoMapper;
using Brainz.API.Framework.Exceptions;
using Brainz.API.Framework.Interfaces;
using Brainz.API.Framework.Result;
using Brainz.API.Framework.Services;
using Brainz.Data.Interfaces;
using Brainz.Domain.Entities;
using Brainz.Domain.Enumerators;
using Brainz.Domain.Payloads;
using Brainz.Domain.ViewModels;
using Brainz.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Brainz.Service.Services
{
    public class ExampleService: ServiceBase, IExampleService
    {
        #region Fields

        private readonly IApiContext _apiContext;
        private readonly IConfiguration _configuration;
        private readonly IJwtUtil _jwtUtil;
        private readonly IExampleRepository _exampleRepository;
        private readonly IGraphService _graphService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ExampleService(IApiContext apiContext, IConfiguration configuration, IJwtUtil jwtUtil, IExampleRepository exampleRepository, 
            IGraphService graphService, IMapper mapper) : base(apiContext)
        {
            _apiContext = apiContext;
            _configuration = configuration;
            _jwtUtil = jwtUtil;
            _exampleRepository = exampleRepository;
            _graphService = graphService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public IList<ExampleViewModel> List()
        {
            PagingValidation();

            List<ExampleViewModel> viewModel;
            var examples = _exampleRepository.List();

            viewModel = _mapper.Map<List<ExampleViewModel>>(examples);
            return viewModel;
        }

        public ExampleViewModel GetById(Guid id)
        {
            ExampleViewModel viewModel;
            var example = _exampleRepository.GetById(id);

            if (example == null)
            {
                throw new BadRequestException(ExampleErrors.NotFoundEntity);
            }

            viewModel = _mapper.Map<ExampleViewModel>(example);
            return viewModel;
        }

        public ExampleViewModel Insert(ExamplePayload payload)
        {
            ValidatePayLoad(payload);

            ExampleViewModel viewModel;

            var entity = new Example
            {
                Name = payload.Name,
                BirthDate = payload.BirthDate
            };
            entity.SetId(Guid.NewGuid());
            entity.Activate();

            var example = _exampleRepository.Insert(entity);

            if (example == null)
            {
                throw new BadRequestException(ExampleErrors.InvalidRequest);
            }

            viewModel = _mapper.Map<ExampleViewModel>(example);
            return viewModel;
        }

        public ExampleViewModel Update(ExamplePayload payload)
        {
            ValidatePayLoad(payload);

            ExampleViewModel viewModel;
            var entity = new Example
            {
                Name = payload.Name,
                BirthDate = payload.BirthDate,
                UpdateDate = DateTime.Now
            };
            entity.SetId(payload.Id);

            var example = _exampleRepository.UpdateData(entity);

            if (example == null)
            {
                throw new BadRequestException(ExampleErrors.InvalidRequest);
            }

            viewModel = _mapper.Map<ExampleViewModel>(example);
            return viewModel;
        }

        public ExampleViewModel Delete(Guid id)
        {
            ExampleViewModel viewModel;
            var example = _exampleRepository.Delete(id);

            viewModel = _mapper.Map<ExampleViewModel>(example);
            return viewModel;
        }

        #endregion

        #region Private Methods

        private void ValidatePayLoad(ExamplePayload payload)
        {
            if (string.IsNullOrEmpty(payload.Name))
            {
                _apiContext.Errors.Add(new Error(ExampleErrors.NotFoundName));
            }

            if (payload.BirthDate == null)
            {
                _apiContext.Errors.Add(new Error(ExampleErrors.NotFoundBirthDate));
            }

            if (_apiContext.Errors.Count > 0)
            {
                throw new BadRequestException(ExampleErrors.InvalidPayload);
            }
        }

        private void PagingValidation()
        {
            if (_apiContext.PagingContext.RequestPaging.Page <= 0)
            {
                _apiContext.PagingContext.RequestPaging.Page = 1;
            }

            if (_apiContext.PagingContext.RequestPaging.PageSize <= 0)
            {
                _apiContext.PagingContext.RequestPaging.PageSize = 20;
            }

            if (_apiContext.PagingContext.RequestPaging.PageSize > 100)
            {
                throw new BadRequestException(ExampleErrors.PageMaximumExceeded);
            }
        }

        #endregion
    }
}