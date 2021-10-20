using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.UpdateCart
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommandRequest, UpdateCartCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public UpdateCartCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateCartCommandResponse> Handle(UpdateCartCommandRequest request, CancellationToken token = default)
        {
            CartItemDTO cartItem = new CartItemDTO
            {
                Id = request.Id,
                Quantity = request.Quantity,
                DateCreated = request.DateCreated,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            bool result = await _serviceManager.CartService.UpdateAsync(cartItem, token);

            return new UpdateCartCommandResponse
            {
                Succeed = result,
                Message = result ? $"Cart was successfully updated" : $"Cannot update cart!"
            };
        }
    }
}
