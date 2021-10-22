using MediatR;

namespace Boyner.API.Commands.ProductDeleteCommand
{
    public class ProductDeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
