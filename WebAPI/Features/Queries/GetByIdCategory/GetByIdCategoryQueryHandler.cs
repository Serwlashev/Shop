using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken token = default)
        {
            var product = await _serviceManager.CategoryService.GetAsync(request.Id, token);

            return _mapper.Map<GetByIdCategoryQueryResponse>(product);
        }
    }
}
