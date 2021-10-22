using MediatR;

namespace Boyner.API.Commands.CategoryDeleteCommand
{
    public class CategoryDeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
