using MediatR;
using System.Collections.Generic;

namespace Boyner.API.Commands.CategoryInsertCommand
{
    public class CategoryInsertCommand : IRequest<int>
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
    }
}
