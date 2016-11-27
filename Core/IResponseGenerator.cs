using System.Threading.Tasks;

namespace Core
{
    public interface IResponseGenerator
    {
        Task<TResult> Create<TResult>(IRequestHandler<TResult> requestHandler);
    }
}