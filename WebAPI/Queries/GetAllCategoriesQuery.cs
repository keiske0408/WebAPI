using MediatR;
using WebAPI.Models;

namespace WebAPI.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        // This query doesn't need any parameters for getting all categories
        // You can add filtering parameters here if needed in the future
    }
}