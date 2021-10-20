using MediatR;

namespace Boyner.API.Commands.ProductInsertCommand
{
    public class ProductInsertCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool IsStock { get; set; }
        public int CategoryId { get; set; }
    }
}
