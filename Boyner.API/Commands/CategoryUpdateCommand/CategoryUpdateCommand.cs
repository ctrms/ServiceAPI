using MediatR;

namespace Boyner.API.Commands.CategoryUpdateCommand
{
    public class CategoryUpdateCommand : IRequest<int>
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
    }
}
