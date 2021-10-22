using MediatR;

namespace Boyner.API.Commands.ProductAttributeInsertCommand
{
    public class ProductAttributeInsertCommand : IRequest<int>
    {
        public string Value { get; set; }
        public int CategoryAttributeId { get; set; }
    }
}
