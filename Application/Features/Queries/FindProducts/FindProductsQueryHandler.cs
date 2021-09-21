﻿using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Queries.FindProducts
{
    public class FindProductsQueryHandler
        : IRequestHandler<FindProductsQueryRequest, List<FindProductsQueryResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private IMapper _mapper;

        public FindProductsQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<FindProductsQueryResponse>> Handle(FindProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _serviceManager.ProductService.FindProductsAsync(request.SearchText);

            return _mapper.Map<List<FindProductsQueryResponse>>(products);
        }
    }
}
