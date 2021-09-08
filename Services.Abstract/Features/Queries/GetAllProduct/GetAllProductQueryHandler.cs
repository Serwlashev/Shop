﻿using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler
        : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private IMapper _mapper;

        public GetAllProductQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _serviceManager.ProductService.GetAllAsync();

            return _mapper.Map<List<GetAllProductQueryResponse>>(products);
        }
    }
}
