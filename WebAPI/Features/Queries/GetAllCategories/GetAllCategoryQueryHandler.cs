using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler
        : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private IMapper _mapper;

        public GetAllCategoryQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _serviceManager.CategoryService.GetAllAsync();

            return _mapper.Map<List<GetAllCategoryQueryResponse>>(categories);
        }
    }
}
