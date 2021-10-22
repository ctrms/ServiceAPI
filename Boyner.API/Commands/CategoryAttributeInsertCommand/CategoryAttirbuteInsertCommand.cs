using MediatR;

namespace Boyner.API.Commands.ProductInsertCommand
{
    public class CategoryAttributeInsertCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
