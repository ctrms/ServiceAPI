using MediatR;
using System.Collections.Generic;
namespace Boyner.API.Commands.ProductInsertCommand
{
    public class ProductInsertCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsStock { get; set; }
        public int CategoryId { get; set; }
        public List<ProductAttributeInsertCommand.ProductAttributeInsertCommand> Attributes { get; set; }
    }
}
