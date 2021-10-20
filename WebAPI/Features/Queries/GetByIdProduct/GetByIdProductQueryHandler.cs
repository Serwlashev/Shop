using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken token = default)
        {
            var product = await _serviceManager.ProductService.GetAsync(request.Id, token);

            return _mapper.Map<GetByIdProductQueryResponse>(product);
        }
    }
}
