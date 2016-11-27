using System.Threading.Tasks;

namespace Core
{
    public interface IRequestHandler<T>
    {
        ValidationResult ValidateInput();
        Task<T> Execute();
    }
}