using System;
using System.Threading.Tasks;

namespace AtualizarEstoqueAutomatico.Jobs
{
    public class AtualizarEstoqueJob : IAtualizarEstoqueJob
    {
        public Task Run()
        {
            //var dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("America/Fortaleza"));
            var dataAtual = DateTime.Now;
            Console.WriteLine($"Testar execução | Horario : {dataAtual}");

            return Task.CompletedTask;
        }
    }
}
