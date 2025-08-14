using MediatR;
using WebAPI.Models;

namespace WebAPI.Commands
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}