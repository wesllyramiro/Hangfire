using System.Threading.Tasks;

namespace AtualizarEstoqueAutomatico.Jobs
{
    public interface IAtualizarEstoqueJob
    {
        Task Run();
    }
}
