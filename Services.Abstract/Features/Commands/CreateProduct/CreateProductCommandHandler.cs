﻿using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IServiceManager _serviceManager;
        
        public CreateProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO product = new ProductDTO
            {
                Name = request.Name,
                Price = request.Price,
                Number = request.Number,
                Category = new CategoryDTO { Id = request.CategoryId }
            };

            bool result = await _serviceManager.ProductService.CreateAsync(product);

            return new CreateProductCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product { product.Name } was successfully added" : $"Cannot add product { product.Name }!"
            };
        }
    }
}
