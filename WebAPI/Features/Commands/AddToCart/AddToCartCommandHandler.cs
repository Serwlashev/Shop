using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.AddToCart
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommandRequest, AddToCartCommandResponse>
    {
        private readonly IServiceManager _serviceManager;
        
        public AddToCartCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<AddToCartCommandResponse> Handle(AddToCartCommandRequest request, CancellationToken cancellationToken)
        {
            CartItemDTO cartItem = new CartItemDTO
            {
                Quantity = request.Quantity,
                DateCreated = request.DateCreated,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            bool result = await _serviceManager.CartService.CreateAsync(cartItem);

            return new AddToCartCommandResponse
            {
                Succeed = result,
                Message = result ? $"Cart item was successfully added" : $"Cannot add cart item!"
            };
        }
    }
}
