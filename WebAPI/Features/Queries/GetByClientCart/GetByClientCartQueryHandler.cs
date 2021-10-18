using AutoMapper;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Queries.GetByClientCart
{
    public class GetByClientCartQueryHandler : IRequestHandler<GetByClientCartQueryRequest, GetByClientCartQueryResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public GetByClientCartQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<GetByClientCartQueryResponse> Handle(GetByClientCartQueryRequest request, CancellationToken cancellationToken)
        {
            var cart = await _serviceManager.CartService.GetByConditionAsync(cart => cart.UserId.Equals(request.UserId));

            return _mapper.Map<GetByClientCartQueryResponse>(cart);
        }
    }
}
