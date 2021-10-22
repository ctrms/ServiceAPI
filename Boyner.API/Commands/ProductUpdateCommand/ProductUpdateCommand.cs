using MediatR;

namespace Boyner.API.Commands.ProductUpdateCommand
{
    public class ProductUpdateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
